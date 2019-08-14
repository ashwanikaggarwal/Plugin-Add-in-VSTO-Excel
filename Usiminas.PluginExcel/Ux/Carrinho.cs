using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Usiminas.PluginExcel.Dto;

namespace Usiminas.PluginExcel.Ux
{

    public partial class F_Pedido
    {
        int QuantTotalItens = 0;
        private void PopulateItens()
        {
            flowLayoutPanelCarrinho.Controls.Clear();
            foreach (var item in infoPlaDtos)
            {
                Debug.WriteLine(item.ToString());
            }
            infoPlaDtos.Sort((x, y) => x.RefClient.CompareTo(y.RefClient));
            int i = 0;
            InfoPlaDto itemAnterior = new InfoPlaDto();
            foreach (var item in infoPlaDtos)
            {
                Debug.WriteLine(item.ToString());

                if (item.RefClient == itemAnterior.RefClient)
                {
                    //popula o carrinho de acordo com o decendio
                    var itemCarrinhoDetalhe = new ItemCarrinhoDetalhe();
                    if (item.D1 != "")
                    {
                        itemCarrinhoDetalhe.Popular(item, "D1");
                        flowLayoutPanelCarrinho.Controls.Add(itemCarrinhoDetalhe);

                    }
                    if (item.D2 != "")
                    {
                        itemCarrinhoDetalhe.Popular(item, "D2");
                        flowLayoutPanelCarrinho.Controls.Add(itemCarrinhoDetalhe);

                    }
                    if (item.D3 != "")
                    {
                        itemCarrinhoDetalhe.Popular(item, "D3");
                        flowLayoutPanelCarrinho.Controls.Add(itemCarrinhoDetalhe);

                    }
                }
                else
                {
                    var Cabecalho = new ItemCarrinho();
                    Cabecalho.DetalCabecalho = item.detalheItem.ToString();
                    Cabecalho.DetalParNumber = item.RefClient;
                    flowLayoutPanelCarrinho.Controls.Add(Cabecalho);

                    ItemCarrinhoDetalhe itemCarrinhoDetalhe = new ItemCarrinhoDetalhe();
                    if (item.D1 != "")
                    {
                        itemCarrinhoDetalhe = new ItemCarrinhoDetalhe();
                        itemCarrinhoDetalhe.Popular(item, "D1");
                        flowLayoutPanelCarrinho.Controls.Add(itemCarrinhoDetalhe);

                    }
                    if (item.D2 != "")
                    {
                        itemCarrinhoDetalhe = new ItemCarrinhoDetalhe();
                        itemCarrinhoDetalhe.Popular(item, "D2");
                        flowLayoutPanelCarrinho.Controls.Add(itemCarrinhoDetalhe);

                    }
                    if (item.D3 != "")
                    {
                        itemCarrinhoDetalhe = new ItemCarrinhoDetalhe();
                        itemCarrinhoDetalhe.Popular(item, "D3");
                        flowLayoutPanelCarrinho.Controls.Add(itemCarrinhoDetalhe);

                    }
                }
                itemAnterior = item;
                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopulateItens();
        }

    }
}
