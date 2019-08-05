using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Dto
{
    public class DeParaRecebedorDto
    {
        public int Id { get; set; }
        public string CodCliente { get; set; }
        public string CodRecebedorCliente { get; set; }
        public string CodRecebedorUsiminas { get; set; }
        public string DesRecebedorUsiminas { get; set; }
        public string UserName { get; set; }
        public DateTime UltimaUtilizacao { get; set; }
        public bool Ativo { get; set; }
    }
}
