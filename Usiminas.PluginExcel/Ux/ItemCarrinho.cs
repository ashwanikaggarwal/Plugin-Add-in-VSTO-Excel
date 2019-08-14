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
        private string DetalheCabecalho;

        public string DetalCabecalho
        {
            get { return DetalheCabecalho; }
            set { DetalheCabecalho = value; }
        }
        private string PartNumberDetalhe;

        public string DetalParNumber
        {
            get { return PartNumberDetalhe; }
            set { PartNumberDetalhe = value; }
        }

        public ItemCarrinho()
        {
            InitializeComponent();
            //resizeheigt += flowLayoutPanelIemCarrrinho.Size.Height;
        }

        private void ItemCarrinho_Load(object sender, EventArgs e)
        {
            this.ICDetalhamento.Text = DetalheCabecalho;
            this.ICPartNumber.Text = PartNumberDetalhe;
        }
    }
}
