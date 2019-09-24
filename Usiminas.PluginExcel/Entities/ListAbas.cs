using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Usiminas.PluginExcel.Entities
{
    public class ListAbas
    {
        public TabPage Tab { get; set; }
        public bool Visible { get; set; }
        public bool LastTab { get; set; }

        public ListAbas(bool visible = true)
        {
            Visible = visible;
        }

        public override string ToString()
        {
            return String.Format("{0} | Visible: {1} | LastTab {2}", this.Tab.Name, this.Visible, this.LastTab);
        }
    }
}
