using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Usiminas.PluginExcel.Dto;
using Usiminas.PluginExcel.Entities;
using Usiminas.PluginExcel.Repository;
using Usiminas.PluginExcel.Util;

namespace Usiminas.PluginExcel.Services
{
    public static class LogServices
    {
        public static async void LogEmissaoClass<T>(Authentication authentication, string campo, string msg, T Informacoesenvio)
        {
            try
            {
                //return;
                LogPluginDto Log = new LogPluginDto();
                Log.ClassToJasonCampo(Informacoesenvio);
                //Log.ClassToJasonCampo("teste");
                Log.emissor = authentication.CurrentClient;
                Log.jsonCampo = campo;
                Log.msg = msg;

                Log.nomePc = WindowsIdentity.GetCurrent().Name.ToString();
                Log.nomeUser = "USER PC:" + WindowsIdentity.GetCurrent().User.ToString() + " | USER PLUGIN: " + authentication.userName;
                PluginRepository pluginRepository = new PluginRepository(authentication, EndPointsAPI.ClientLogPost);
                var list = await pluginRepository.PostJson(Log);
            }
            catch (Exception ex)
            {


            }
        }
        public static async void LogEmissaoSimples(Authentication authentication, string campo, string msg)
        {
            //return;
            try
            {
                LogPluginDto Log = new LogPluginDto();
                //Log.ClassToJasonCampo(Informacoesenvio);
                Log.emissor = authentication.CurrentClient;
                Log.jsonCampo = campo;
                Log.msg = msg;

                Log.nomePc = WindowsIdentity.GetCurrent().Name.ToString();
                Log.nomeUser = "USER PC:" + WindowsIdentity.GetCurrent().User.ToString() + " | USER PLUGIN: " + authentication.userName;
                PluginRepository pluginRepository = new PluginRepository(authentication, EndPointsAPI.ClientLogPost);
                var list = await pluginRepository.PostJson(Log);
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message, ex);
            }
        }
    }
}
