using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usiminas.PluginExcel.Dto;
using Usiminas.PluginExcel.Entities;
using Usiminas.PluginExcel.Util;

namespace Usiminas.PluginExcel.Ux
{
    public partial class F_Pedido
    {
        #region Delegates
        private delegate void DelPopulateGridMap(ref List<InfoPlaDto> ret);
        private delegate void DelAddColumReciver(List<ReceiverCorresp> receiverCorresp);
        private delegate void DelAddColumPlace(List<PlaceCorresp> PlaceCorresp);
        #endregion
        #region  HandlerGrid
        /// <summary>
        /// bind the grid for maping fields from Excel
        /// </summary>
        /// <param name="ret"></param>
        private void PopulateGridMap(ref List<InfoPlaDto> ret)
        {
            foreach (var item in ret)
            {
                GridSales.Rows.Add(item.RefClient, item.Id, item.Receiver, null, null, item.Place, null, null, item.Mensagem, item.D1, item.D2, item.D3, item.DesiredPeriod);
            }
        }

        /// <summary>
        /// create new collunms to bind form map
        /// </summary>
        private void AddColumReciver(List<ReceiverCorresp> receiverCorresp)
        {
            foreach (DataGridViewRow item in GridSales.Rows)
            {
                DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(item.Cells["ReceiverMap"]);
                ContactCombo.DataSource = receiverCorresp.Select(p => p.Description).ToArray();

                string preencher = Functions.GetValueintoListRecebedor(deParaRecebedorDto, receiverCorresp, item.Cells["Receiver"].Value.ToString());

                if (preencher != null)
                {
                    item.Cells["ReceiverMap"].Value = preencher;
                    item.Cells["RecebedorMapeado"].Value = preencher;
                    //altera o val or da lista existente
                    infoPlaDtos.Where(p => p.Id.ToString() == item.Cells["ReceiverMap"].Value.ToString()).ToList().ForEach(s => s.PlacerMapped = preencher);
                    //dataGridView1.Rows[rowIndexYouWant].Cells["ComboColumn"].Value = "1";
                }
            }

        }

        /// <summary> 
        /// create new collunms to bind form map
        /// </summary>
        private void AddColumPlace(List<PlaceCorresp> PlaceCorresp)
        {
            foreach (DataGridViewRow item in GridSales.Rows)
            {

                DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(item.Cells["PlaceMap"]);
                ContactCombo.DataSource = PlaceCorresp.Select(p => p.Description).ToArray();
                //verifica se tem historico de mapeamento
                if (item.Cells["Place"].Value != null)
                {
                    string preencher = Functions.GetValueintoListBeneficiador(deParaBeneficiadorDto, PlaceCorresp, item.Cells["Place"].Value.ToString());
                    if (preencher != null)
                    {
                        item.Cells["PlaceMap"].Value = preencher;
                        item.Cells["RecebedorMapeado"].Value = preencher;
                        //altera o valor da lista existente
                        infoPlaDtos.Where(p => p.Id.ToString() == item.Cells["PlaceMap"].Value.ToString()).ToList().ForEach(s => s.PlacerMapped = preencher);
                        //dataGridView1.Rows[rowIndexYouWant].Cells["ComboColumn"].Value = "1";
                    }
                }

            }
        }
        /// <summary> 
        /// change value form field infoPlaDtos.PlacerMapped to currente place
        /// </summary>
        private void ChangeColumPlace()
        {
            foreach (DataGridViewRow item in GridSales.Rows)
            {
                //verifica se tem historico de mapeamento
                if (item.Cells["Place"].Value != null)
                {
                    item.Cells["RecebedorMapeado"].Value = item.Cells["PlaceMap"].Value;
                    //altera o valor da lista existente
                    infoPlaDtos.Where(p => p.Id.ToString() == item.Cells["PlaceMap"].Value.ToString()).ToList().ForEach(s => s.PlacerMapped = item.Cells["RecebedorMapeado"].Value.ToString());
                }

            }
        }
        /// <summary>
        /// change value form field infoPlaDtos.ReceiverMapped to currente Receiver
        /// </summary>
        private void ChangeColumReciver()
        {
            foreach (DataGridViewRow item in GridSales.Rows)
            {
                item.Cells["RecebedorMapeado"].Value = item.Cells["ReceiverMap"].Value;
                //altera o valor da lista existente
                infoPlaDtos.Where(p => p.Id.ToString() == item.Cells["ReceiverMap"].Value.ToString()).ToList().ForEach(s => s.PlacerMapped = item.Cells["RecebedorMapeado"].Value.ToString());
            }
        }
        private void GridSales_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            string HearderGrid = GridSales.Rows[0].Cells[e.ColumnIndex].Value.ToString();

            foreach (DataGridViewRow item in GridSales.Rows)
            {
                DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(item.Cells["PlaceMap"]);
                ContactCombo.DataSource = infoPlaDtos.First().PlaceCorresp.Select(p => p.Description).ToArray();
                //verifica se tem historico de mapeamento
                if (item.Cells["Place"].Value != null)
                {
                    string preencher = Functions.GetValueintoListBeneficiador(deParaBeneficiadorDto, infoPlaDtos.First().PlaceCorresp, item.Cells["Place"].Value.ToString());
                    if (preencher != null)
                    {
                        item.Cells["PlaceMap"].Value = preencher;
                        item.Cells["RecebedorMapeado"].Value = preencher;
                        //altera o valor da lista existente
                        infoPlaDtos.Where(p => p.Id.ToString() == item.Cells["PlaceMap"].Value.ToString()).ToList().ForEach(s => s.PlacerMapped = preencher);
                        //dataGridView1.Rows[rowIndexYouWant].Cells["ComboColumn"].Value = "1";
                    }
                }
            }
        }
        private IEnumerator<string> ValidRevicerMap(DataGridViewCellEventArgs e)
        {
            if (GridSales.Rows[e.RowIndex].Cells["ReceiverMap"].Value.ToString() == "")
                yield return String.Format("O campo {0} é obrigado a ter um recebedor mapeado, favor selecionar uma opção!", TabMapColGrid.receiver);

            if (GridSales.Rows[e.RowIndex].Cells["Receiver"].Value.ToString() != GridSales.Rows[e.RowIndex].Cells["ReciverMapped"].Value.ToString())
            {
                yield return String.Format("Favor seleconar um recebedor valdido!");
            }

            yield return null;
        }
        private void BtnIrParaCarrinho_Click(object sender, EventArgs e)
        {
            SelecionarValoresCombobox();
        }

        #endregion
        private void SelecionarValoresCombobox()
        {

            foreach (DataGridViewRow linha in GridSales.Rows)
            {

                //foreach (DataGridViewColumn coluna in GridSales.Columns)
                //{
                //    DataGridViewCell valorCelula = linha.Cells[coluna.Name.ToString()];

                //}
            }
            //GridSales.CurrentRow.Cells["UF"].ReadOnly;
        }

    }
}

