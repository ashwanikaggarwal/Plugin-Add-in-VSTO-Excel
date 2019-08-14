using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using Usiminas.PluginExcel.Services;
using Usiminas.PluginExcel.Entities;
using Usiminas.PluginExcel.Repository;
using Usiminas.PluginExcel.Dto;
using Usiminas.PluginExcel.Util;
using System.Linq;
using System.Collections.Generic;

namespace Usiminas.PluginExcel.Ux
{
    public partial class F_Pedido : Form
    {
        #region Variáveis
        Excel.Worksheet worksheet = Globals.ThisAddIn.GetActiveWorkSheet();
        Excel.Range Target = Globals.ThisAddIn.Worksheet_SelectionChange();
        Authentication auth = new Authentication();
        List<DeParaBeneficiadorDto> deParaBeneficiadorDto = new List<DeParaBeneficiadorDto>();
        List<DeParaRecebedorDto> deParaRecebedorDto = new List<DeParaRecebedorDto>();
        SalesDto salesdto = new SalesDto();
        List<ClientePluginDto> clientes;
        List<InfoPlaDto> infoPlaDtos;

        List<DetalheItemDto> DetalheItemDtos;
        List<CalendarioAceiteFilterDto> calendarioAceiteFilterDto;

        int FieldEdit; // variavel que define qual é o botão
        #endregion
        private async void mocardadosFormulario()
        {

            InformationsPlan informationsPlan = new InformationsPlan();

            if (auth.accessToken == null)
            {
                Login login = new Login();
                AuthenticationServices authentication = new AuthenticationServices();
                OvTxLogin.Text = "igorteste";
                OvTxSenha.Text = "Simo12es?";

                auth = await authentication.ActionLogin(OvTxLogin.Text, OvTxSenha.Text);
            }
            //

            List<PlaceCorresp> placeCorresp = new List<PlaceCorresp>();
            placeCorresp.Add(new PlaceCorresp { Id = "0000011683", Description = "7924-MASAYOSHI ( AVE PINHEIRO 1081 )" });
            placeCorresp.Add(new PlaceCorresp { Id = "0000007924", Description = "11683-FITAMETAL ( R JOAO ROBERTO 170A, 7Y )" });
            placeCorresp.Add(new PlaceCorresp { Id = "0000012749", Description = "12749-CENTRASA ( RUA DEZ 66, 3W )" });

            List<ReceiverCorresp> receiverCorresps = new List<ReceiverCorresp>();
            receiverCorresps.Add(new ReceiverCorresp { Id = "0000007711", Description = "7711-AETHRA ( AVE CENTAURO 234, 5J )" });
            receiverCorresps.Add(new ReceiverCorresp { Id = "0000012536", Description = "12536-AETHRA ( RUA CAROLINA 51 )" });

            #region moc Dto Inforplan
            deParaBeneficiadorDto = new List<DeParaBeneficiadorDto>();
            deParaRecebedorDto = new List<DeParaRecebedorDto>();
            ///SalesDto salesdtoMoc = new SalesDto();
            List<InfoPlaDto> infoPlaDtosMoc = new List<InfoPlaDto>();
            var escolha = 1;

            infoPlaDtosMoc.Add(new InfoPlaDto
            {
                Id = 1,
                Active = true,
                RefClient = "01.110.1407C",
                Receiver = "CENTAURO",
                ReceiverCorresp = receiverCorresps,
                Place = "A.ALIANÇA",
                PlaceCorresp = placeCorresp,
                DesiredPeriod = "08/2019",
                D1 = "0",
                D2 = "25",
                D3 = "0"
                ,
                PlacerMapped = placeCorresp.Last().Description,
                ReceiverMapped = receiverCorresps.First().Description
            });
            infoPlaDtosMoc.Add(new InfoPlaDto
            {
                Id = 2,
                Active = true,
                RefClient = "01.210.1820C",
                Receiver = "CENTAURO",
                ReceiverCorresp = receiverCorresps,
                Place = "A.ALIANÇA",
                PlaceCorresp = placeCorresp,
                DesiredPeriod = "08/2019",
                D1 = "0",
                D2 = "25",
                D3 = "0"
                ,
                PlacerMapped = placeCorresp.Last().Description,
                ReceiverMapped = receiverCorresps.First().Description
            });
            infoPlaDtosMoc.Add(new InfoPlaDto
            {
                Id = 3,
                Active = true,
                RefClient = "01.113.1381C",
                Receiver = "CENTAURO",
                ReceiverCorresp = receiverCorresps,
                Place = "A.ALIANÇA",
                PlaceCorresp = placeCorresp,
                DesiredPeriod = "08/2019",
                D1 = "25",
                D2 = "0",
                D3 = "0"
                ,
                PlacerMapped = placeCorresp.First().Description,
                ReceiverMapped = receiverCorresps.Last().Description
            });
            infoPlaDtosMoc.Add(new InfoPlaDto
            {
                Id = 4,
                Active = true,
                RefClient = "01.230.4012C",
                Receiver = "CENTAURO",
                ReceiverCorresp = receiverCorresps,
                Place = "FITAMETAL",
                PlaceCorresp = placeCorresp,
                DesiredPeriod = "08/2019",
                D1 = "0",
                D2 = "28",
                D3 = "28"
                ,
                PlacerMapped = placeCorresp.First().Description,
                ReceiverMapped = receiverCorresps.Last().Description
            });
            infoPlaDtosMoc.Add(new InfoPlaDto
            {
                Id = 5,
                Active = true,
                RefClient = "01.230.4018C",
                Receiver = "CENTAURO",
                ReceiverCorresp = receiverCorresps,
                Place = "FITAMETAL",
                PlaceCorresp = placeCorresp,
                DesiredPeriod = "08/2019",
                D1 = "56",
                D2 = "56",
                D3 = "28"
                ,
                PlacerMapped = placeCorresp.First().Description,
                ReceiverMapped = receiverCorresps.First().Description
            });

            #endregion

            infoPlaDtos = infoPlaDtosMoc;
            //infoPlaDtos = null;
            PopulateGridMap(ref infoPlaDtos);
            DelAddColumReciver delAddColumReciver = new DelAddColumReciver(AddColumReciver);
            delAddColumReciver.Invoke(infoPlaDtos.First().ReceiverCorresp);

            DelAddColumPlace delAddColumPlace = new DelAddColumPlace(AddColumPlace);
            delAddColumPlace.Invoke(infoPlaDtos.First().PlaceCorresp);
            //var ret = DeParaServices.NovosDeParaBeneficiador(deParaBeneficiadorDto, infoPlaDtos, "0000007711", "UZ22657");
            var arrayref = infoPlaDtosMoc.Select(p => p.RefClient).ToList();
            PluginService pluginServices = new PluginService(auth);

            //pega a lista de recebedor e beneficiador cadastrado
            SalesDto dto = new SalesDto { CD_Cliente = "0000000155", RefClient = "B7", D1 = "ag7", D2 = "ah7", D3 = "ai7", Receiver = "aq7" };
            var PartNumArr = informationsPlan.GetPartNumberPlan(dto);
            var ReceiverCorrespsForPartNumber = pluginServices.ReceiverCorrespsPostAsync(PartNumArr.ToArray(), salesdto.CD_Cliente).GetAwaiter().GetResult();
            var placeCorrespForPartNumber = await pluginServices.PlaceCorrespsPostAsync(PartNumArr.ToArray(), salesdto.CD_Cliente);
            var validaPesoMultiPartNumberDto = new ValidaPesoMultiPartNumberDto();
            validaPesoMultiPartNumberDto.CdCliente = "0000007711";
            validaPesoMultiPartNumberDto.PartNumbers = PartNumArr;
            validaPesoMultiPartNumberDto.Recebedores = ReceiverCorrespsForPartNumber.Select(p => p.Id).ToList();

            var itemDtos = pluginServices.PesoMultiploPartNumberAsync(validaPesoMultiPartNumberDto);
            //DetalheItemDtos = await pluginServices.DetalhamentoDePartNumber(PartNumArr.ToArray(), salesdto.CD_Cliente);

            DetalheItemDtos = await pluginServices.DetalhamentoDePartNumber(infoPlaDtosMoc.Select(p => p.RefClient).ToArray(), "0000000155");

            SelectContext("OvAbaPedido");
        }

