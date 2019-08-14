using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Dto
{
    public class CalendarioAceiteFilterDto
    {
        public string TipoBusca { get; set; }
        public string Mercado { get; set; }
        public string PartNumber { get; set; }
        public string NumeroOV { get; set; }
        public string Item { get; set; }
        public string CdGrupo { set; get; }
        public string CdCliente { set; get; }

    }
}
