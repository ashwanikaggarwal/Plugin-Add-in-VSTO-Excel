using DataGridViewNumericUpDownElements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Usiminas.PluginExcel.Dto;
using Usiminas.PluginExcel.Services;
using Usiminas.PluginExcel.Util;

namespace Usiminas.PluginExcel.Ux
{

    public partial class F_Pedido
    {
        #region Emissao de pedido

        #region////// Variaveis globais 

        public List<EmitirPedidoItemDto> TabemitirPedidoList;
        decimal TabQuantTotalItens;
        decimal TabQuantTotalTonoDese;
        decimal TabQuantTotalTonoDisp;
        int TabidCarrinhoItem;
        Rectangle _Rectangle;
        DateTimePicker dtp;
        DataGridViewCellEventArgs ePubl; //usar 

        #endregion

        #region///// funcionalidades para carrinho Tabela
        private void TabTotalizadoresInit()
        {
            TbC_totalItens.Text = TabQuantTotalItens.ToString("N2");
            TbC_TotalTonelagem.Text = TabQuantTotalTonoDese.ToString("N2");
            TbC_TotalTonelagemReal.Text = TabQuantTotalTonoDisp.ToString("N2");
        }
        public void TabTotalizadoresAtualizar()
        {
            TabQuantTotalTonoDisp = TabemitirPedidoList.Select(p => p.QuantidadeDesejada).Sum();
            TbC_TotalTonelagemReal.Text = TabQuantTotalTonoDisp.ToString("N2");
        }

        private void TabPopulateItens()
        {
            GridCarrinho.Rows.Clear();
            TabQuantTotalItens = 0;
            TabQuantTotalTonoDese = 0;
            TabQuantTotalTonoDisp = 0;
            TabidCarrinhoItem = 1;
            TabemitirPedidoList = new List<EmitirPedidoItemDto>();
            infoPlaDtos.OrderBy(p => p.RefClient).ThenBy(p => p.dataSelecionada);
            dtp = new DateTimePicker();
            GridCarrinho.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.ValueChanged += new EventHandler(dtp_TextChange);
            //dtp.TextChanged += new EventHandler(dtp_TextChange);


            int i = 0;
            InfoPlaDto itemAnterior = new InfoPlaDto();

            foreach (var item in infoPlaDtos)
            {
                //Debug.WriteLine(item.ToString() + " - " + item.DataAceite.ToString() + " - " + item.minimoMultiplo.ToString());
                //popula o carrinho de acordo com o decendio
                if (item.RefClient == itemAnterior.RefClient)
                {
                    if (item.D1 != "" && item.D1 != "0")
                    {
                        addItemPedido(item, "D2");
                    }
                    if (item.D2 != "" && item.D2 != "0")
                    {
                        addItemPedido(item, "D2");
                    }
                    if (item.D3 != "" && item.D3 != "0")
                    {
                        addItemPedido(item, "D3");
                    }
                }
                else
                {

                    if (item.D1 != "" && item.D1 != "0")
                    {
                        addItemPedido(item, "D1");
                    }
                    if (item.D2 != "" && item.D2 != "0")
                    {
                        addItemPedido(item, "D2");
                    }
                    if (item.D3 != "" && item.D3 != "0")
                    {
                        addItemPedido(item, "D3");
                    }

                }
                itemAnterior = item;
                i++;
            }
            PreencherMultiplo();
        }

