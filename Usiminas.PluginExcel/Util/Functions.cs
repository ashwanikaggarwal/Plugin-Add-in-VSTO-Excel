using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Usiminas.PluginExcel.Dto;
using Usiminas.PluginExcel.Entities;

namespace Usiminas.PluginExcel.Util
{
    public static class Functions
    {

        public static T ConvertJsonToListIdDescription<T>(string StringJson) 
        {
            var clasResult = Activator.CreateInstance<T>();
            clasResult = JsonConvert.DeserializeObject<T>(StringJson);
            return clasResult;
        }
        public static string GetValueintoListBeneficiador(this List<DeParaBeneficiadorDto> deParaBeneficiadorDto, List<PlaceCorresp> PlaceCorresp, string texto)
        {
            string preencher = deParaBeneficiadorDto.Where(p => p.CodBeneficiadorCliente.Contains(texto) && p.Ativo == true).Select(p => p.DesBeneficiadorUsiminas).FirstOrDefault();
            if (preencher == null)
                return null;
            var valorretorno = PlaceCorresp.Where(p => p.Description.Contains(preencher) == true).FirstOrDefault();
            
            return valorretorno.Description;
        }
        public static string GetValueintoListRecebedor(this List<DeParaRecebedorDto> deParaRecebedorDto, List<ReceiverCorresp> ReceiverCorresp, string texto)
        {
            string preencher = deParaRecebedorDto.Where(p => p.CodRecebedorCliente.Contains(texto) && p.Ativo == true).Select(p => p.DesRecebedorUsiminas).FirstOrDefault();
            if (preencher == null)
                return null;
            var valorretorno = ReceiverCorresp.Where(p => p.Description.Contains(preencher) == true).FirstOrDefault();

            return valorretorno.Description;
        }
        public static string MyDictionaryToJson(Dictionary<string, string> dict)
        {
            var entries = dict.Select(d => string.Format("\"{0}\": [{1}]", d.Key, string.Join(",", d.Value)));
            return "{" + string.Join(",", entries) + "}";
        }

    }
}
