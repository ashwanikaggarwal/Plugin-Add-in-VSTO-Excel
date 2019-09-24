using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Usiminas.PluginExcel.Entities;
using Usiminas.PluginExcel.Util;

namespace Usiminas.PluginExcel.Repository
{
    public class PluginRepository: Requestbase
    {
        public PluginRepository(Authentication authentication, string Url) : base(authentication, Url)
        {

        }
        public override async Task<T> Get<T>(Dictionary<string, string> Parametros) 
        {
            if (Url == null)
                throw new CustomExceptions("Favor Definir um EndPoint");

            try
            {
                //var retorn =  Activator.CreateInstance<T>();
                using (HttpClient client = new HttpClient())
                {
                    var builderUri = new UriBuilder(Url);
                    builderUri.Query = string.Join("&", Parametros.Select(x => x.Key + "=" + x.Value).ToArray());

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", String.Format("{0}", this.currentToken()));
                    HttpResponseMessage response = await client.GetAsync(builderUri.Uri).ConfigureAwait(false);
                    string contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (response.IsSuccessStatusCode == true)
                    {
                        var retorn = JsonConvert.DeserializeObject<T>(contentString);
                        return retorn;
                    }
                    else
                    {
                        throw new CustomExceptions(contentString);
                    }
                };
            }
            catch (CustomExceptions ex)
            {
                throw new CustomExceptions(ex.CustomMessagem());
            }
        }
    }
}
