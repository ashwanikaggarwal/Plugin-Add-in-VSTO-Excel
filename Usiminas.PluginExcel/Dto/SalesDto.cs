using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Dto
{
    public class SalesDto
    {
        public int Id { get; set; }

        public string CD_Cliente { get; set; }
        public string UserName { get; set; }
        public string PartNumber { get; set; }

        [Required(ErrorMessage = "O part number é Obrigatório")]
        public string RefClient { get; set; }

        [Required(ErrorMessage = "O recebedor é Obrigatório")]
        public string Receiver { get; set; }

        public string Place { get; set; }

        public string DesiredPeriod { get; set; }

        [Required(ErrorMessage = "O primeiro decêndio é Obrigatório")]
        public string D1 { get; set; }

        [Required(ErrorMessage = "O segundo decêndio é Obrigatório")]
        public string D2 { get; set; }

        [Required(ErrorMessage = "O terceiro decêndio é Obrigatório")]
        public string D3 { get; set; }
        public bool Active { get; set; }
        public bool IntegridadeDados()
        {
            var linha = RefClient.Substring(3, 1);
            if (linha != Receiver.Substring(3, 1))
                return false;

            if (Place != null || Place != "")
            {
                if (linha != Receiver.Substring(3, 1))
                    return false;
            }

            if (linha != D1.Substring(3, 1))
                return false;

            if (linha != D2.Substring(3, 1))
                return false;

            if (linha != D3.Substring(3, 1))
                return false;

            return true;
        }

    }

}
