using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Entities
{
    public class User
    {

        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string CdCliente { get; set; }
        public string CdGrupo { get; set; }
        public PerfilEnum? PerfilId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string Tel { get; set; }
        public string TelCorporativo { get; set; }
        public bool StUsuario { get; set; }
        public DateTime? DtAtualizacao { get; set; }

        public virtual ClientLogin Cliente { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
    public enum PerfilEnum
    {
        Administrador = 1,
        Interno = 2,
        Master = 3,
        Cliente = 4
    }


}
