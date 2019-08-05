using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Dto
{
    public class ClientePluginDto
    {
        public int id { get; set; }
        public string codigoCliente { get; set; }
        public string descricaoCliente { get; set; }
        public string codigoGrupoCompra { get; set; }
        public string estado { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string cnpj { get; set; }
    }
}
