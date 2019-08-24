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
using Usiminas.PluginExcel.Services;
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
            if (GridSales.InvokeRequired == true)
            {
                GridSales.Invoke(new Action(() =>
                {
                    GridSales.Rows.Clear();
                }));
            }
            else
            {
                GridSales.Rows.Clear();
            }
            foreach (var item in ret)
            {

                if (GridSales.InvokeRequired == true)
                {
                    GridSales.Invoke(new Action(() => {
                        //GridSales.Controls.Clear();
                        GridSales.Rows.Add(item.RefClient, item.Id, item.Receiver, null, null, item.Place, null, null, item.Mensagem, item.D1, item.D2, item.D3, item.DesiredPeriod); }));
                }
                else
                {
                    GridSales.Rows.Add(item.RefClient, item.Id, item.Receiver, null, null, item.Place, null, null, item.Mensagem, item.D1, item.D2, item.D3, item.DesiredPeriod);
                }
            }
        }
        
        /// <summary>
        /// create new collunms to bind form map
        /// </summary>
        private void AddColumReciver(List<ReceiverCorresp> receiverCorresp)
        {
            foreach (DataGridViewRow item in GridSales.Rows)
            {
                DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(item.Cells[TabMapColGrid.RecebedorLista.Key]);
                ContactCombo.DataSource = receiverCorresp.Select(p => p.Description).ToArray();

                string preencher = Functions.GetValueintoListRecebedor(deParaRecebedorDto, receiverCorresp, item.Cells[TabMapColGrid.Recebedor.Key].Value.ToString());

                if (preencher != null)
                {
                    item.Cells[TabMapColGrid.RecebedorLista.Key].Value = preencher;
                    item.Cells[TabMapColGrid.RecebedorMapeado.Key].Value = preencher;
                    //altera o val or da lista existente
                    infoPlaDtos.Where(p => p.Id.ToString() == item.Cells[TabMapColGrid.RecebedorLista.Key].Value.ToString()).ToList().ForEach(s => s.PlacerMapped = preencher);
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

                DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(item.Cells[TabMapColGrid.BeneficiadorLista.Key]);
                ContactCombo.DataSource = PlaceCorresp.Select(p => p.Description).ToArray();

                //verifica se tem historico de mapeamento
                if (item.Cells[TabMapColGrid.Beneficiador.Key].Value != null)
                {
                    string preencher = Functions.GetValueintoListBeneficiador(deParaBeneficiadorDto, PlaceCorresp, item.Cells[TabMapColGrid.Beneficiador.Key].Value.ToString());
                    if (preencher != null)
                    {
                        item.Cells[TabMapColGrid.BeneficiadorLista.Key].ReadOnly = false;
                        item.Cells[TabMapColGrid.BeneficiadorMapeado.Key].ReadOnly = false;
                        item.Cells[TabMapColGrid.BeneficiadorLista.Key].Value = preencher;
                        item.Cells[TabMapColGrid.BeneficiadorMapeado.Key].Value = preencher;
                        //altera o valor da lista existente
                        infoPlaDtos.Where(p => p.Id.ToString() == item.Cells[TabMapColGrid.BeneficiadorLista.Key].Value.ToString()).ToList().ForEach(s => s.PlacerMapped = preencher);
                        //dataGridView1.Rows[rowIndexYouWant].Cells["ComboColumn"].Value = "1";
                    }
                }
                else
                {
                    item.Cells[TabMapColGrid.BeneficiadorLista.Key].ReadOnly = true;
                    item.Cells[TabMapColGrid.BeneficiadorMapeado.Key].ReadOnly = true;
                }

            }
        }

        private string ValidGridToMap(int RowIndex)
        {
            string retstring = null;
            if (GridSales.Rows[RowIndex].Cells[TabMapColGrid.RecebedorLista.Key].Value == "" || GridSales.Rows[RowIndex].Cells[TabMapColGrid.RecebedorLista.Key].Value == null)
                retstring = string.Format("O campo {0} é obrigado a ter um recebedor mapeado, favor selecionar uma opção!", TabMapColGrid.Recebedor.Value);

            if (GridSales.Rows[RowIndex].Cells[TabMapColGrid.Beneficiador.Key].Value != null)
            {
                if (GridSales.Rows[RowIndex].Cells[TabMapColGrid.Beneficiador.Key].Value.ToString() != "")
                {
                    if (GridSales.Rows[RowIndex].Cells[TabMapColGrid.BeneficiadorLista.Key].Value == "" || GridSales.Rows[RowIndex].Cells[TabMapColGrid.BeneficiadorLista.Key].Value == null)
                    {
                        retstring += String.Format("O mapeamento do campo {0} é obrigado a ter um {1} mapeado, favor selecionar uma opção!", TabMapColGrid.BeneficiadorLista.Value, TabMapColGrid.Beneficiador.Value);
                    }
                }
            }

            return retstring;
        }

        private bool SelecionarValoresCombobox()
        {
            bool ValidGrd = true;
            for (int linha = 0; linha < GridSales.Rows.Count; linha++)
            {
                GridSales.Rows[linha].Cells[TabMapColGrid.Messagem.Key].Value = null;
                var validacao = ValidGridToMap(linha);
                if (validacao != null)
                {
                    GridSales.Rows[linha].Cells[TabMapColGrid.Messagem.Key].Value = validacao;
                    ValidGrd = false;
                }

            }
            return ValidGrd;
        }
        private void PreencherValoresColuna(string ColunaLista, string ColunaMapeada, string PreencherTexto)
        {
            for (int linha = 0; linha < GridSales.Rows.Count; linha++)
            {
                GridSales.Rows[linha].Cells[ColunaLista].Value = PreencherTexto;
                GridSales.Rows[linha].Cells[ColunaMapeada].Value = PreencherTexto;
                if (ColunaLista == "RecebedorLista")
                {
                    infoPlaDtos.Where(p => p.Id.ToString() == GridSales.Rows[linha].Cells[TabMapColGrid.Id.Key].Value.ToString()).ToList().ForEach(s => s.ReceiverMapped = PreencherTexto);
                }
                if (ColunaLista == "BeneficiadorLista")
                {
                    infoPlaDtos.Where(p => p.Id.ToString() == GridSales.Rows[linha].Cells[TabMapColGrid.Id.Key].Value.ToString()).ToList().ForEach(s => s.PlacerMapped = PreencherTexto);
                }
            }
        }

        #endregion

        #region EventsGrid
        private void BtnIrParaCarrinho_Click(object sender, EventArgs e)
        {
            AbrirLoad("Motando carrinho...");
            if (SelecionarValoresCombobox() == false)
            {
                MessageBox.Show("Existem pendências no mapeamento!");
            }

            //caso exista novos mapeamentos, são salvos no banco
            var NovosMapeamentoBeneficiador = DeParaServices.NovosDeParaBeneficiador(deParaBeneficiadorDto, infoPlaDtos, auth.CurrentClient, auth.userName);
            var NovosMapeamentoRecebedor = DeParaServices.NovosDeParaRecebedor(deParaRecebedorDto, infoPlaDtos, auth.CurrentClient, auth.userName);
            PluginService pluginServices = new PluginService(auth);

            if (NovosMapeamentoBeneficiador != null && NovosMapeamentoBeneficiador.Count != 0)
                pluginServices.BeneficiadorDeParaPostAsync(NovosMapeamentoBeneficiador);

            if (NovosMapeamentoRecebedor != null && NovosMapeamentoRecebedor.Count != 0)
                pluginServices.RecebedorDeParaPostAsync(NovosMapeamentoRecebedor);

            PopulateItens();
            SelectContext("OvAbaCarrinho");
            FecharLoad();
        }

        private void GridSales_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (GridSales.Columns[e.ColumnIndex].Name.Equals(TabMapColGrid.BeneficiadorLista.Key))
            {
                if (GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.Beneficiador.Key].Value != null)
                {
                    string novoValor = GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.BeneficiadorLista.Key].Value.ToString();
                    GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.BeneficiadorMapeado.Key].Value = novoValor;
                    infoPlaDtos.Where(p => p.Id.ToString() == GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.Id.Key].Value.ToString()).ToList().ForEach(s => s.PlacerMapped = novoValor);
                    //SelecionarValoresCombobox();
                }
            }

            if (GridSales.Columns[e.ColumnIndex].Name.Equals(TabMapColGrid.RecebedorLista.Key))
            {
                if (GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.Recebedor.Key].Value != null)
                {
                    string novoValor = GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.RecebedorLista.Key].Value.ToString();
                    GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.RecebedorMapeado.Key].Value = novoValor;
                    infoPlaDtos.Where(p => p.Id.ToString() == GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.Id.Key].Value.ToString()).ToList().ForEach(s => s.ReceiverMapped = novoValor);
                    //SelecionarValoresCombobox();
                }
            }
            //GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.Messagem.Key].Value = ValidGridToMap(e).ToString();
        }


        private void GridSales_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (GridSales.Columns[e.ColumnIndex].Name.Equals(TabMapColGrid.BeneficiadorLista.Key))
            {
                if (GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.BeneficiadorLista.Key].Value != null)
                {
                    if (MessageBox.Show(string.Format("Deseja aplicar o valor {0} para todos campos?", GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.Beneficiador.Key].Value),
                        string.Format("Aplicar valores na coluna {0}", TabMapColGrid.Beneficiador.Key.ToString()), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string novoValor = GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.BeneficiadorLista.Key].Value.ToString();
                        PreencherValoresColuna(TabMapColGrid.BeneficiadorLista.Key, TabMapColGrid.BeneficiadorMapeado.Key, GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.BeneficiadorLista.Key].Value.ToString());
                    }

                    //SelecionarValoresCombobox();
                }
            }

            if (GridSales.Columns[e.ColumnIndex].Name.Equals(TabMapColGrid.RecebedorLista.Key))
            {
                if (GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.RecebedorLista.Key].Value != null)
                {
                    if (MessageBox.Show(string.Format("Deseja aplicar o valor '{0}' para todos campos?", GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.RecebedorLista.Key].Value),
                        string.Format("Aplicar valores na coluna {0}", TabMapColGrid.RecebedorLista.Value.ToString()), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string novoValor = GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.RecebedorLista.Key].Value.ToString();
                        PreencherValoresColuna(TabMapColGrid.RecebedorLista.Key, TabMapColGrid.RecebedorMapeado.Key, GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.RecebedorLista.Key].Value.ToString());
                    }
                }
            }
        }
    }

    #endregion


}


