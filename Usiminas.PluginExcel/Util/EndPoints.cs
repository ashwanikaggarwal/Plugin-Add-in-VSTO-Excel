using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Util
{
    public static class EndPointsBase
    {
        static public string UrlBaseAOthServer = ConfigurationManager.AppSettings["OAuthServerUrl"];
        static public string ServerUrlDev = ConfigurationManager.AppSettings["ServerUrlDev"];
    }
    public static class EndPointsAPI
    {
        static public string User = ConfigurationManager.AppSettings["EndPointUser"];
        static public string Login = ConfigurationManager.AppSettings["ComplementUrlLogin"];
        static public string ClientGroup = ConfigurationManager.AppSettings["EndPointGrupoClient"];

        //tabela
        static public string ClientFieldsGet = ConfigurationManager.AppSettings["EndPointPluginGet"];
        static public string ClientFieldsPost = ConfigurationManager.AppSettings["EndPointPluginPost"];

        //beneficiador
        static public string ClientReceiverEmissao = ConfigurationManager.AppSettings["EndPointRecebedorPost"];
        static public string ClientReceiverDeParaGet = ConfigurationManager.AppSettings["EndPointRecebedorDePara"];
        static public string ClientReceiverDeParaPost = ConfigurationManager.AppSettings["EndPointRecebedorDePara"];
        static public string ClientReceiverDeParaDelete = ConfigurationManager.AppSettings["EndPointRecebedorDePara"];

        //recebedor 
        static public string ClientPlaceGetEmissao = ConfigurationManager.AppSettings["EndPointBeneficiadorPost"];
        static public string ClientPlaceDeParaGet = ConfigurationManager.AppSettings["EndPointBeneficiadorDePara"];
        static public string ClientPlaceDeParaPost = ConfigurationManager.AppSettings["EndPointBeneficiadorDePara"];
        static public string ClientPlaceDeParaDelete = ConfigurationManager.AppSettings["EndPointBeneficiadorDePara"];

    }
}