        #region //////// Inicialização e transição de form
        public F_Pedido()
        {

            InitializeComponent();
            InitialStageSelectfields();
        }
        private void F_Pedido_Load(object sender, EventArgs e)
        {
            SelectContext("OvAbaConfiguracao");
            InitialStageSelectfields();
            ObBtnChosenClient.Visible = false;
            ObCbClienteGrupo.Visible = false;
            OvLbClienteGrupo.Visible = false;
            //mocardadosFormulario();
            //PopulateItens();
        }
        private void FPTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                Target = Globals.ThisAddIn.Worksheet_SelectionChange();
                switch (FieldEdit)
                {
                    case 1:
                        this.OvTxSelecaoRefCliente.Text = Target.Address;
                        break;
                    case 2:
                        this.OvTxSelecaoRecebedor.Text = Target.Address;
                        break;
                    case 3:
                        this.OvTxSelecaoLocalEntrega.Text = Target.Address;
                        break;
                    case 4:
                        this.OvTxSelecaoPeriodo.Text = Target.Address;
                        break;
                    case 5:
                        this.OvTxSelecaoTonelagemD1.Text = Target.Address;
                        break;
                    case 6:
                        this.OvTxSelecaoTonelagemD2.Text = Target.Address;
                        break;
                    case 7:
                        this.OvTxSelecaoTonelagemD3.Text = Target.Address;
                        break;
                    default:
                        FPTimer.Stop();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void OvBtnEnviar_Click(object sender, EventArgs e)
        {
            var resultados = DataAnnotation.ValidateEntity<SalesDto>(salesdto);
            if (resultados.HasError == true)
            {
                MessageBox.Show(resultados.ListaErro);
                return;
            }

            InformationsPlan informationsPlan = new InformationsPlan();

            //pega a lista de recebedor e beneficiador cadastrado
            var PartNumArr = informationsPlan.GetPartNumberPlan(salesdto);
            PluginService pluginServices = new PluginService(auth);
            var ReceiverCorrespsForPartNumber = pluginServices.ReceiverCorrespsPostAsync(PartNumArr.ToArray(), salesdto.CD_Cliente).GetAwaiter().GetResult();
            var placeCorrespForPartNumber = await pluginServices.PlaceCorrespsPostAsync(PartNumArr.ToArray(), salesdto.CD_Cliente);

            //pega o dstalhamento de acordo com os partnumbers
            DetalheItemDtos = await pluginServices.DetalhamentoDePartNumber(PartNumArr.ToArray(), salesdto.CD_Cliente);
            //carrega o minimo multiplo
            var validaPesoMultiPartNumberDto = new ValidaPesoMultiPartNumberDto();
            validaPesoMultiPartNumberDto.PartNumbers = PartNumArr;
            validaPesoMultiPartNumberDto.Recebedores = ReceiverCorrespsForPartNumber.Select(p => p.Id).ToList();

            List<MinimoMultiploDto> MinimoMultiplo = await pluginServices.PesoMultiploPartNumberAsync(validaPesoMultiPartNumberDto);

            calendarioAceiteFilterDto = new List<CalendarioAceiteFilterDto>();
            //carrega os dados de calendario de aceite
            foreach (var item in PartNumArr)
            {
                calendarioAceiteFilterDto.Add(new CalendarioAceiteFilterDto { TipoBusca = "P", CdCliente = salesdto.CD_Cliente,  Mercado = "MI", PartNumber = item});
            }


            List<DadosDataAceiteDto> dadosDataAceiteDto;
            dadosDataAceiteDto = await pluginServices.CalendarioAceiteAsync(calendarioAceiteFilterDto);

            //carrega os dados que vão ser listados na planilha
            infoPlaDtos = informationsPlan.GetDataforAdress(salesdto, DtPrazoDesejado.Value, placeCorrespForPartNumber, ReceiverCorrespsForPartNumber);

            //popula os detalhamentos de acordo com os partnumbers
            insertDetalPedido(ref infoPlaDtos, DetalheItemDtos, dadosDataAceiteDto);

            //delagates criados para deixar o objetos na mesma tread
            if (GridSales.InvokeRequired == true)
            {
                DelPopulateGridMap delPopulateGridMap = new DelPopulateGridMap(PopulateGridMap);
                delPopulateGridMap.Invoke(ref infoPlaDtos);
            }
            else
            {
                PopulateGridMap(ref infoPlaDtos);
            }

            DelAddColumReciver delAddColumReciver = new DelAddColumReciver(AddColumReciver);
            delAddColumReciver.Invoke(infoPlaDtos.First().ReceiverCorresp);

            DelAddColumPlace delAddColumPlace = new DelAddColumPlace(AddColumPlace);
            delAddColumPlace.Invoke(infoPlaDtos.First().PlaceCorresp);

            if (salesdto.Id == 0)
            {
                if (MessageBox.Show("Deseja salvar o mapeamento da planilha para o proximo pedido?", "Mapeamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    PluginService pluginser = new PluginService(auth);
                    var salvar = await pluginser.SaveInfoPlan(salesdto);
                }
            }
            SelectContext("OvAbaPedido");
        }

        private void insertDetalPedido(ref List<InfoPlaDto> plaDto, List<DetalheItemDto> detalheItem, List<DadosDataAceiteDto> dadosDataAceiteDto, List<MinimoMultiploDto> minimoMultiplos)
        {
         
            //mensagem padrao de como nao foi localizado
            plaDto.ForEach(s =>
            {
                s.Mensagem = "Part number não foi localizado";
                s.Validado = false;
            });
            //foreach (var item in detalheItem.Where(p => p.Status == "A"))
            foreach (var item in detalheItem)
            {
                //infoPlaDtos.Where(p => p.Id.ToString() == GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.Id.Key].Value.ToString()).ToList().ForEach(s => s.ReceiverMapped = novoValor);
                if (plaDto.Select(p => p.RefClient == item.Description).Any() == true)
                {
                    plaDto.Where(p => p.RefClient == item.Description).ToList().ForEach(s =>
                    {
                        s.Mensagem = "";
                        s.Validado = true;
                        s.detalheItem = item;
                    });
                }
            }
        }
        #endregion

        #region //////// Inicializar pedido
        private async void OvBtnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                Login login = new Login();
                AuthenticationServices authentication = new AuthenticationServices();
                //homologacao
                OvTxLogin.Text = "igorteste";
                OvTxSenha.Text = "Simo12es?";
                login.CreateLogin(OvTxLogin.Text, OvTxSenha.Text);

                var resultados = DataAnnotation.ValidateEntity<Login>(login);
                if (resultados.HasError == true)
                {
                    MessageBox.Show(resultados.ListaErro);
                    return;
                }
                auth = await authentication.ActionLogin(OvTxLogin.Text, OvTxSenha.Text);
                if (auth.Token != null)
                {
                    UserRepository userRepository = new UserRepository(auth, EndPointsAPI.User);
                    //var user = await userServices.UserInformation(auth);
                    var user = await userRepository.Get<User>();
                    if (user.CdCliente == null && user.CdGrupo == null)
                    {
                        MessageBox.Show("O Usuário não tem nenhum cliente ou grupo associado a ele!");
                        return;
                    }
                    //quanto tiver grupo, forçar a seleção
                    if (user.CdGrupo == null)
                    {

                        NameClienteForm(user.Cliente.DsCliente);
                        auth.SetCliente(user.CdCliente);
                        PluginService pluginServices = new PluginService(auth);
                        var sales = await pluginServices.GetInformationFieldsPlan(user.CdCliente);
                        if (sales != null)
                        {
                            salesdto = sales;
                            deParaRecebedorDto = await pluginServices.RecebedorDeParaGetAsync();
                            deParaBeneficiadorDto = await pluginServices.BeneficiadorDeParaGetAsync();
                        }
                        salesdto.CD_Cliente = user.CdCliente;
                        salesdto.UserName = auth.userName;

                        InitialStageSelectfields();
                    }
                    else
                    {

                        ClientRepository clientRepository = new ClientRepository(auth, EndPointsAPI.ClientGroup);
                        clientes = await clientRepository.showClientOrGrupo();
                        List<IdDescriptionDto> listClient = new List<IdDescriptionDto> { new IdDescriptionDto { Id = "1", Description = "Selecione um cliente" } };

                        listClient.AddRange(clientes.Select(item => new IdDescriptionDto { Id = item.codigoCliente, Description = String.Format("Cliente: {3}|UF:{0} |Cidade: {1} |Bairro:{2} ", item.estado, item.cidade, item.bairro, item.descricaoCliente) }));

                        if (ObCbClienteGrupo.InvokeRequired)
                            ObCbClienteGrupo.Invoke(new Action(() =>
                            {
                                ObCbClienteGrupo.DataSource = listClient;
                                ObCbClienteGrupo.DisplayMember = "Description";
                                ObCbClienteGrupo.ValueMember = "Id";
                            }));
                        if (ObBtnChosenClient.InvokeRequired)
                            ObBtnChosenClient.Invoke(new Action(() =>
                            {
                                ObBtnChosenClient.Visible = true;
                            }));
                        if (ObBtnChosenClient.InvokeRequired)
                            ObBtnChosenClient.Invoke(new Action(() =>
                            {
                                ObBtnChosenClient.Visible = true;
                            }));
                        if (OvLbClienteGrupo.InvokeRequired)
                            OvLbClienteGrupo.Invoke(new Action(() =>
                            {
                                OvLbClienteGrupo.Visible = true;
                            }));
                    }

                    MessageBox.Show("Login Realizado com sucesso");
                    SelectContext("OvAbaDados");

                }
                else
                {
                    MessageBox.Show("Falha ao tentar logar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao tentar logar: " + ex.Message);
            }
        }

        private void ObCbClienteGrupo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ObCbClienteGrupo.SelectedValue.ToString() == "1")
            {
                ObBtnChosenClient.Visible = false;
                return;
            }

