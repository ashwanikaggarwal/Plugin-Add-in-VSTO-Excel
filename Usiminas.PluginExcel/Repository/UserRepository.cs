using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Usiminas.PluginExcel.Entities;
using Usiminas.PluginExcel.Util;

namespace Usiminas.PluginExcel.Repository
{
    public class UserRepository : Requestbase
    {
         public UserRepository(Authentication authentication, string Url) : base(authentication  , Url)
        {

        }
        public override  async Task<T> Get<T>() 
        {
            try
            {
                var retorn = Activator.CreateInstance<T>();
                using (HttpClient client = new HttpClient())
                {
                    string TokenURI = Url;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", String.Format("{0}", this.currentToken()));

                    HttpResponseMessage response;
                    response = await client.GetAsync(TokenURI);

                    string contentString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode == false)
                        throw new Exception(response.RequestMessage.ToString());

                    retorn = JsonConvert.DeserializeObject<T>(contentString);
                    
                    return retorn;
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
