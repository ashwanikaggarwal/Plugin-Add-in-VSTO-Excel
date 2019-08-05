using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Dto
{
    public class DeParaBeneficiadorDto
    {
        public int Id { get; set; }
        public string CodCliente { get; set; }
        public string CodBeneficiadorCliente { get; set; }
        public string CodBeneficiadorUsiminas { get; set; }
        public string DesBeneficiadorUsiminas { get; set; }
        public string UserName { get; set; }
        public DateTime UltimaUtilizacao { get; set; }
        public bool Ativo { get; set; }
    }
}
