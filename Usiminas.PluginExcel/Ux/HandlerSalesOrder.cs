using System;

namespace Usiminas.PluginExcel.Ux
{

    public partial class F_Pedido
    {
        private void PopulateItens()
        {
            ItemCarrinho[] itemCarrinhos = new ItemCarrinho[10];
            ItemCarrinhoDetalhe[] itemCarrinhosdetalhe = new ItemCarrinhoDetalhe[11];
            flowLayoutPanelCarrinho.AutoSize = false;
            //flowLayoutPanelCarrinho.MaximumSize = new System.Drawing.Size(40, 15); 
            //flowLayoutPanelCarrinho.MaximumSize.Width = 1;
            flowLayoutPanelCarrinho.Controls.Clear();
            for (int i = 0; i < itemCarrinhos.Length; i++)
            {
                itemCarrinhos[i] = new ItemCarrinho();
                itemCarrinhosdetalhe[i] = new ItemCarrinhoDetalhe();

                if (i < 1)
                {
                    flowLayoutPanelCarrinho.Controls.Add(itemCarrinhos[i]);
                }
                flowLayoutPanelCarrinho.Controls.Add(itemCarrinhosdetalhe[i]);
                flowLayoutPanelCarrinho.Controls.Add(itemCarrinhosdetalhe[i + 1]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopulateItens();
        }
    }
}
