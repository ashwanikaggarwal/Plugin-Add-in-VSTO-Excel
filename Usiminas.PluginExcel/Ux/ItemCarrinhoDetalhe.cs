using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Usiminas.PluginExcel.Dto;
using Usiminas.PluginExcel.Entities;

namespace Usiminas.PluginExcel.Ux
{
    public partial class ItemCarrinhoDetalhe : UserControl
    {

        #region variaveis
        public int Id;
        public int IdPai;

        public string DesejDecendio;
        public string DesejPeriodo;
        public decimal DesejToneleagem;
        public DateTime DeseDt;

        public string DispDecendio;
        public decimal DispToneleagem;

        public List<string> DisponDecendioList;
        public List<ReceiverCorresp> receiverCorresps;
        public string receiverCorrespsMapped;
        public string receiverMappedCod;

        public List<PlaceCorresp> placeCorresps;
        public string placeCorrespsMapped;
        public string placeMappedCod;
        public decimal DisponMultiplo;
        public DateTime DisponPeriodo;

        public bool quantAlterado = false;
        public bool dataAlterado = false;
        decimal quantDif = 0;

        public event EventHandler ButtonClick;
        #endregion

        #region inicialização de formulario
        public ItemCarrinhoDetalhe()
        {
            InitializeComponent();
        }
        public void Popular(InfoPlaDto parametro, string Decendio, int Id)
        {
            DadosDesejado(parametro, Decendio, Id);
        }
        private void DadosDesejado(InfoPlaDto parametro, string Decendio, int Id)
        {
            this.Id = Id;
            this.IdPai = parametro.Id;
            DesejDecendio = Decendio;
            switch (Decendio)
            {
                case "D1":
                    DesejToneleagem = decimal.Parse(parametro.D1);
                    DeseDt = DateTime.ParseExact("01/" + parametro.DesiredPeriod.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    break;
                case "D2":
                    DesejToneleagem = decimal.Parse(parametro.D2);
                    DeseDt = DateTime.ParseExact("11/" + parametro.DesiredPeriod.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    break;
                case "D3":
                    DesejToneleagem = decimal.Parse(parametro.D3);
                    DeseDt = DateTime.ParseExact("21/" + parametro.DesiredPeriod.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    break;
            }

            DesejPeriodo = parametro.DesiredPeriod;
            receiverCorresps = parametro.ReceiverCorresp;
            receiverCorrespsMapped = parametro.ReceiverMapped;

            if (parametro.PlaceCorresp.Count > 0)
            {
                placeCorrespsMapped = parametro.PlacerMapped;
                placeCorresps = parametro.PlaceCorresp;
            }
            else
            {
                placeCorresps = new List<PlaceCorresp>();
            }
            ///// dados da API
            var decendioconvert = Convert.ToInt32(parametro.DataAceite.Decendio);
            if (decendioconvert >= 1 && decendioconvert <= 10)
            {
                DispDecendio = "D1";
            }
            else if (decendioconvert >= 11 && decendioconvert <= 20)
            {
                DispDecendio = "D2";
            }
            else if (decendioconvert >= 21 && decendioconvert <= 31)
            {
                DispDecendio = "D3";
            }
            DisponMultiplo = parametro.minimoMultiplo.MED_PesoMult;
            PopularDados(parametro);
        }
        private void PopularDados(InfoPlaDto parametro)
        {

            //define tonelagem disponivel
            DisponDecendioList = new List<string>();
            DisponDecendioList.Add("D1");
            DisponDecendioList.Add("D2");
            DisponDecendioList.Add("D3");

            OvCbIcDecendio.DataSource = DisponDecendioList;
            OvCbIcDecendio.SelectedItem = DispDecendio;

            if (placeCorresps != null)
            {
                OvCbIcBeneficiador.DisplayMember = "Description";
                OvCbIcBeneficiador.ValueMember = "Id";
                OvCbIcBeneficiador.DataSource = placeCorresps;
                OvCbIcBeneficiador.SelectedValue = placeCorrespsMapped == null ? "0" : placeCorresps.Where(p => p.Description == placeCorrespsMapped).Select(p => p.Id).First();
            }

            OvCbIcRecebedor.DisplayMember = "Description";
            OvCbIcRecebedor.ValueMember = "Id";
            OvCbIcRecebedor.DataSource = receiverCorresps;
            OvCbIcRecebedor.SelectedValue = receiverCorrespsMapped == null ? "0" : receiverCorresps.Where(p => p.Description == receiverCorrespsMapped).Select(p => p.Id).First();

            // parametros de tonelagem
            OvNuIcMultTonelage.Increment = DisponMultiplo;
            OvNuIcMultTonelage.Minimum = DisponMultiplo;
            OvNuIcMultTonelage.Maximum = 10000;

            if (DisponMultiplo >= DesejToneleagem)
            {
                OvNuIcMultTonelage.Value = DisponMultiplo;
            }
            else
            {
                //quando a tonelagem for maior que o multiplo, arredonda para cima o proximo valor do multiplo
                OvNuIcMultTonelage.Value = (Math.Ceiling((DesejToneleagem / DisponMultiplo))) * DisponMultiplo;
                
            }
            TonelagemAtualizar();
            //parametro de data de aceite
            OvDtAceiteDisp.MinDate = parametro.DataAceite.DataCompleta;

            if (DeseDt <= parametro.DataAceite.DataCompleta)
            {
                OvDtAceiteDisp.Value = parametro.DataAceite.DataCompleta;
            }
            else
            {
                OvDtAceiteDisp.Value = DeseDt;
            }

            DataAtualizar();
            RecebedorAlterar();
            BeneficiadorAlterar();
            OvLbIcDecendioMap.Text = DesejDecendio;
            OvLbIcTonelageMap.Text = DesejToneleagem.ToString();
            OvLbIcMesMap.Text = DesejPeriodo;
        }

        #endregion

        #region Eventos que atualiza dados das variaveis 

        private void TonelagemAtualizar()
        {

            DispToneleagem = OvNuIcMultTonelage.Value;
            quantDif = DesejToneleagem - DispToneleagem;

        }
        private void DataAtualizar()
        {

            if (OvDtAceiteDisp.Value.Day >= 1 && OvDtAceiteDisp.Value.Day <= 10)
            {
                OvDtAceiteDisp.Value = DateTime.ParseExact("01/" + OvDtAceiteDisp.Value.Month + "/" + OvDtAceiteDisp.Value.Year, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DispDecendio = "D1";

            }
            else if (OvDtAceiteDisp.Value.Day >= 11 && OvDtAceiteDisp.Value.Day <= 20)
            {
                OvDtAceiteDisp.Value = DateTime.ParseExact("11/" + OvDtAceiteDisp.Value.Month + "/" + OvDtAceiteDisp.Value.Year, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DispDecendio = "D2";

            }
            else if (OvDtAceiteDisp.Value.Day >= 21 && OvDtAceiteDisp.Value.Day <= 31)
            {
                OvDtAceiteDisp.Value = DateTime.ParseExact("21/" + OvDtAceiteDisp.Value.Month + "/" + OvDtAceiteDisp.Value.Year, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DispDecendio = "D3";
            }
            DisponPeriodo = OvDtAceiteDisp.Value;
            OvCbIcDecendio.SelectedItem = DispDecendio;
            itemAlterado();
        }

        private void RecebedorAlterar()
        {
            receiverMappedCod = OvCbIcRecebedor.SelectedValue.ToString();
        }

        private void BeneficiadorAlterar()
        {
            placeMappedCod = OvCbIcBeneficiador.SelectedValue.ToString();
        }

        private void itemAlterado()
        {
            quantAlterado = quantDif != 0 ? true : false;
            dataAlterado = DeseDt != DisponPeriodo ? true : false;
        }

        #endregion

        #region Eventos do formulario
        private void OvNuIcMultTonelage_ValueChanged(object sender, EventArgs e)
        {
            TonelagemAtualizar();
            itemAlterado();

            //bubble the event up to the parent
            if (this.ButtonClick != null)
                this.ButtonClick(this, e);
        }
        private void OvDtAceiteDisp_ValueChanged(object sender, EventArgs e)
        {
            DataAtualizar();
            itemAlterado();
        }

        private void OvCbIcRecebedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RecebedorAlterar();
        }

        private void OvCbIcBeneficiador_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BeneficiadorAlterar();
        } 
        #endregion
    }
}