        private void addItemPedido(InfoPlaDto item, string decendio)
        {
            decimal DesejToneleagem = 0;
            DateTime DeseDt = new DateTime();
            switch (decendio)
            {
                case "D1":
                    DesejToneleagem = decimal.Parse(item.D1);
                    DeseDt = DateTime.ParseExact("01/" + item.DesiredPeriod.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    break;
                case "D2":
                    DesejToneleagem = decimal.Parse(item.D2);
                    DeseDt = DateTime.ParseExact("11/" + item.DesiredPeriod.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    break;
                case "D3":
                    DesejToneleagem = decimal.Parse(item.D3);
                    DeseDt = DateTime.ParseExact("21/" + item.DesiredPeriod.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    break;
            }

            string DispDecendio = null;
            var decendioconvert = Convert.ToInt32(item.DataAceite.Decendio);
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

            decimal DisponMultiplo = item.minimoMultiplo.MED_PesoMult;
            decimal DisponMultiploPreencher = 0;
            if (DisponMultiplo >= DesejToneleagem)
            {
                DisponMultiploPreencher = DisponMultiplo;
            }
            else
            {
                //quando a tonelagem for maior que o multiplo, arredonda para cima o proximo valor do multiplo
                DisponMultiploPreencher = (Math.Ceiling((DesejToneleagem / DisponMultiplo))) * DisponMultiplo;
            }
            string dtDisponivel = DeseDt >= item.DataAceite.DataCompleta ? DeseDt.ToShortDateString() : item.DataAceite.DataCompleta.ToShortDateString();
            GridCarrinho.Rows.Add(item.Id, item.RefClient, item.detalheItem.ToString(), decendio, DeseDt.ToShortDateString(), DesejToneleagem.ToString(), DispDecendio,
                dtDisponivel, DisponMultiploPreencher, item.ReceiverMapped, item.PlacerMapped, TabidCarrinhoItem);

            TabemitirPedidoList.Add(EmissaoPedidoAdd(item, TabidCarrinhoItem, item.DataAceite.DataCompleta, DisponMultiploPreencher));
            TabidCarrinhoItem += 1;
            TabQuantTotalItens += 1;
            TabQuantTotalTonoDese += DesejToneleagem;
            TabQuantTotalTonoDisp += DisponMultiploPreencher;
            TabTotalizadoresInit();
        }

        private EmitirPedidoItemDto EmissaoPedidoAdd(InfoPlaDto plaDto, int id, DateTime periodoDesejado, decimal tonelagem)
        {
            var emitirPedidoitem = new EmitirPedidoItemDto();
            emitirPedidoitem.Id = id;
            //receiverCorresps.Where(p => p.Description == receiverCorrespsMapped).Select(p => p.Id).First()
            emitirPedidoitem.CodigoRecebedor = plaDto.ReceiverCorresp.Where(p => p.Description == plaDto.ReceiverMapped).Select(p => p.Id).First();
            emitirPedidoitem.CodigoLocalEntrega = plaDto.PlacerMapped == null ? null : plaDto.PlaceCorresp.Where(p => p.Description == plaDto.PlacerMapped).Select(p => p.Id).First();
            emitirPedidoitem.Comprimento = decimal.Parse(plaDto.detalheItem.Comprimento);
            emitirPedidoitem.Largura = decimal.Parse(plaDto.detalheItem.Largura);
            emitirPedidoitem.Espessura = decimal.Parse(plaDto.detalheItem.Espessura);
            emitirPedidoitem.Norma = plaDto.detalheItem.Qualidade;
            emitirPedidoitem.multiplo = plaDto.minimoMultiplo.MED_PesoMult;
            emitirPedidoitem.DataDesejada = periodoDesejado;
            emitirPedidoitem.DataDesejadaFormat = null;
            emitirPedidoitem.DataAceite = plaDto.DataAceite.DataCompleta;
            emitirPedidoitem.QuantidadeDesejada = tonelagem;
            //emitirPedidoitem.QuantidadeDesejadaEspecifica = false;
            emitirPedidoitem.PartNumber = plaDto.RefClient;

            emitirPedidoitem.Usuario = auth.CurrentClient;
            emitirPedidoitem.CodigoEmissor = auth.CurrentClient;
            //////////////
            emitirPedidoitem.Dimensional = null;
            return emitirPedidoitem;
        }

        private void PreencherMultiplo()
        {
            foreach (DataGridViewRow item in GridCarrinho.Rows)
            {

                for (int i = 0; i < item.Cells.Count; i++)
                {
                    var tipo = item.Cells[i].GetType().Name;
                    if (tipo == "DataGridViewNumericUpDownCell")
                    {
                        DataGridViewNumericUpDownCell ContactCombo = (DataGridViewNumericUpDownCell)item.Cells[i];

                        EmitirPedidoItemDto EmitirPeididoList = TabemitirPedidoList.Where(p => p.Id.ToString() == item.Cells["Iditem"].Value.ToString()).FirstOrDefault();

                        ContactCombo.Minimum = EmitirPeididoList.multiplo;

                        ContactCombo.Increment = EmitirPeididoList.multiplo;

                        ContactCombo.Value = EmitirPeididoList.QuantidadeDesejada;

                        ContactCombo.Maximum = 10000;
                        //Dese_Tonelagem
                        if (EmitirPeididoList.QuantidadeDesejada > decimal.Parse(item.Cells["Dese_Tonelagem"].Value.ToString()))
                        {
                            ContactCombo.Style.BackColor = Color.Aquamarine;

                        }
                        else if (EmitirPeididoList.QuantidadeDesejada < decimal.Parse(item.Cells["Dese_Tonelagem"].Value.ToString()))
                        {
                            ContactCombo.Style.BackColor = Color.OrangeRed;

                        }
                        else
                        {
                            ContactCombo.Style.BackColor = Color.White;
                        }
                    }
                }
            }
        }

        private void TabEmissaoPedidoEdit(string id, string data, decimal tonelagem)
        {
            if (data != null)
            {
                TabemitirPedidoList.Where(p => p.Id == int.Parse(id)).ToList().ForEach(p =>
                {
                    p.DataDesejada = data == null ? p.DataDesejada : DateTime.ParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                });
            }

            if (tonelagem != 0)
            {
                TabemitirPedidoList.Where(p => p.Id == int.Parse(id)).ToList().ForEach(p =>
                {
                    p.QuantidadeDesejada = tonelagem;
                });
            }

        }

        private void dtp_TextChange(object sender, EventArgs e)
        {
            //////////////////
            ///usar a variavel ePubl que pega o endereço da celula ativa e atualiar manualmente a data;

            try
            {
                var col = GridCarrinho.Rows[GridCarrinho.CurrentCell.RowIndex].Cells[GridCarrinho.CurrentCell.RowIndex].OwningColumn.Name;
                //Debug.WriteLine("GridCarrinho.CurrentCell.RowIndex : " + GridCarrinho.CurrentCell.RowIndex + " |ePubl RowIndex: " + ePubl.RowIndex + " ColIndex: " + ePubl.ColumnIndex + "| dtp: " + dtp.Text.ToString() + "| colanme: " + col);
                if (ePubl.ColumnIndex != null)
                {
                    //GridCarrinho.CurrentCell.Value = dtp.Text.ToString();
                    // Debug.WriteLine("GridCarrinho.CurrentCell.RowIndex : " + GridCarrinho.CurrentCell.RowIndex  + "| dtp.txt: " + dtp.Text.ToString() + " | dt grid before" + GridCarrinho.Rows[ePubl.RowIndex].Cells["Disp_DataAceite"].Value.ToString());
                    GridCarrinho.Rows[ePubl.RowIndex].Cells["Disp_DataAceite"].Value = dtp.Text.ToString();

                    TabEmissaoPedidoEdit(GridCarrinho.Rows[GridCarrinho.CurrentCell.RowIndex].Cells["Iditem"].Value.ToString(), dtp.Text.ToString(), 0);

                    GridCarrinho.Rows[GridCarrinho.CurrentCell.RowIndex].Cells["Disp_Decendio"].Selected = true;
                    //Debug.WriteLine("GridCarrinho.CurrentCell.RowIndex : " + GridCarrinho.CurrentCell.RowIndex  + "| dtp.txt: " + dtp.Text.ToString() + " | dt grid after" + GridCarrinho.Rows[ePubl.RowIndex].Cells["Disp_DataAceite"].Value.ToString());
                    dtp.Visible = false;

                    dtp.Hide();

                    dtp.Focus();
                }

            }
            catch (Exception)
            {


            }
        }

        #endregion

        #region///// Eventos tabela
        private void GridCarrinho_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            switch (GridCarrinho.Columns[e.ColumnIndex].Name)
            {
                case "Disp_Tonela":

                    var tone1 = (DataGridView)sender;

                    TabEmissaoPedidoEdit(GridCarrinho.Rows[e.RowIndex].Cells["Iditem"].Value.ToString(), null, decimal.Parse(tone1.CurrentCell.EditedFormattedValue.ToString()));

                    if (decimal.Parse(tone1.CurrentCell.EditedFormattedValue.ToString()) > decimal.Parse(GridCarrinho.Rows[e.RowIndex].Cells["Dese_Tonelagem"].Value.ToString()))
                    {
                        tone1.CurrentCell.Style.BackColor = Color.Aquamarine;

                    }
                    else if (decimal.Parse(tone1.CurrentCell.EditedFormattedValue.ToString()) < decimal.Parse(GridCarrinho.Rows[e.RowIndex].Cells["Dese_Tonelagem"].Value.ToString()))
                    {
                        tone1.CurrentCell.Style.BackColor = Color.PaleVioletRed;

                    }
                    else
                    {
                        tone1.CurrentCell.Style.BackColor = Color.White;
                    }
                    TabTotalizadoresAtualizar();
                    break;
            }
        }

        private void GridCarrinho_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            switch (GridCarrinho.Columns[e.ColumnIndex].Name)
            {
                case "Disp_DataAceite":

                    var datammin = TabemitirPedidoList.Where(p => p.Id.ToString() == GridCarrinho.Rows[e.RowIndex].Cells["Iditem"].Value.ToString()).Select(p => p.DataAceite).FirstOrDefault();

                    _Rectangle = GridCarrinho.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                    dtp.Size = new Size(_Rectangle.Width + 100, _Rectangle.Height + 50);

                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);

                    dtp.Visible = true;

                    dtp.MinDate = datammin;

                    // dtp.Value = DateTime.ParseExact(GridCarrinho.Rows[e.RowIndex].Cells["Disp_DataAceite"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    //dtp.ValueChanged += new EventHandler(dtp_TextChange);
                    dtp.Show();

                    ePubl = e;

                    break;
            }
        }


