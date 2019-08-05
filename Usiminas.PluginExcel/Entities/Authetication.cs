using System;
using System.Web.Script.Serialization;

namespace Usiminas.PluginExcel.Entities
{
    public class Authentication
    {
        public string Token { get; private set; }
        public string accessToken { get; private set; }
        public string tokenType { get; private set; }
        public string expiresIn { get; private set; }
        public string refreshToken { get; private set; }
        public string clientID { get; private set; }
        public string userName { get; private set; }
        public string issued { get; private set; }
        public string expires { get; private set; }
        public Authentication()
        {

        }
        public Authentication( string authentication)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            dynamic results = js.Deserialize<dynamic>(authentication);
            Token = authentication;
            this.accessToken = results["access_token"];
            this.refreshToken = results["refresh_token"];
            this.clientID = results["as:client_id"];
            this.expires = results[".expires"];
            this.expiresIn = Convert.ToString(results["expires_in"]);
            this.issued = results[".issued"];
            this.tokenType = results["token_type"];
            this.userName = results["userName"];

        }
    }
}
