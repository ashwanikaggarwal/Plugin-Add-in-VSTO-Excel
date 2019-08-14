using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usiminas.PluginExcel.Dto;
using Usiminas.PluginExcel.Entities;
using Usiminas.PluginExcel.Repository;
using Usiminas.PluginExcel.Util;

namespace Usiminas.PluginExcel.Services
{
    public class PluginService
    {
        private Authentication _authentication { get; set; }
        public PluginService(Authentication authentication)
        {
            _authentication = authentication;
        }
        public async Task<SalesDto> GetInformationFieldsPlan(string codCliente)
        {
            PluginRepository pluginRepository = new PluginRepository(_authentication, EndPointsAPI.ClientFieldsGet);
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            keyValues.Add("idUser", _authentication.userName);
            keyValues.Add("idclient", codCliente);
            try
            {
                var campos = await pluginRepository.Get<List<SalesDto>>(keyValues).ConfigureAwait(false);

                return campos.Where(p => p.Active == true).FirstOrDefault();
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("não existem dados"))
                {
                    return null;
                }
                throw new Exception(ex.Message);
            }

        }
        public async Task<bool> SaveInfoPlan(SalesDto salesDto)
        {
            try
            {
                PluginRepository pluginRepository = new PluginRepository(_authentication, EndPointsAPI.ClientFieldsGet);
                var campos = await pluginRepository.Post<SalesDto>(ListFieldsSalesDto.ListNameClassSalesDto(salesDto, salesDto.UserName, salesDto.CD_Cliente));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// retorna a lista de recebedor de acordo com o cliente e partnumber
        /// </summary>
        /// <param name="PartNumbers"></param>
        /// <param name="CodCliente"></param>
        /// <returns></returns>
        public async Task<List<ReceiverCorresp>> ReceiverCorrespsPostAsync(string[] PartNumbers, string CodCliente)
        {
            EmissaoPedidosDto emissaoPedidosDto = new EmissaoPedidosDto();
            emissaoPedidosDto.TipoBusca = "P";
            emissaoPedidosDto.PartNumbers = PartNumbers.ToList();
            emissaoPedidosDto.CodigoCliente = CodCliente;

            PluginRepository pluginRepository = new PluginRepository(_authentication, EndPointsAPI.ClientReceiverEmissao);
            //string result = JsonConvert.SerializeObject(emissaoPedidosDto, Formatting.None);

            var listReciver = await pluginRepository.PostJson(emissaoPedidosDto);
            return Functions.ConvertJsonToListIdDescription<List<ReceiverCorresp>>(listReciver);
        }
        /// <summary>
        /// retorna a lista de beneficiador de acordo com o cliente e partnumber
        /// </summary>
        /// <param name="PartNumbers"></param>
        /// <param name="CodCliente"></param>
        /// <returns></returns>
        public async Task<List<PlaceCorresp>> PlaceCorrespsPostAsync(string[] PartNumbers, string CodCliente)
        {

            EmissaoPedidosDto emissaoPedidosDto = new EmissaoPedidosDto();
            emissaoPedidosDto.TipoBusca = "P";
            emissaoPedidosDto.PartNumbers = PartNumbers.ToList();
            emissaoPedidosDto.CodigoCliente = CodCliente;

            PluginRepository pluginRepository = new PluginRepository(_authentication, EndPointsAPI.ClientPlaceGetEmissao);

            string result = JsonConvert.SerializeObject(emissaoPedidosDto, Formatting.None);

            var listPlace = await pluginRepository.PostJson(emissaoPedidosDto);
            return Functions.ConvertJsonToListIdDescription<List<PlaceCorresp>>(listPlace);

        }
        public async Task<List<DeParaRecebedorDto>> RecebedorDeParaGetAsync()
        {

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("idclient", _authentication.CurrentClient);
            parameters.Add("UserName", _authentication.userName);
            PluginRepository pluginRepository = new PluginRepository(_authentication, EndPointsAPI.ClientReceiverDeParaGet);
            var campos = await pluginRepository.Get<List<DeParaRecebedorDto>>(parameters);

            return campos;
        }
        public async Task<List<DeParaBeneficiadorDto>> BeneficiadorDeParaGetAsync()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("idclient", _authentication.CurrentClient);
            parameters.Add("UserName", _authentication.userName);
            PluginRepository pluginRepository = new PluginRepository(_authentication, EndPointsAPI.ClientPlaceDeParaGet);
            var campos = await pluginRepository.Get<List<DeParaBeneficiadorDto>>(parameters);
            return campos;
        }
        public async void RecebedorDeParaPostAsync(List<DeParaRecebedorDto> deParaRecebedor)
        {
            PluginRepository pluginRepository = new PluginRepository(_authentication, EndPointsAPI.ClientReceiverDeParaPost);
            var retorno = await pluginRepository.PostJson(deParaRecebedor);
        }
        public async void BeneficiadorDeParaPostAsync(List<DeParaBeneficiadorDto> deParaBeneficiador)
        {
            PluginRepository pluginRepository = new PluginRepository(_authentication, EndPointsAPI.ClientPlaceDeParaPost);
            var retorno = await pluginRepository.PostJson(deParaBeneficiador);
        }
        public async Task<List<DetalheItemDto>> DetalhamentoDePartNumber(string[] PartNumbers, string CodCliente)
        {
            EmissaoPedidosDto emissaoPedidosDto = new EmissaoPedidosDto();
            emissaoPedidosDto.TipoBusca = "P";
            emissaoPedidosDto.PartNumbers = PartNumbers.ToList();
            emissaoPedidosDto.CodigoCliente = CodCliente;

            PluginRepository pluginRepository = new PluginRepository(_authentication, EndPointsAPI.ClientListaPartNumber);
            //string result = JsonConvert.SerializeObject(emissaoPedidosDto, Formatting.None);

            var list = await pluginRepository.PostJson(emissaoPedidosDto);
            return Functions.ConvertJsonToListIdDescription<List<DetalheItemDto>>(list);
        }
        public async Task<List<MinimoMultiploDto>> PesoMultiploPartNumberAsync(ValidaPesoMultiPartNumberDto validaPesoMultiPartNumberDto)
        {
            PluginRepository pluginRepository = new PluginRepository(_authentication, EndPointsAPI.ClientPesoMultiploPost);

            var list = await pluginRepository.PostJson(validaPesoMultiPartNumberDto);
            return Functions.ConvertJsonToListIdDescription<List<MinimoMultiploDto>>(list);
        }
        public async Task<List<DadosDataAceiteDto>> CalendarioAceiteAsync(List<CalendarioAceiteFilterDto> calendarioAceiteFilterDto)
        {
            PluginRepository pluginRepository = new PluginRepository(_authentication, EndPointsAPI.ClientCalendarioAceitePost);

            var list = await pluginRepository.PostJson(calendarioAceiteFilterDto);
            return Functions.ConvertJsonToListIdDescription<List<DadosDataAceiteDto>>(list);
        }
    }
}