        private void GridCarrinho_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }

        private async void BtnEnviarPedidoGrid_Click(object sender, EventArgs e)
        {
            try
            {

                AbrirLoad(TextosLoad.EnviandoPedidos);

                LogServices.LogEmissaoClass<List<EmitirPedidoItemDto>>(auth, "Enviar Pedido", "List<EmitirPedidoItemDto>", TabemitirPedidoList);

                var emissao = new PluginService(auth);

                var ret = await emissao.EmissaoDePedidoAsync(TabemitirPedidoList);

                LogServices.LogEmissaoClass<List<EmitirPedidoRespDto>>(auth, "Pedido Enviado", "List<EmitirPedidoItemDto>", ret);

                FecharLoad("OvAbaCarrinhoTabela");

                var F_Retorno = new F_RetornoPedido();

                F_Retorno.BuldingTempInvoce(ret);


                if (F_Retorno.InvokeRequired == true)
                {
                    F_Retorno.Invoke(new Action(() => this.Show()));

                }
                else
                {
                    F_Retorno.Show();
                }


            }
            catch (CustomExceptions ex)
            {
                LogServices.LogEmissaoClass<Exception>(auth, "erro", "retorno emissao de pedido", ex);

                MessageBox.Show(ex.CustomMessagem());
            }
            finally
            {
                FecharLoad("OvAbaCarrinhoTabela");
            }
        }
        #endregion 

        #endregion
    }
}