            ObBtnChosenClient.Visible = true;

        }

        private async void ObBtnChosenClient_Click(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync();

            if (ObCbClienteGrupo.SelectedValue.ToString() == "1")
                return;

            var client = clientes.Where(p => p.codigoCliente == ObCbClienteGrupo.SelectedValue.ToString()).FirstOrDefault();
            //coloca o cliente como padrao dentro do authentication para ser passar como parametro padrao

            auth.SetCliente(client.codigoCliente);
            PluginService pluginServices = new PluginService(auth);

            try
            {
                var sales = await pluginServices.GetInformationFieldsPlan(client.codigoCliente);
                if (sales != null)
                {
                    salesdto = sales;
                    deParaRecebedorDto = await pluginServices.RecebedorDeParaGetAsync();
                    deParaBeneficiadorDto = await pluginServices.BeneficiadorDeParaGetAsync();

                }
                salesdto.CD_Cliente = client.codigoCliente;
                salesdto.UserName = auth.userName;
                NameClienteForm(client.descricaoCliente);

                InitialStageSelectfields();

            }
            catch (Exception ex)
            {

            }
            if (ObBtnChosenClient.InvokeRequired == true)
            {
                ObBtnChosenClient.Invoke(new Action(() =>
                {
                    ObBtnChosenClient.Visible = false;
                }));
                ObCbClienteGrupo.Invoke(new Action(() =>
                {
                    ObCbClienteGrupo.Visible = false;
                }));
                OvLbClienteGrupo.Invoke(
                    new Action(() =>
                    {
                        OvLbClienteGrupo.Visible = false;
                    }));
            }
            else
            {
                ObBtnChosenClient.Visible = false;
                ObCbClienteGrupo.Visible = false;
            }
            SelectContext("OvAbaDados");
        }
        #endregion

