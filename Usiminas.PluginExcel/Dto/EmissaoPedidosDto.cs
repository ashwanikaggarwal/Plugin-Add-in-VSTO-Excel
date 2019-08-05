using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Dto
{
    public class EmissaoPedidosDto
    {
        public EmissaoPedidosDto()
        {
            this.NumeroOVItems = new List<string>();
            this.PartNumbers = new List<string>();
            Plugin = true;
        }

        public string TipoBusca { get; set; }

        public string Mensagem { get; set; }

        public string Status { get; set; }

        public List<string> NumeroOVItems { get; set; }

        public List<string> PartNumbers { get; set; }

        public string NumeroOV { get; set; }

        public string Item { get; set; }

        public string PartNumber { get; set; }

        public string DataInicial { get; set; }

        public string DataFinal { get; set; }

        public string CodigoCliente { get; set; }

        public string TipoProduto { get; set; }

        public string NormaQualidade { get; set; }

        public float? Espessura { get; set; }

        public float? Largura { get; set; }

        public float? Comprimento { get; set; }
        public bool? Plugin { get; set; }
    }
}
