using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Util
{
    /// <summary>
    /// Direciona a base da URL e o servidor de autenticação
    /// </summary>
    public static class EndPointsBase
    {
        //tomar cuidado para que o servidor de AOth sempre esteja apontado para o servidor certo.
        static public string UrlBaseAOthServer = ConfigurationManager.AppSettings["OAuthServerUrlHml"];
        static public string ServerUrl = ConfigurationManager.AppSettings["ServerUrlHML"];
    }
    /// <summary>
    /// Direciona os endpoints
    /// </summary>
    public static class EndPointsAPI
    {
        static public string User = ConfigurationManager.AppSettings["EndPointUser"];
        static public string Login = ConfigurationManager.AppSettings["ComplementUrlLogin"];
        static public string ClientGroup = ConfigurationManager.AppSettings["EndPointGrupoClient"];
        static public string ControleVersao = ConfigurationManager.AppSettings["EndPointVersion"];

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

        //partNumber
        static public string ClientListaPartNumber = ConfigurationManager.AppSettings["EndPointListaPartNumber"];

        //Peso Multiplo
        static public string ClientPesoMultiploPost = ConfigurationManager.AppSettings["EndPointPesoMultiplo"];

        //calendario aceite
        static public string ClientCalendarioAceitePost = ConfigurationManager.AppSettings["EndPointCalendarioAceite"];

        //emissao de pedido
        static public string ClientEmissaoPedido = ConfigurationManager.AppSettings["EndPointEmititPedido"];

        //log
        static public string ClientLogPost = ConfigurationManager.AppSettings["EndPointLog"];

    }
}
