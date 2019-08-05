using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Entities
{
    public class Grupo
    {
        public string CdGrupo { get; set; }
        public string DsGrupo { get; set; }
        public virtual ICollection<ClientLogin> Clientes { get; set; }
    }
}
