using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Usiminas.PluginExcel.Dto
{
    public class LogPluginDto
    {
        public int id { get; set; }
        public string emissor { get; set; }
        public string jsonCampo { get; set; }
        public string json { get; set; }
        public DateTime dataHora { get; set; }
        public string msg { get; set; }
        public bool erro { get; set; }
        public string nomePc { get; set; }
        public string nomeUser { get; set; }

        public void ClassToJasonCampo<T>(T classe)
        {
            this.jsonCampo = new JavaScriptSerializer().Serialize(classe);
        }
    }
}
