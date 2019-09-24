using Microsoft.Office.Tools.Excel;
using System;
using System.Collections.Generic;
using Usiminas.PluginExcel.Dto;
using Excel = Microsoft.Office.Interop.Excel;
using Usiminas.PluginExcel.Entities;

namespace Usiminas.PluginExcel.Services
{
    public class InformationsPlan
    {

        Worksheet worksheet = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet);
        public List<string> GetPartNumberPlan(SalesDto salesdto)
        {
            var infoscells = ConvertRangeToArray(salesdto);
            List<InfoPlaDto> values = new List<InfoPlaDto>();
            int contar = 0;
            bool repet = true;
            //pega o valor dos partnumber para carregar os recebedores e beneficiadores
            List<string> partnumber = new List<string>();
            string Valor = null;
            while (repet == true)
            {
                foreach (var item in infoscells)
                {
                    Valor = GetValueCell(item.Item2 + contar, item.Item3);
                    switch (item.Item1)
                    {

                        case "RefClient":
                            if (Valor == "")
                            {
                                repet = false;
                                break;

                            }
                            if (partnumber.Contains(Valor) == false)
                                partnumber.Add(Valor);
                            break;
                    }
                }

                contar += 1;
            }
            return partnumber;
        }
        public List<InfoPlaDto> GetDataforAdress(SalesDto salesdto, DateTime dtPedido, List<PlaceCorresp> placeCorresp, List<ReceiverCorresp> receiverCorresp)
        {

            var infoscells = ConvertRangeToArray(salesdto);
            List<InfoPlaDto> values = new List<InfoPlaDto>();


            int contar = 0;
            bool repet = true;


            while (repet == true)
            {
                InfoPlaDto infoPlaDto = new InfoPlaDto();

                foreach (var item in infoscells)
                {
                    var Valor = GetValueCell(item.Item2 + contar, item.Item3);
                    switch (item.Item1)
                    {
                        case "Place":
                            infoPlaDto.Place = Valor;
                            break;
                        case "Receiver":
                            infoPlaDto.Receiver = Valor;
                            break;
                        case "RefClient":
                            infoPlaDto.RefClient = Valor;
                            break;
                        case "D1":
                            infoPlaDto.D1 = Valor;
                            break;
                        case "D2":
                            infoPlaDto.D2 = Valor;
                            break;
                        case "D3":
                            infoPlaDto.D3 = Valor;
                            break;
                        default:
                            break;
                    }
                    //sempre adiciona o valor da data do pedido
                    infoPlaDto.DesiredPeriod = dtPedido.ToString("MM/yyyy");
                }

                //entender se é para filtrar os dados ou apenas retornar o erro 

                //insere a lista de recebedores
                infoPlaDto.ReceiverCorresp.AddRange(receiverCorresp);
                if (infoPlaDto.D1 == "" && infoPlaDto.D2 == "" && infoPlaDto.D3 == "")
                {
                    contar += 1;
                    if (infoPlaDto.RefClient == "" && infoPlaDto.Receiver == "")
                    {
                        repet = false;
                    }
                }
                else
                {
                    //insere a lista de beneficiadores, caso exitir
                    if (infoPlaDto.Place != "" || infoPlaDto.Place != null)
                    {
                        infoPlaDto.PlaceCorresp.AddRange(placeCorresp);
                    }

                    if (infoPlaDto.RefClient != "" && infoPlaDto.Receiver != "")
                    {
                        values.Add(infoPlaDto);
                    }
                    else
                    {
                        repet = false;
                    }
                    contar += 1;
                    infoPlaDto.Id = contar;
                }

            }
            return values;
        }


        public string GetValueCell(int lin, int Col)
        {
            try
            {
                Excel.Range selection = worksheet.UsedRange; //Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.Cells) ;
                Excel.Range range = selection.Cells[lin, Col] as Excel.Range;
                string sValue = range.Value2.ToString();
                return sValue;
            }
            catch (Exception)
            {
                return "";
            }

        }

        public List<Tuple<string, int, int>> ConvertRangeToArray(SalesDto salesDto)
        {
            try
            {
                List<Tuple<string, int, int>> list = new List<Tuple<string, int, int>>();

                Excel.Range cell = worksheet.Range[salesDto.RefClient];
                Tuple<string, int, int> values = new Tuple<string, int, int>("RefClient", cell.Row, cell.Column);
                list.Add(values);

                cell = worksheet.Range[salesDto.Receiver];
                values = new Tuple<string, int, int>("Receiver", cell.Row, cell.Column);
                list.Add(values);

                if (salesDto.Place != null && salesDto.Place != "")
                {
                    cell = worksheet.Range[salesDto.Place];
                    values = new Tuple<string, int, int>("Place", cell.Row, cell.Column);
                    list.Add(values);
                }

                cell = worksheet.Range[salesDto.D1];
                values = new Tuple<string, int, int>("D1", cell.Row, cell.Column);
                list.Add(values);

                cell = worksheet.Range[salesDto.D2];
                values = new Tuple<string, int, int>("D2", cell.Row, cell.Column);
                list.Add(values);

                cell = worksheet.Range[salesDto.D3];
                values = new Tuple<string, int, int>("D3", cell.Row, cell.Column);
                list.Add(values);

                return list;
            }
            catch (Exception ex)
            { 
                throw new Exception("Erro ao mapear Planilha: " + ex.Message);
            }
        }

    }
}
