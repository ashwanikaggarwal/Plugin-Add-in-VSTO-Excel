using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Dto
{
    public class ValidaPesoMultiPartNumberDto
    {
        public ValidaPesoMultiPartNumberDto()
        {
            this.Recebedores = new List<string>();
            this.PartNumbers = new List<string>();
        }
        public string CdCliente { get; set; }
        public List<string> Recebedores { get; set; }
        public List<string> PartNumbers { get; set; }
        public decimal Tonelagem { get; set; }

    }
}
