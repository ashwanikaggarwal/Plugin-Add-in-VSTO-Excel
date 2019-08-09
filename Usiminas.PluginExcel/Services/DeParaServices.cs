using System.Collections.Generic;
using System.Linq;
using Usiminas.PluginExcel.Dto;
using Usiminas.PluginExcel.Entities;

namespace Usiminas.PluginExcel.Services
{
    static class DeParaServices
    {
        public static List<DeParaBeneficiadorDto> NovosDeParaBeneficiador(List<DeParaBeneficiadorDto> deParaBeneficiador, List<InfoPlaDto> VerificarDepara, string codCliente, string Usuario)
        {
            if (deParaBeneficiador.Count == 0)
                return null;

            List<DeParaBeneficiadorDto> deParaBeneficiadorDtos = new List<DeParaBeneficiadorDto>();
            foreach (var infoPlaDto in VerificarDepara)
            {
                if (deParaBeneficiador.Where(p => p.CodBeneficiadorCliente.Contains(infoPlaDto.Place) && p.CodBeneficiadorUsiminas.Contains(infoPlaDto.PlacerMapped.Split('-')[0])).Any() == false)
                {
                    if (deParaBeneficiadorDtos.Where(p => p.CodBeneficiadorCliente.Contains(infoPlaDto.Receiver) && p.CodBeneficiadorUsiminas.Contains(infoPlaDto.ReceiverMapped.Split('-')[0])).Any() == false)
                    {
                        deParaBeneficiadorDtos.Add(new DeParaBeneficiadorDto
                        {
                            CodBeneficiadorCliente = infoPlaDto.Place,
                            CodBeneficiadorUsiminas = infoPlaDto.PlacerMapped.Split('-')[0],
                            DesBeneficiadorUsiminas = infoPlaDto.PlacerMapped,
                            CodCliente = codCliente,
                            Ativo = true,
                            UserName = Usuario
                        });
                    }
                }
            }
            return deParaBeneficiadorDtos;
        }
        public static List<DeParaRecebedorDto> NovosDeParaRecebedor(List<DeParaRecebedorDto> deParaRecebedor, List<InfoPlaDto> VerificarDepara, string codCliente, string Usuario)
        {
            List<DeParaRecebedorDto> deParaRecebedorDtos = new List<DeParaRecebedorDto>();
            foreach (var infoPlaDto in VerificarDepara)
            {
                if (deParaRecebedor.Where(p => p.CodRecebedorCliente.Contains(infoPlaDto.Receiver) && p.CodRecebedorUsiminas.Contains(infoPlaDto.ReceiverMapped.Split('-')[0])).Any() == false )
                {
                    if (deParaRecebedorDtos.Where(p => p.CodRecebedorCliente.Contains(infoPlaDto.Receiver) && p.CodRecebedorUsiminas.Contains(infoPlaDto.ReceiverMapped.Split('-')[0])).Any() == false)
                    {
                        deParaRecebedorDtos.Add(new DeParaRecebedorDto
                        {
                            CodRecebedorCliente = infoPlaDto.Receiver,
                            CodRecebedorUsiminas = infoPlaDto.ReceiverMapped.Split('-')[0],
                            DesRecebedorUsiminas = infoPlaDto.ReceiverMapped,
                            CodCliente = codCliente,
                            Ativo = true,
                            UserName = Usuario
                        });
                    }

                }
            }
            return deParaRecebedorDtos;
        }
    }
}
