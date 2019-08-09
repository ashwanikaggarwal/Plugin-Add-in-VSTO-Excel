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
        }
        public string Mensagem { get; set; }
        public List<ReceiverCorresp> ReceiverCorresp { get; set; }
        public List<PlaceCorresp>PlaceCorresp { get; set; }
        public bool Validado { get; set; }
        public int Id { get; set; }

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

        public DetalheItemDto detalheItem { get; set; }
    }


}