        #region //////// botoes de classificação 

        private void OvBtnClassRefCliente_Click(object sender, EventArgs e)
        {
            FieldEdit = 1;
            //salesdto.DesiredPeriod = "$M$21";
            //salesdto.Place = "$C$21";
            //salesdto.Receiver = "$B$21";
            //salesdto.RefClient = "$A$21";
            //salesdto.D1 = "$j$21";
            //salesdto.D2 = "$K$21";
            //salesdto.D3 = "$l$21";
            SaleDtoEdit();
            InitialStageSelectfields();

        }

        private void OvBtnClassRecebedor_Click(object sender, EventArgs e)
        {
            FieldEdit = 2;
            SaleDtoEdit();
            InitialStageSelectfields();

        }

        private void OvBtnClassLocalEntrega_Click(object sender, EventArgs e)
        {
            FieldEdit = 3;
            SaleDtoEdit();
            InitialStageSelectfields();

        }

        private void OvBtnClassPeriodo_Click(object sender, EventArgs e)
        {
            FieldEdit = 4;
            SaleDtoEdit();
            InitialStageSelectfields();

        }

        private void OvBtnClassTonelagemD1_Click(object sender, EventArgs e)
        {
            FieldEdit = 5;
            SaleDtoEdit();
            InitialStageSelectfields();
        }

