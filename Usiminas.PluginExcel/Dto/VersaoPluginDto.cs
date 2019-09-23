using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Dto
{
    public class VersaoPluginDto
    {
        public int id { get; set; }
        public decimal minimaVersao { get; set; }
        public decimal ultimaVersao { get; set; }
        public DateTime dtUltimaVersao { get; set; }
        public bool ativo { get; set; }
    }
}

