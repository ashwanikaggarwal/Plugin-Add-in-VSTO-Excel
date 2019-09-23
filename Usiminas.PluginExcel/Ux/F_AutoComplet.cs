using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Usiminas.PluginExcel.Ux
{
    public partial class F_AutoComplet : Form
    {
        public F_AutoComplet()
        {
            InitializeComponent();
        }
        //public EventHandler retornoValor;
        public int valor;

        private void BtnOvOptionTodas_Click(object sender, EventArgs e)
        {
            valor = 1;
            //if (this.retornoValor != null)
            //    this.retornoValor(sender, e);
            this.Hide();
        }

        private void BtnOvOptionIgual_Click(object sender, EventArgs e)
        {
            valor = 2;

            //if (this.retornoValor != null)
            //    this.retornoValor(sender, e);
            this.Hide();

        }
    }
}
