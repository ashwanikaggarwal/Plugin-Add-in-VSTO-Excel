using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Usiminas.PluginExcel.Dto;
using Usiminas.PluginExcel.Entities;
using Usiminas.PluginExcel.Util;

namespace Usiminas.PluginExcel.Repository
{
    public class ClientRepository : Requestbase
    {
        public ClientRepository(Authentication authentication, string endPoint) : base(authentication, endPoint)
        {

        }
        public async Task<List<ClientePluginDto>> showClientOrGrupo()
        {
            var ret = await this.Get<List<ClientePluginDto>>();
            return ret;
        }
    }
}
