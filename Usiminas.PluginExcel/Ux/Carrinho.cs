using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Usiminas.PluginExcel.Dto;
using Usiminas.PluginExcel.Services;

namespace Usiminas.PluginExcel.Ux
{

    public partial class F_Pedido
    {
        public List<EmitirPedidoItemDto> emitirPedidoList;
        decimal QuantTotalItens;
        decimal QuantTotalTonoDese;
        decimal QuantTotalTonoDisp;
        int idCarrinhoItem = 1;
        private void TotalizadoresInit(ItemCarrinhoDetalhe itemCarrinho)
        {
            QuantTotalTonoDisp += itemCarrinho.DispToneleagem;
            QuantTotalTonoDese += itemCarrinho.DesejToneleagem;
            QuantTotalItens += 1;
            Debug.WriteLine("id e idpai:" + itemCarrinho.Id.ToString() +  " / " + itemCarrinho.IdPai.ToString() + "| decendio: " + itemCarrinho.DesejDecendio.ToString() + "| tone disp" 
            + itemCarrinho.DesejToneleagem.ToString() + " - total " + QuantTotalTonoDese.ToString());

            OvLbTotalToneContFinal.Text = QuantTotalTonoDisp.ToString("N2");
            OvLbTotalToneCont.Text = QuantTotalTonoDese.ToString("N2");
            OvLbTotalItemCont.Text = QuantTotalItens.ToString();

        }
        public void TotalizadoresAtualizar()
        {
            QuantTotalTonoDisp = emitirPedidoList.Select(p => p.QuantidadeDesejada).Sum();
            OvLbTotalToneContFinal.Text = QuantTotalTonoDisp.ToString("N2");
        }
        private void PopulateItens()
        {
            flowLayoutPanelCarrinho.Controls.Clear();
            //flowLayoutPanelCarrinho.Click += new System.EventHandler();

            //foreach (var item in infoPlaDtos)
            //{
            //    Debug.WriteLine(item.ToString() + " - " + item.DataAceite.ToString() + " - " + item.minimoMultiplo.ToString());
            //}
            QuantTotalItens = 0;
            QuantTotalTonoDese = 0;
            QuantTotalTonoDisp = 0;
            emitirPedidoList = new List<EmitirPedidoItemDto>();

            infoPlaDtos.Sort((x, y) => x.RefClient.CompareTo(y.RefClient));

            int i = 0;
            InfoPlaDto itemAnterior = new InfoPlaDto();

            foreach (var item in infoPlaDtos)
            {
                Debug.WriteLine(item.ToString() + " - " + item.DataAceite.ToString() + " - " + item.minimoMultiplo.ToString());
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
                    var Cabecalho = new ItemCarrinho();
                    Cabecalho.DetalCabecalho = item.detalheItem.ToString();
                    Cabecalho.DetalParNumber = item.RefClient;
                    flowLayoutPanelCarrinho.Controls.Add(Cabecalho);
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
        }
        private void addItemPedido( InfoPlaDto item, string decendio)
        {
            ItemCarrinhoDetalhe itemCarrinhoDetalhe = new ItemCarrinhoDetalhe();
            
            itemCarrinhoDetalhe.Popular(item, decendio, idCarrinhoItem);

            itemCarrinhoDetalhe.ButtonClick += ItemCarrinhoDetalhe_ButtonClick;

            TotalizadoresInit(itemCarrinhoDetalhe);
            flowLayoutPanelCarrinho.Controls.Add(itemCarrinhoDetalhe);
            //item.QuantidadeSelecionada = itemCarrinhoDetalhe.DispToneleagem;
            //item.dataSelecionada = itemCarrinhoDetalhe.DisponPeriodo;
            emitirPedidoList.Add(EmissaoPedidoAdd(item, itemCarrinhoDetalhe));
            idCarrinhoItem += 1;
        }
        private void ItemCarrinhoDetalhe_ButtonClick(object sender, EventArgs e)
        {
            EmissaoPedidoEdit((ItemCarrinhoDetalhe)sender);
            TotalizadoresAtualizar();
        }

        private EmitirPedidoItemDto EmissaoPedidoAdd(InfoPlaDto plaDto, ItemCarrinhoDetalhe itemCarrinho)
        {
            var emitirPedidoitem = new EmitirPedidoItemDto();
            emitirPedidoitem.Id = itemCarrinho.Id;
            //receiverCorresps.Where(p => p.Description == receiverCorrespsMapped).Select(p => p.Id).First()
            emitirPedidoitem.CodigoRecebedor = plaDto.ReceiverCorresp.Where(p => p.Description == plaDto.ReceiverMapped).Select(p => p.Id).First();
            emitirPedidoitem.CodigoLocalEntrega = plaDto.PlacerMapped == null ? null : plaDto.PlaceCorresp.Where(p => p.Description == plaDto.PlacerMapped).Select(p => p.Id).First();
            emitirPedidoitem.Comprimento = decimal.Parse(plaDto.detalheItem.Comprimento);
            emitirPedidoitem.Largura = decimal.Parse(plaDto.detalheItem.Largura);
            emitirPedidoitem.Espessura = decimal.Parse(plaDto.detalheItem.Espessura);
            emitirPedidoitem.Norma = plaDto.detalheItem.Qualidade;

            emitirPedidoitem.DataDesejada = itemCarrinho.DisponPeriodo;
            emitirPedidoitem.DataDesejadaFormat = null;

            emitirPedidoitem.QuantidadeDesejada = itemCarrinho.DispToneleagem;
            //emitirPedidoitem.QuantidadeDesejadaEspecifica = false;
            emitirPedidoitem.PartNumber = plaDto.RefClient;

            emitirPedidoitem.Usuario = auth.CurrentClient;
            emitirPedidoitem.CodigoEmissor = auth.CurrentClient;
            //////////////
            emitirPedidoitem.Dimensional = null;
            return emitirPedidoitem;
        }
        private void EmissaoPedidoEdit(ItemCarrinhoDetalhe itemCarrinhoDetalhe)
        {
            ///fazer enventos que deve apontar para os objetos corretos ao alterar
            ///recebedor, beneficiador, quantidade e data

            emitirPedidoList.Where(p => p.Id == itemCarrinhoDetalhe.Id).ToList().ForEach(p =>
            {
                p.CodigoRecebedor = itemCarrinhoDetalhe.receiverMappedCod;
                p.CodigoLocalEntrega = itemCarrinhoDetalhe.placeMappedCod;
                p.DataDesejada = itemCarrinhoDetalhe.DeseDt;
                p.QuantidadeDesejada = itemCarrinhoDetalhe.DispToneleagem;
            });

        }
        private async void BtnEnviarPedido_Click(object sender, EventArgs e)
        {
            try
            {

                AbrirLoad("Enviando pedido!");
                LogServices.LogEmissaoClass<List<EmitirPedidoItemDto>>(auth, "Enviar Pedido", "List<EmitirPedidoItemDto>", emitirPedidoList);

                var emissao = new PluginService(auth);
                var ret = await emissao.EmissaoDePedidoAsync(emitirPedidoList);
                LogServices.LogEmissaoClass<EmitirPedidoRespDto>(auth, "Pedido Enviado", "List<EmitirPedidoItemDto>", ret);

                MessageBox.Show(ret.E_MESSAGE);
            }
            catch (Exception ex)
            {
                LogServices.LogEmissaoClass<Exception>(auth, "erro", "retorno emissao de pedido", ex);

            }
            finally
            {
                FecharLoad();
            }
        }

    }
}
