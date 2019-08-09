using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Usiminas.PluginExcel.Ux;
//NameSpace couldn't receive refencia to Usiminas.PluginExcel.Ux becouse class 'ThisRabbonCillecion' for defalt, reference name space root
namespace Usiminas.PluginExcel
{
    public partial class RibbonB2B
    {
        private void RibbonB2B_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void RibbonB2BCallForm(object sender, RibbonControlEventArgs e)
        {
            var Form = new F_Pedido();
            Form.Show();
        }
    }
}