        private void OvBtnClassTonelagemD2_Click(object sender, EventArgs e)
        {
            FieldEdit = 6;
            SaleDtoEdit();
            InitialStageSelectfields();
        }

        private void OvBtnClassTonelagemD3_Click(object sender, EventArgs e)
        {
            FieldEdit = 7;
            SaleDtoEdit();
            InitialStageSelectfields();
        }

        #endregion 

        #region //////// botoes de cancelar classificação
        private void OvBtnClassRefClienteCancel_Click(object sender, EventArgs e)
        {
            InitialStageSelectfields();
        }

        private void OvBtnClassRecebedorCancel_Click(object sender, EventArgs e)
        {
            InitialStageSelectfields();
        }

        private void OvBtnClassLocalEntregaCancel_Click(object sender, EventArgs e)
        {
            InitialStageSelectfields();
        }

        private void OvBtnClassPeriodoCancel_Click(object sender, EventArgs e)
        {
            InitialStageSelectfields();
        }

        private void OvBtnClassTonelagemCancel_Click(object sender, EventArgs e)
        {
            InitialStageSelectfields();
        }
        private void OvBtnClassTonelagemD2Cancel_Click(object sender, EventArgs e)
        {
            InitialStageSelectfields();
        }

        private void OvBtnClassTonelagemD3Cancel_Click(object sender, EventArgs e)
        {
            InitialStageSelectfields();
        }
        #endregion 

