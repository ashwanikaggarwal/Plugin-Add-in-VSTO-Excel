using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Util
{
    public class CustomExceptions: Exception
    {
        public CustomExceptions(string messagem) : base(messagem)
        {

        }
        public CustomExceptions(string messagem, Exception exception) : base(messagem, exception)
        {

        }
        public string CustomMessagem()
        {
            if (this.Message.Contains("Authorization has been denied for this request"))
            {
                return "Sua sessão expirou. Favor logar novamente para continuar.";
            }

            return this.Message;
        }
    }
}
