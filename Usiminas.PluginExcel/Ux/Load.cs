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
    public partial class Load : Form
    {
        public Load(string texto = "Aguarde...")
        {
            InitializeComponent();
            textoLoad(texto);
        }

        public void textoLoad(string texto)
        {
            LoadOvLbAguarde.Text = texto;
        }

    }
}
