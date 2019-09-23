using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Dto
{
    public class EmitirPedidoItemDto
    {
        public EmitirPedidoItemDto()
        {
            TipoBusca = "P";
        }
        public int Id { get; set; }
        public string TipoBusca { get; set; }

        public string NumeroOV { get; set; }
        public string ItemOV { get; set; }
        public string PartNumber { get; set; }
        public string CodigoEmissor { get; set; }
        public string CodigoRecebedor { get; set; }
        public string TipoLocal { get; set; }
        public string CodigoLocalEntrega { get; set; }
        public DateTime DataDesejada { get; set; }
        public DateTime DataAceite { get; set; }
        public string DataDesejadaFormat { get; set; }
        public decimal QuantidadeDesejada { get; set; }
        public bool QuantidadeDesejadaEspecifica { get; set; }
        public string ReferenciaItemCliente { get; set; }
        public string PedidoCompraCliente { get; set; }
        public decimal Espessura { get; set; }
        public decimal Largura { get; set; }
        public decimal? Comprimento { get; set; }
        public string Produto { get; set; }
        public string Norma { get; set; }
        public bool Blank { get; set; }
        public string Dimensional { get; set; }
        public bool Bobina { get; set; }
        public string Borda { get; set; }
        public string Usuario { get; set; }
        public decimal multiplo { get; set; }

        public override string ToString()
        {
            return string.Format("id: {3} |partN: {0}|QuantDes: {1}| dt: {2}",this.PartNumber, this.QuantidadeDesejada, DataDesejada.ToShortDateString(), Id);
        }
    }
}
