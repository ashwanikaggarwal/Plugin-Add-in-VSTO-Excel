using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Usiminas.PluginExcel.Dto;
using Usiminas.PluginExcel.Entities;

namespace Usiminas.PluginExcel.Util
{
    public class Requestbase
    {
        #region propertys
        public string Url { get; private set; }
        //readonly string endPoint = ConfigurationManager.AppSettings["EndPointUser"];

        private string UrlBase { get; set; }
        private string EndPoint { get; set; }
        private  Authentication Authentication { get; set; }
        public  string currentToken()
        {
            return Authentication.accessToken;
        }
        public string currentUserName()
        {
            return Authentication.userName;
        }
        #endregion

        /// <summary>
        /// Envia uma requisição sem parametros
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual async Task<T> Get<T>() where T : class
        {
            if (EndPoint == null)
                throw new Exception("Favor Definir um EndPoint");

            try
            {
                var retorn = Activator.CreateInstance<T>();
                using (HttpClient client = new HttpClient())
                {
                    string TokenURI = UrlBase + EndPoint;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", String.Format("{0}", Authentication.accessToken));
                    HttpResponseMessage response;
                    response = await client.GetAsync(TokenURI);

                    string contentString = await response.Content.ReadAsStringAsync();
                    retorn = JsonConvert.DeserializeObject<T>(contentString);
                    EndPoint = null;
                    return retorn;
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// requisição get com parametros
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Parametros"></param>
        /// <returns></returns>
        public virtual async Task<T> Get<T>(Dictionary<string, string> Parametros) where T : class
        {
            if (EndPoint == null)
                throw new Exception("Favor Definir um EndPoint");
            if (Parametros == null)
                throw new Exception("Favor Definir Os parametros");
            try
            {

                //var retorn =  Activator.CreateInstance<T>();
                using (HttpClient client = new HttpClient())
                {
                    var builderUri = new UriBuilder(UrlBase + EndPoint);
                    builderUri.Query = string.Join("&", Parametros.Select(x => x.Key + "=" + x.Value).ToArray());

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", String.Format("{0}", Authentication.accessToken));


                    HttpResponseMessage response = await client.GetAsync(builderUri.Uri);

                    string contentString = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode == true)
                    {

                       var retorn = JsonConvert.DeserializeObject<T>(contentString);
                        EndPoint = null;
                        return retorn;

                    }
                    else
                    {
                        throw new Exception(contentString);
                    }
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Requisição post com parametros
        /// </summary>
        /// <typeparam name="T que é igual a classe de retorno"></typeparam>
        /// <param name="Parametros"></param>
        /// <returns></returns>
        public virtual async Task<T> Post<T>(Dictionary<string, string> Parametros) where T : class
        {
            if (EndPoint == null)
                throw new Exception("Favor Definir um EndPoint");
            if (Parametros == null)
                throw new Exception("Favor Definir Os parametros");

            var retorn = Activator.CreateInstance<T>();
            using (HttpClient client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(Parametros);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", String.Format("{0}", Authentication.accessToken));

                HttpResponseMessage response = await client.PostAsync(UrlBase + EndPoint, content);

                string contentString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode == true)
                {

                    retorn = JsonConvert.DeserializeObject<T>(contentString);
                    EndPoint = null;
                }
                else
                {
                    throw new Exception(contentString);
                }
                return retorn;
            };
        }

        public virtual async Task<string> PostJson<T>(T Parametro)
        {
            if (EndPoint == null)
                throw new Exception("Favor Definir um EndPoint");

            using (HttpClient client = new HttpClient())
            {
                //var content = new FormUrlEncodedContent(Parametros);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", String.Format("{0}", Authentication.accessToken));
                string json = new JavaScriptSerializer().Serialize(Parametro);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                client.Timeout = TimeSpan.FromMinutes(10);
                HttpResponseMessage response = await client.PostAsync(UrlBase + EndPoint, content);

                string contentString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode == true)
                {
                    EndPoint = null;
                    return contentString;
                }
                else
                {
                    throw new Exception(contentString);
                }
                throw new HttpRequestException(contentString);
            };
        }
       
        public Requestbase(Authentication login, string endPoint)
        {
            UrlBase = EndPointsBase.ServerUrl;
            EndPoint = endPoint;
            Authentication = login;
            Url = UrlBase + EndPoint;
        }

    }
}
