using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Entities
{
    public class ClientLogin
    {
        public string CdCliente { get; set; }
        public string DsCliente { get; set; }
        public string CdGerencia { get; set; }
        public bool IsClienteEmissor { get; set; }
        public string CdGrupo { get; set; }

    }
}
