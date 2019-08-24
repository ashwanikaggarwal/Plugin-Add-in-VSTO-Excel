using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usiminas.PluginExcel.Entities;

namespace Usiminas.PluginExcel.Dto
{
    public class InfoPlaDto
    {
        public InfoPlaDto()
        {
            ReceiverCorresp = new List<ReceiverCorresp>();
            PlaceCorresp = new List<PlaceCorresp>();
            detalheItem = new DetalheItemDto();
            //detalheItem = new DetalheItemDto { Espessura = "1.7", Largura = "1200.0", Comprimento = "0", Produto = "BF", Qualidade = "NBR5915EEPG2" };
            minimoMultiplo = new MinimoMultiploDto();
            DataAceite = new DadosDataAceiteDto();
        }
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public bool Validado { get; set; }
        public string PartNumber { get; set; }
        public string RefClient { get; set; }
        public string Receiver { get; set; }
        public string Place { get; set; }
        public string DesiredPeriod { get; set; }
        public string D1 { get; set; }
        public string D2 { get; set; }
        public string D3 { get; set; }
        public bool Active { get; set; }
        public string ReceiverMapped { get; set; }
        public string PlacerMapped { get; set; }
        public List<ReceiverCorresp> ReceiverCorresp { get; set; }
        public List<PlaceCorresp> PlaceCorresp { get; set; }
        public DetalheItemDto detalheItem { get; set; }
        public MinimoMultiploDto minimoMultiplo { get; set; }
        public DadosDataAceiteDto DataAceite { get; set; }
        public DateTime dataSelecionada { set; get; }
        public decimal QuantidadeSelecionada { get; set; }
        public override string ToString()
        {
            string RET = string.Format("ID {0}|partnum: {1}|receiver: {2}|receiverMap: {3}|place: {4}|placerMap: {5}|D1: {6}|D2: {7}|D3 {8}| Val: {9}",
            this.Id, this.RefClient, this.Receiver, this.ReceiverMapped, this.Place, this.PlacerMapped, this.D1, this.D2, this.D3, this.Validado);
            return RET;
        }
    }


}