        #region //////// Options para escolher a classificação do campo
        private void OvRdnull_CheckedChanged(object sender, EventArgs e)
        {
            // InitialStageSelectfields();
        }

        private void OvRdRefCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.ToString().Contains("Checked: False"))
                return;

            FieldEdit = 1;
            VisibleBtnClass();
            VisibleBtnCancel();

            ReadOnlySelectField();
            FormSalesDtoBind();
        }

        private void OvRdRecebedor_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.ToString().Contains("Checked: False"))
                return;

            FieldEdit = 2;
            VisibleBtnClass();
            VisibleBtnCancel();

            ReadOnlySelectField();
            FormSalesDtoBind();
        }

        private void OvRdLocalEntrega_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.ToString().Contains("Checked: False"))
                return;

            FieldEdit = 3;
            VisibleBtnClass();
            VisibleBtnCancel();

            ReadOnlySelectField();
            FormSalesDtoBind();
        }

        private void OvRdPerioDesejado_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.ToString().Contains("Checked: False"))
                return;

            FieldEdit = 4;
            VisibleBtnClass();
            VisibleBtnCancel();
            ReadOnlySelectField();
            FormSalesDtoBind();
        }

        private void OvRdTonelagem_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.ToString().Contains("Checked: False"))
                return;

            FieldEdit = 5;
            VisibleBtnClass();
            VisibleBtnCancel();

            ReadOnlySelectField();
            FormSalesDtoBind();
        }

        private void OvRdTonelagemD2_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.ToString().Contains("Checked: False"))
                return;

            FieldEdit = 6;
            VisibleBtnClass();
            VisibleBtnCancel();

            ReadOnlySelectField();
            FormSalesDtoBind();
        }

        private void OvRdTonelagemD3_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.ToString().Contains("Checked: False"))
                return;

            FieldEdit = 7;
            VisibleBtnClass();
            VisibleBtnCancel();

            ReadOnlySelectField();
            FormSalesDtoBind();
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            mocardadosFormulario();
        }
    }
}
