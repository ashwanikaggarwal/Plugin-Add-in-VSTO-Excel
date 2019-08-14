using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Dto
{
    public class DetalheItemDto
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Produto { get; set; }
        public string Qualidade { get; set; }
        public string Espessura { get; set; }
        public string Largura { get; set; }
        public string Comprimento { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return string.Format("{0} /{1} / Espe. {2} /Larg. {3} / Comp. {4}", this.Produto, this.Qualidade,this.Espessura,this.Largura, this.Comprimento) ;
        }
    }
}
