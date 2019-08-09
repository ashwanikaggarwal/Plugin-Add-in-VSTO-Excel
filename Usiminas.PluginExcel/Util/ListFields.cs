using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Usiminas.PluginExcel.Dto;

namespace Usiminas.PluginExcel.Util
{
    public static class ListFields
    {
        /// <summary>
        /// lista a ordenação das colunas do grid
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> OrderNameClassSalesDto()
        {
            Dictionary<string, string> SetListNameClass = new Dictionary<string, string>();
            InfoPlaDto sale = new InfoPlaDto();
            int indice = 0;
            foreach (var item in sale.GetType().GetProperties().Select(f => f.Name).ToList())
            {
                switch (item)
                {

                    case "RefClient":
                        SetListNameClass.Add(item, "0");
                        break;
                    case "Receiver":
                        SetListNameClass.Add(item, "1");
                        break;
                    case "ReceiverCorresp":
                        SetListNameClass.Add(item, "2");
                        break;
                    case "Place":
                        SetListNameClass.Add(item, "3");
                        break;
                    case "PlaceCorresp":
                        SetListNameClass.Add(item, "4");
                        break;
                    case "Mensagem":
                        SetListNameClass.Add(item, "5");
                        break;
                    case "D1":
                        SetListNameClass.Add(item, "6");
                        break;
                    case "D2":
                        SetListNameClass.Add(item, "7");
                        break;
                    case "D3":
                        SetListNameClass.Add(item, "8");
                        break;
                    case "partNumberCorresp":
                        SetListNameClass.Add(item, "9");
                        break;
                    case "DesiredPeriod":
                        SetListNameClass.Add(item, "10");
                        break;
                    case "Validado":
                        SetListNameClass.Add(item, "11");
                        break;
                }
            }
            //Mensagem
            return SetListNameClass;
        }

        /// <summary>
        /// lista o de para de nomes que vao aparecer na coluna e do grid
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> ListNameClassSalesDto()
        {
            Dictionary<string, string> SetListNameClass = new Dictionary<string, string>();
            InfoPlaDto sale = new InfoPlaDto();
            int indice = 0;
            foreach (var item in sale.GetType().GetProperties().Select(f => f.Name).ToList())
            {
                switch (item)
                {

                    case "RefClient":
                        SetListNameClass.Add(item, "Part Number");
                        break;
                    case "Receiver":
                        SetListNameClass.Add(item, "Recebedor");
                        break;
                    case "ReceiverCorresp":
                        SetListNameClass.Add(item, "Recebedor Map");
                        break;
                    case "Place":
                        SetListNameClass.Add(item, "Beneficiador");
                        break;
                    case "PlaceCorresp":
                        SetListNameClass.Add(item, "Beneficiador Map");
                        break;
                    case "Mensagem":
                        SetListNameClass.Add(item, "Mensagem");
                        break;
                    case "D1":
                        SetListNameClass.Add(item, "D1");
                        break;
                    case "D2":
                        SetListNameClass.Add(item, "D2");
                        break;
                    case "D3":
                        SetListNameClass.Add(item, "D3");
                        break;
                    case "DesiredPeriod":
                        SetListNameClass.Add(item, "Periodo");
                        break;
                    case "Validado":
                        SetListNameClass.Add(item, "Validado");
                        break;
                }
            }
            //Mensagem
            return SetListNameClass;
        }

        /// <summary>
        /// lista os campos de uma classe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<string, string> ListGenerycClass(EmissaoPedidosDto emissaoPedidosDto)
        {
            Dictionary<string, string> SetListNameClass = new Dictionary<string, string>();


            foreach (var info in emissaoPedidosDto.GetType().GetProperties())
            {
                if (emissaoPedidosDto.GetType().GetProperty(info.Name).GetValue(emissaoPedidosDto, null) != null)
                {
                    if (emissaoPedidosDto.GetType().GetProperty(info.Name).GetValue(emissaoPedidosDto, null).ToString() != "System.Collections.Generic.List`1[System.String]")
                    {
                        SetListNameClass.Add(info.Name, emissaoPedidosDto.GetType().GetProperty(info.Name).GetValue(emissaoPedidosDto, null).ToString());
                    }
                    else
                    {
                        if (info.Name == "PartNumbers")
                        {
                            string textoAgrup = "'";
                            int contstr = 1;
                            foreach (var item in emissaoPedidosDto.PartNumbers)
                            {
                                if (emissaoPedidosDto.PartNumbers.Count > contstr)
                                {
                                    textoAgrup += item + "', '";
                                }
                                else
                                {
                                    textoAgrup += item + "'";
                                }
                                contstr += 1;
                            }
                            SetListNameClass.Add(info.Name, textoAgrup);
                        }
                    }
                }
                // classinstancia.GetType().GetProperty("NumeroOVItems").GetValue(classinstancia, null);
                else
                {
                    SetListNameClass.Add(info.Name, null);
                }
            }
            return SetListNameClass;
        }
    }
    public static class ListFieldsSalesDto
    {
        public static Dictionary<string, string> ListNameClassSalesDto(SalesDto saleDto, string userName, string client)
        {
            Dictionary<string, string> SetListNameClass = new Dictionary<string, string>();
            SetListNameClass.Add("CD_Cliente", client);
            SetListNameClass.Add("UserName", userName);
            PropertyInfo[] infos = saleDto.GetType().GetProperties();
            foreach (PropertyInfo info in infos)
            {
                switch (info.Name)
                {
                    case "RefClient":
                        SetListNameClass.Add(info.Name, info.GetValue(saleDto, null).ToString());
                        break;
                    case "Receiver":
                        SetListNameClass.Add(info.Name, info.GetValue(saleDto, null).ToString());
                        break;
                    case "Place":
                        if (saleDto.Place == null)
                        {
                            break;
                        }
                        SetListNameClass.Add(info.Name, info.GetValue(saleDto, null).ToString());
                        break;
                    //case "DesiredPeriod":
                    //    SetListNameClass.Add(info.Name, info.GetValue(saleDto, null).ToString());
                    //    break;
                    case "D1":
                        SetListNameClass.Add(info.Name, info.GetValue(saleDto, null).ToString());
                        break;
                    case "D2":
                        SetListNameClass.Add(info.Name, info.GetValue(saleDto, null).ToString());
                        break;
                    case "D3":
                        SetListNameClass.Add(info.Name, info.GetValue(saleDto, null).ToString());
                        break;
                }
            }

            return SetListNameClass;
        }
    }

}
