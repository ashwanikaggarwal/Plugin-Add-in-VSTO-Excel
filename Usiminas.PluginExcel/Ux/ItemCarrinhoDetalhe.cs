using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Usiminas.PluginExcel.Dto;
using Usiminas.PluginExcel.Entities;

namespace Usiminas.PluginExcel.Ux
{
    public partial class ItemCarrinhoDetalhe : UserControl
    {
        public ItemCarrinhoDetalhe()
        {
            InitializeComponent();
        }
        private string DesejDecendio;
        private string DesejPeriodo;
        private string DesejToneleagem;

        private List<string> DisponToneleagem;
        private List<ReceiverCorresp> receiverCorresps;
        private string receiverCorrespsMapped;

        private List<PlaceCorresp> placeCorresps;
        private string placeCorrespsMapped;
        private int DisponMultiplo;

        public void Popular(InfoPlaDto parametro, string Decendio)
        {
            DadosDesejado( parametro,  Decendio);
        }
        private void DadosDesejado(InfoPlaDto parametro, string Decendio)
        {
            DesejDecendio = Decendio;
            switch (Decendio)
            {
                case "D1":
                    DesejToneleagem = parametro.D1;
                    break;
                case "D2":
                    DesejToneleagem = parametro.D2;
                    break;
                case "D3":
                    DesejToneleagem = parametro.D3;
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
            PopularDados();
        }
        private void PopularDados()
        {
            //define tonelagem disponivel
            DisponToneleagem = new List<string>();
            DisponToneleagem.Add("D1");
            DisponToneleagem.Add("D2");
            DisponToneleagem.Add("D3");

            OvCbIcDecendio.DataSource = DisponToneleagem;
            OvCbIcDecendio.SelectedItem = DesejDecendio;

            if (placeCorresps != null)
            {
                OvCbIcBeneficiador.DataSource = placeCorresps.Select(p => p.Description).ToList();
                OvCbIcBeneficiador.SelectedText = placeCorrespsMapped;
            }
            OvCbIcRecebedor.DataSource = receiverCorresps.Select(p => p.Description).ToList();
            OvCbIcRecebedor.SelectedText = receiverCorrespsMapped;

            OvLbIcDecendioMap.Text = DesejDecendio;
            OvLbIcTonelageMap.Text = DesejToneleagem;
            OvLbIcMesMap.Text = DesejPeriodo;
        }

    }
}
