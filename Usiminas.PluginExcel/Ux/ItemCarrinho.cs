using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Usiminas.PluginExcel.Ux
{
    public partial class ItemCarrinho : UserControl
    {
        //private ItemCarrinhoDetalhe itemCarrinhoDetalhe;

        //public ItemCarrinhoDetalhe ItemCarrinhoDetalhe
        //{
        //    get { return itemCarrinhoDetalhe; }
        //    set { itemCarrinhoDetalhe = value; }
        //}
        //private int resizeheigt = 0; 
        public ItemCarrinho()
        {
            InitializeComponent();
            //resizeheigt += flowLayoutPanelIemCarrrinho.Size.Height;
        }
        public void AddItem(ItemCarrinhoDetalhe item)
        {
            //flowLayoutPanelIemCarrrinho.Controls.Add(item);
            //flowLayoutPanelIemCarrrinho.MaximumSize = new Size(flowLayoutPanelIemCarrrinho.Size.Width, resizeheigt + item.Size.Height);
            //flowLayoutPanelIemCarrrinho.AutoSize = true;
            //flowLayoutPanelIemCarrrinho.Size = new Size(flowLayoutPanelIemCarrrinho.Size.Width, flowLayoutPanelIemCarrrinho.Size.Height + item.Size.Height +5); //.Height = 1; // = this.Size.Height + item.Height;
        }
    }
}
