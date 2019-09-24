using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            var linha = Regex.Replace(RefClient, @"[^\d]", "");  
            if (linha != Regex.Replace(Receiver, @"[^\d]", ""))
                return false;

            if (Place != null && Place != "")
            {
                if (linha != Regex.Replace(Place, @"[^\d]", ""))
                    return false;
            }

            if (linha != Regex.Replace(D1, @"[^\d]", ""))
                return false;

            if (linha != Regex.Replace(D2, @"[^\d]", ""))
                return false;

            if (linha != Regex.Replace(D3, @"[^\d]", ""))
                return false;

            return true;
        }

    }

}
