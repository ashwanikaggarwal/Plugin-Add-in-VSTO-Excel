using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Util
{
    /// <summary>
    /// classe para padronizar o nome do cammpo dentro do grid, e seu respectivo cabeçalho
    /// 
    /// </summary>
    public static class TabMapColGrid
    {
        public static  KeyValuePair<string, string> Id = new KeyValuePair<string, string> ("Id", "Id");
        public static  KeyValuePair<string, string> PartNumber = new KeyValuePair<string, string> ("PartNumber", "PartNumber");
        public static  KeyValuePair<string, string> Recebedor = new KeyValuePair<string, string> ("Recebedor", "Recebedor");
        public static  KeyValuePair<string, string> RecebedorMapeado = new KeyValuePair<string, string> ("RecebedorMapeado", "Recebedor Mapeado");
        public static  KeyValuePair<string, string> RecebedorLista = new KeyValuePair<string, string> ("RecebedorLista", "Mapeamento Recebedor");
        public static  KeyValuePair<string, string> Beneficiador = new KeyValuePair<string, string> ("Beneficiador", "Beneficiador");
        public static  KeyValuePair<string, string> BeneficiadorMapeado = new KeyValuePair<string, string> ("BeneficiadorMapeado", "Beneficiador Mapeado");
        public static  KeyValuePair<string, string> BeneficiadorLista = new KeyValuePair<string, string> ("BeneficiadorLista", "Mapeamento Beneficiador");
        public static  KeyValuePair<string, string> Messagem = new KeyValuePair<string, string> ("Mensagem", "Mensagem");
        public static  KeyValuePair<string, string> D1 = new KeyValuePair<string, string> ("D1", "D1");
        public static  KeyValuePair<string, string> D2 = new KeyValuePair<string, string> ("D2", "D2");
        public static  KeyValuePair<string, string> D3 = new KeyValuePair<string, string> ("D3", "D3");
        public static KeyValuePair<string, string> period = new KeyValuePair<string, string> ("period", "Id");
    }


}
