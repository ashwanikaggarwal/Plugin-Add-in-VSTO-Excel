using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Dto
{
    public class MinimoMultiploDto
    {
        public string BK_PartnumberCliente { get; set; }
        public string MED_PesoMin { get; set; }
        public string MED_PesoMult { get; set; }

        public override string ToString()
        {
            return string.Format("PartNum: {0} |Min: {1} |mult: {2}",this.BK_PartnumberCliente, this.MED_PesoMin, this.MED_PesoMult);
        }
    }
}
