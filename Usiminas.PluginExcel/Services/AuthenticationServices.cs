using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Usiminas.PluginExcel.Entities;

namespace Usiminas.PluginExcel.Services
{
    public class AuthenticationServices
    {
        public async Task<Authentication> ActionLogin(string username, string password)
        {
            try
            {
                string Url = ConfigurationManager.AppSettings["OAuthServerUrlDev"];
                string login = ConfigurationManager.AppSettings["ComplementUrlLogin"];
                var clientId = ConfigurationManager.AppSettings["AuthClientId"];
                var clientSecret = ConfigurationManager.AppSettings["AuthClientSecret"];
                var response = await LoginToken(username, password, clientId, clientSecret);
                
                Authentication auth = new Authentication(response);
                return auth;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }
        private async Task<string> LoginToken(string username, string password, string clientId, string clientSecret)
        {

            try
            {
                var values = new Dictionary<string, string>
                {
                   { "username", username },
                   { "password", password },
                   { "grant_type", "password" }
                };

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode(clientId + ":" + clientSecret));

                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync(ConfigurationManager.AppSettings["OAuthServerUrl"] + "/oauth/token", content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    dynamic results = JsonConvert.DeserializeObject<dynamic>(responseString);
                    throw new Exception(((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)results).Last).Last).Value as string);
                }
                return responseString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
