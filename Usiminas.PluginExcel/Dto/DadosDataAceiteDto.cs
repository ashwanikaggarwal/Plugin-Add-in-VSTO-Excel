using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Dto
{
    public class DadosDataAceiteDto
    {
        public string PartNumber { get; set; }
        public string Cliente { get; set; }
        public string Decendio { get; set; }
        public string MesAno { get; set; }
        public DateTime DataCompleta { get; set; }
        public bool Success { get; set; }
        public string Mensage { get; set; }
        public override string ToString()
        {
            return string.Format("PartNumber: {0} |Data: {1} ", PartNumber, DataCompleta.ToShortDateString());
        }
    }
}
