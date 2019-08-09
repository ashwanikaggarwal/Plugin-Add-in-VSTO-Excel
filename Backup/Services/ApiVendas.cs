using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Usiminas.PluginExcel.Dto;
using System.Collections.Generic;

namespace Usiminas.PluginExcel.Services
{
    public static class ApiVendas
    {
        static HttpClient client = new HttpClient();
        public static async Task<object> CreateProductAsync()
        {
            // Assemble the URI for the REST API method.
            string uri = "http://localhost:9100/api/cliente/cadastrados";

            HttpResponseMessage response;

            response = await client.GetAsync(uri);

            string contentString = await response.Content.ReadAsStringAsync();

            var texto = JToken.Parse(contentString).ToString();
            var modelObj = JsonConvert.DeserializeObject<List<IdDescriptionDto>>(texto);  //JavaScriptSerializer().Deserialize<UsuarioFiltersDto>(texto);
            return modelObj;
        }
    }
}
