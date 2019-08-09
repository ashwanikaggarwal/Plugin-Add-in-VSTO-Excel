using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Entitys
{
    public partial class SortSettingsDto
    {

        public string OrderBy { get; set; }
        public SortDirection? Direction { get; set; }
    }

    public enum SortDirection
    {
        Asc = 0,
        Desc = 1
    }
}
