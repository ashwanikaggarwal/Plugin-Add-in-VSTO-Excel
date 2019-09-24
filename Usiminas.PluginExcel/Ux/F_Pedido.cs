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
using System.Threading.Tasks;

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
        SalesDto salesdtoOrigem = new SalesDto();
        List<ClientePluginDto> clientes;
        List<InfoPlaDto> infoPlaDtos;

        List<DetalheItemDto> DetalheItemDtos;
        List<CalendarioAceiteFilterDto> calendarioAceiteFilterDto;
        Load load = new Load();

        int FieldEdit; // variavel que define qual é o botão
        #endregion

        // variavel que controla as abas
        List<ListAbas> ListAbas = new List<ListAbas>();

        #region Inicialização e transição de form
        public F_Pedido()
        {
            InitializeComponent();
            ListAbas.Add( new ListAbas() { Tab = this.OvAbaConfiguracao });
            ListAbas.Add( new ListAbas() { Tab = this.OvAbaDados });
            ListAbas.Add( new ListAbas() { Tab = this.OvAbaPedido });
            ListAbas.Add( new ListAbas() { Tab = this.OvAbaCarrinhoTabela });
            ListAbas.Add(new ListAbas() { Tab = this.OvAbaLoad, Visible = false });

            InitialStageSelectfields();
        }
        private void F_Pedido_Load(object sender, EventArgs e)
        {
            OvAbaCarrinhoTab.Hide();

            SelectContext("OvAbaConfiguracao");
            //
            InitialStageSelectfields();
            ObBtnChosenClient.Visible = false;
            ObCbClienteGrupo.Visible = false;
            OvLbClienteGrupo.Visible = false;
            OvLbVersao.Text = "Versão: " + Functions.Versao().ToString().Replace(",", ".");
            FecharLoad("OvAbaConfiguracao");
        }

        protected void Form1_OnKeyPress(object sender, KeyPressEventArgs e)
        {
            //KeyChar é igual a 13, então usuário apertou ENTER
            if (e.KeyChar == 13)
            {
                OvBtnLogin_Click(sender, null);
            }
        }

        private async void OvBtnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                AbrirLoad(TextosLoad.Login);
                ///reseta as configurações
                InitialStageSelectfields();
                ObBtnChosenClient.Visible = false;
                ObCbClienteGrupo.Visible = false;
                OvLbClienteGrupo.Visible = false;
                OvTxLogin.Text = "igorteste";
                OvTxSenha.Text = "Simo12es?";

                Login login = new Login();

                AuthenticationServices authentication = new AuthenticationServices();
                //homologacao

                login.CreateLogin(OvTxLogin.Text, OvTxSenha.Text);

                var resultados = DataAnnotation.ValidateEntity<Login>(login);

                if (resultados.HasError == true)
                {
                    MessageBox.Show(resultados.ListaErro);

                    return;
                }

                List<IdDescriptionDto> listClient = new List<IdDescriptionDto> { new IdDescriptionDto { Id = "1", Description = "Selecione um cliente" } };


                //auth = await Task.Run(async () => await authentication.ActionLogin(OvTxLogin.Text, OvTxSenha.Text));
                auth = await authentication.ActionLogin(OvTxLogin.Text, OvTxSenha.Text);

                LogServices.LogEmissaoSimples(auth, "login", "Inicio de log");

                if (auth.Token != null)
                {

                    PluginService pluginServices = new PluginService(auth);

                    var versao = await pluginServices.GetVersaoAsync();

                    if (versao.minimaVersao > Functions.Versao())
                        throw new CustomExceptions(string.Format("Sua versão({0}) está desatualizada, favor atualizar!", Functions.Versao().ToString().Replace(",", ".")));

                    UserRepository userRepository = new UserRepository(auth, EndPointsAPI.User);

                    //var user = await userServices.UserInformation(auth);
                    var user = await userRepository.Get<User>();

                    if (user.CdCliente == null && user.CdGrupo == null)
                    {
                        MessageBox.Show("O Usuário não tem nenhum cliente ou grupo associado a ele!");

                        LogServices.LogEmissaoSimples(auth, "cadastro", "O Usuário não tem nenhum cliente ou grupo associado a ele!");

                        return;
                    }
                    //quanto tiver grupo, forçar a seleção
                    if (user.CdGrupo == null)
                    {

                        NameClienteForm(user.Cliente.DsCliente);

                        auth.SetCliente(user.CdCliente);

                        salesdtoOrigem = await pluginServices.GetInformationFieldsPlan(user.CdCliente);

                        if (salesdtoOrigem != null)
                        {
                            salesdto = salesdtoOrigem;

                            deParaRecebedorDto = await pluginServices.RecebedorDeParaGetAsync();
                            LogServices.LogEmissaoClass<List<DeParaRecebedorDto>>(auth, "Dados mapeamento", "Pegando dados List<DeParaRecebedorDto>", deParaRecebedorDto);

                            deParaBeneficiadorDto = await pluginServices.BeneficiadorDeParaGetAsync();
                            LogServices.LogEmissaoClass<List<DeParaBeneficiadorDto>>(auth, "Dados mapeamento", "Pegando dados List<DeParaBeneficiadorDto>", deParaBeneficiadorDto);

                        }
                        salesdto.CD_Cliente = user.CdCliente;

                        salesdto.UserName = auth.userName;

                        LogServices.LogEmissaoClass<SalesDto>(auth, "mapeamento Planilha", "Dados mapeamento", salesdto);

                        InitialStageSelectfields();
                    }
                    else
                    {

                        ClientRepository clientRepository = new ClientRepository(auth, EndPointsAPI.ClientGroup);

                        clientes = await clientRepository.showClientOrGrupo();

                        LogServices.LogEmissaoClass<List<ClientePluginDto>>(auth, "login", "escolher cliente", clientes);

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

                   // SelectContext("OvAbaDados");
                }
                else
                {
                    MessageBox.Show("Falha ao tentar logar");
                }
            }
            catch (CustomExceptions ex)
            {
                LogServices.LogEmissaoClass<CustomExceptions>(auth, "Erro", "login", ex);

                MessageBox.Show("Falha ao tentar logar: " + ex.CustomMessagem());
            }
            finally
            {
                FecharLoad("OvAbaDados");
            }
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
                AbrirLoad(TextosLoad.BuscardadosCliente);

                salesdtoOrigem = await pluginServices.GetInformationFieldsPlan(client.codigoCliente);

                if (salesdtoOrigem != null)
                {
                    salesdto = salesdtoOrigem;

                    deParaRecebedorDto = await pluginServices.RecebedorDeParaGetAsync();

                    LogServices.LogEmissaoClass<List<DeParaRecebedorDto>>(auth, "Dados mapeamento", "List<DeParaRecebedorDto>", deParaRecebedorDto);

                    deParaBeneficiadorDto = await pluginServices.BeneficiadorDeParaGetAsync();

                    LogServices.LogEmissaoClass<List<DeParaBeneficiadorDto>>(auth, "Dados mapeamento", "List<DeParaBeneficiadorDto>", deParaBeneficiadorDto);

                }
                salesdto.CD_Cliente = client.codigoCliente;

                salesdto.UserName = auth.userName;

                NameClienteForm(client.descricaoCliente);

                LogServices.LogEmissaoClass<SalesDto>(auth, "Dados mapeamento", "Dados mapeamento", salesdto);

                InitialStageSelectfields();

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
            catch (CustomExceptions ex)
            {
                LogServices.LogEmissaoClass<CustomExceptions>(auth, "erro", "ChosenClient", ex);
            }
            finally
            {
                AbrirLoad(TextosLoad.BuscardadosCliente);
            }

        }
        /// ////////////////////////////
        
            /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OvBtnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                BtnIrParaCarrinho.Enabled = true;

                AbrirLoad(TextosLoad.BuscardadosCliente);

                var resultados = DataAnnotation.ValidateEntity<SalesDto>(salesdto);

                if (resultados.HasError == true)
                {
                    MessageBox.Show(resultados.ListaErro);
                    return;
                }
                if (salesdto.IntegridadeDados() == false)
                {
                    MessageBox.Show("Todos os dados tem que estar na mesma linha do excel!");
                    return;
                }


                InformationsPlan informationsPlan = new InformationsPlan();

                //pega a lista de recebedor e beneficiador cadastrado
                var PartNumArr = informationsPlan.GetPartNumberPlan(salesdto);

                if (PartNumArr.Count == 0)
                {
                    MessageBox.Show("Nenhum partNumber foi localizado! Favor verificar");
                    LogServices.LogEmissaoSimples(auth, "Mapeamento planilha", "Nenhum partNumber foi localizado");
                    return;
                }
                PluginService pluginServices = new PluginService(auth);
                //var ReceiverCorrespsForPartNumber = pluginServices.ReceiverCorrespsPostAsync(PartNumArr.ToArray(), salesdto.CD_Cliente).GetAwaiter().GetResult();
                var ReceiverCorrespsForPartNumber = await pluginServices.ReceiverCorrespsPostAsync(PartNumArr.ToArray(), salesdto.CD_Cliente);

                var placeCorrespForPartNumber = await pluginServices.PlaceCorrespsPostAsync(PartNumArr.ToArray(), salesdto.CD_Cliente);

                LogServices.LogEmissaoSimples(auth, "Mapeamento planilha", "Nenhum partNumber foi localizado");

                //pega o dstalhamento de acordo com os partnumbers
                DetalheItemDtos = await pluginServices.DetalhamentoDePartNumber(PartNumArr.ToArray(), salesdto.CD_Cliente);

                //carrega o minimo multiplo
                var validaPesoMultiPartNumberDto = new ValidaPesoMultiPartNumberDto();

                validaPesoMultiPartNumberDto.CdCliente = salesdto.CD_Cliente;

                validaPesoMultiPartNumberDto.PartNumbers = PartNumArr;

                validaPesoMultiPartNumberDto.Recebedores = ReceiverCorrespsForPartNumber.Select(p => p.Id).ToList();

                List<MinimoMultiploDto> MinimoMultiplo = await pluginServices.PesoMultiploPartNumberAsync(validaPesoMultiPartNumberDto);

                calendarioAceiteFilterDto = new List<CalendarioAceiteFilterDto>();
                //carrega os dados de calendario de aceite
                foreach (var item in PartNumArr)
                {
                    calendarioAceiteFilterDto.Add(new CalendarioAceiteFilterDto { TipoBusca = "P", CdCliente = salesdto.CD_Cliente, Mercado = "MI", PartNumber = item });
                }


                List<DadosDataAceiteDto> dadosDataAceiteDto;

                dadosDataAceiteDto = await pluginServices.CalendarioAceiteAsync(calendarioAceiteFilterDto);

                //carrega os dados que vão ser listados na planilha
                infoPlaDtos = informationsPlan.GetDataforAdress(salesdto, DtPrazoDesejado.Value, placeCorrespForPartNumber, ReceiverCorrespsForPartNumber);

                //popula os detalhamentos de acordo com os partnumbers
                insertDetalPedido(ref infoPlaDtos, DetalheItemDtos, dadosDataAceiteDto, MinimoMultiplo);

                if (!infoPlaDtos.Where(p => p.Validado == true).Any())
                {
                    MessageBox.Show("Nenhum partNumber foi localizado! Favor verificar");
                    if (BtnIrParaCarrinho.InvokeRequired == true)
                    {
                        BtnIrParaCarrinho.Invoke(new Action(() => { BtnIrParaCarrinho.Enabled = false; }));
                    }
                    else
                    {
                        BtnIrParaCarrinho.Enabled = false;
                    }
                    //return;
                }

                //delagates criados para deixar o objetos na mesma thread
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

                if (MessageBox.Show("Deseja salvar o mapeamento da planilha para o proximo pedido?", "Mapeamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    LogServices.LogEmissaoClass<SalesDto>(auth, "Salvar novo Mapeamento", "salesdto", salesdto);
                    PluginService pluginser = new PluginService(auth);
                    var salvar = await pluginser.SaveInfoPlan(salesdto);
                }

                FecharLoad("OvAbaPedido");

            }
            catch (CustomExceptions ex)
            {
                MessageBox.Show(ex.CustomMessagem());
                FecharLoad("OvAbaDados");
            }
        }

        private void insertDetalPedido(ref List<InfoPlaDto> plaDto, List<DetalheItemDto> detalheItem, List<DadosDataAceiteDto> dadosDataAceiteDto, List<MinimoMultiploDto> minimoMultiplos)
        {

            //mensagem padrao de como nao foi localizado
            plaDto.ForEach(s =>
            {
                s.Mensagem = "Part number não foi localizado; ";
                s.Validado = false;
            });
            //foreach (var item in detalheItem.Where(p => p.Status == "A"))
            foreach (var item in detalheItem)
            {
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
            if (plaDto.Where(p => p.Validado == true).Any())
            {
                //insere os minimos multiplos
                plaDto.Where(p => p.Validado == true).ToList().ForEach(s =>
                {
                    s.Mensagem = s.Mensagem + "Multiplo não localizado; ";
                    s.Validado = false;
                });

                foreach (var item in minimoMultiplos)
                {
                    plaDto.Where(p => p.RefClient == item.BK_PartnumberCliente).ToList().ForEach(s =>
                    {
                        s.Validado = true;
                        s.Mensagem = s.Mensagem.Replace("Multiplo não localizado; ", "");
                        s.minimoMultiplo = item;
                    });
                }

                //insere as datas de aceite
                plaDto.Where(p => p.Validado == true).ToList().ForEach(s =>
                {
                    s.Mensagem += "Data de aceite não localizado; ";
                    s.Validado = false;
                });

                foreach (var item in dadosDataAceiteDto)
                {
                    plaDto.Where(p => p.RefClient == item.PartNumber).ToList().ForEach(s =>
                    {
                        s.DataAceite = item;
                        s.Mensagem = s.Mensagem.Replace("Data de aceite não localizado; ", "");
                        s.Validado = true;
                    });
                }
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


        #endregion

        #region Mapeamento de planilha

        #region //////// buttons interations


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
            catch (CustomExceptions ex)
            {
                MessageBox.Show(ex.CustomMessagem());
            }
        }

      

        /// <summary>
        /// actions Handlers for textbox
        /// </summary>
        public void ReadOnlySelectField()
        {
            if (this.OvTxSelecaoRefCliente.InvokeRequired == true)
            {
                this.OvTxSelecaoRefCliente.Invoke(new Action(() => { this.OvTxSelecaoRefCliente.ReadOnly = true; }));
            }
            else { this.OvTxSelecaoRefCliente.ReadOnly = true; }

            if (this.OvTxSelecaoRecebedor.InvokeRequired == true)
            {
                this.OvTxSelecaoRecebedor.Invoke(new Action(() => { this.OvTxSelecaoRecebedor.ReadOnly = true; }));
            }
            else { this.OvTxSelecaoRecebedor.ReadOnly = true; }

            if (this.OvTxSelecaoLocalEntrega.InvokeRequired == true)
            {
                this.OvTxSelecaoLocalEntrega.Invoke(new Action(() => { this.OvTxSelecaoLocalEntrega.ReadOnly = true; }));
            }
            else { this.OvTxSelecaoLocalEntrega.ReadOnly = true; }

            if (this.OvTxSelecaoPeriodo.InvokeRequired == true)
            {
                this.OvTxSelecaoPeriodo.Invoke(new Action(() => { this.OvTxSelecaoPeriodo.ReadOnly = true; }));
            }
            else { this.OvTxSelecaoPeriodo.ReadOnly = true; }

            if (this.OvTxSelecaoTonelagemD1.InvokeRequired == true)
            {
                this.OvTxSelecaoTonelagemD1.Invoke(new Action(() => { this.OvTxSelecaoTonelagemD1.ReadOnly = true; }));
            }
            else { this.OvTxSelecaoTonelagemD1.ReadOnly = true; }

            if (this.OvTxSelecaoTonelagemD2.InvokeRequired == true)
            {
                this.OvTxSelecaoTonelagemD2.Invoke(new Action(() => { this.OvTxSelecaoTonelagemD2.ReadOnly = true; }));
            }
            else { this.OvTxSelecaoTonelagemD2.ReadOnly = true; }

            if (this.OvTxSelecaoTonelagemD3.InvokeRequired == true)
            {
                this.OvTxSelecaoTonelagemD3.Invoke(new Action(() => { this.OvTxSelecaoTonelagemD3.ReadOnly = true; }));
            }
            else { this.OvTxSelecaoTonelagemD3.ReadOnly = true; }

            switch (FieldEdit)
            {
                case 1:
                    this.OvTxSelecaoRefCliente.ReadOnly = false; //1
                    break;
                case 2:
                    this.OvTxSelecaoRecebedor.ReadOnly = false;
                    break;
                case 3:
                    this.OvTxSelecaoLocalEntrega.ReadOnly = false;
                    break;
                case 4:
                    this.OvTxSelecaoPeriodo.ReadOnly = false;
                    break;
                case 5:
                    this.OvTxSelecaoTonelagemD1.ReadOnly = false;
                    break;
                case 6:
                    this.OvTxSelecaoTonelagemD2.ReadOnly = false;
                    break;
                case 7:
                    this.OvTxSelecaoTonelagemD3.ReadOnly = false;
                    break;
                default:
                    break;
            }
            FPTimer.Start();
        }

        /// <summary>
        /// actions Handlers for sort button 
        /// </summary>
        public void VisibleBtnClass()
        {
            if (this.OvBtnClassRefCliente.InvokeRequired == true)
            {
                this.OvBtnClassRefCliente.Invoke(new Action(() => { this.OvBtnClassRefCliente.Visible = false; }));
            }
            else { this.OvBtnClassRefCliente.Visible = false; }

            if (this.OvBtnClassRecebedor.InvokeRequired == true)
            {
                this.OvBtnClassRecebedor.Invoke(new Action(() => { this.OvBtnClassRecebedor.Visible = false; }));
            }
            else { this.OvBtnClassRecebedor.Visible = false; }

            if (this.OvBtnClassLocalEntrega.InvokeRequired == true)
            {
                this.OvBtnClassLocalEntrega.Invoke(new Action(() => { this.OvBtnClassLocalEntrega.Visible = false; }));
            }
            else { this.OvBtnClassLocalEntrega.Visible = false; }

            if (this.OvBtnClassPeriodo.InvokeRequired == true)
            {
                this.OvBtnClassPeriodo.Invoke(new Action(() => { this.OvBtnClassPeriodo.Visible = false; }));
            }
            else { this.OvBtnClassPeriodo.Visible = false; }

            if (this.OvBtnClassTonelagemD1.InvokeRequired == true)
            {
                this.OvBtnClassTonelagemD1.Invoke(new Action(() => { this.OvBtnClassTonelagemD1.Visible = false; }));
            }
            else { this.OvBtnClassTonelagemD1.Visible = false; }

            if (this.OvBtnClassTonelagemD2.InvokeRequired == true)
            {
                this.OvBtnClassTonelagemD2.Invoke(new Action(() => { this.OvBtnClassTonelagemD2.Visible = false; }));
            }
            else { this.OvBtnClassTonelagemD2.Visible = false; }

            if (this.OvBtnClassTonelagemD3.InvokeRequired == true)
            {
                this.OvBtnClassTonelagemD3.Invoke(new Action(() => { this.OvBtnClassTonelagemD3.Visible = false; }));
            }
            else { this.OvBtnClassTonelagemD3.Visible = false; }


            switch (FieldEdit)
            {
                case 1:

                    this.OvBtnClassRefCliente.Visible = true;
                    break;
                case 2:
                    this.OvBtnClassRecebedor.Visible = true;
                    break;
                case 3:
                    this.OvBtnClassLocalEntrega.Visible = true;
                    break;
                case 4:
                    this.OvBtnClassPeriodo.Visible = true;
                    break;
                case 5:
                    this.OvBtnClassTonelagemD1.Visible = true;
                    break;
                case 6:
                    this.OvBtnClassTonelagemD2.Visible = true;
                    break;
                case 7:
                    this.OvBtnClassTonelagemD3.Visible = true;
                    break;
                default:

                    break;
            }
        }

        /// <summary>
        /// actions Handlers for button Cancel 
        /// </summary>
        public void VisibleBtnCancel()
        {
            if (this.OvBtnClassRefClienteCancel.InvokeRequired == true)
            {
                this.OvBtnClassRefClienteCancel.Invoke(new Action(() => { this.OvBtnClassRefClienteCancel.Visible = false; }));
            }
            else { this.OvBtnClassRefClienteCancel.Visible = false; }

            if (this.OvBtnClassRecebedorCancel.InvokeRequired == true)
            {
                this.OvBtnClassRecebedorCancel.Invoke(new Action(() => { this.OvBtnClassRecebedorCancel.Visible = false; }));
            }
            else { this.OvBtnClassRecebedorCancel.Visible = false; }

            if (this.OvBtnClassLocalEntregaCancel.InvokeRequired == true)
            {
                this.OvBtnClassLocalEntregaCancel.Invoke(new Action(() => { this.OvBtnClassLocalEntregaCancel.Visible = false; }));
            }
            else { this.OvBtnClassLocalEntregaCancel.Visible = false; }
            if (this.OvBtnClassPeriodoCancel.InvokeRequired == true)
            {
                this.OvBtnClassPeriodoCancel.Invoke(new Action(() => { this.OvBtnClassPeriodoCancel.Visible = false; }));
            }
            else { this.OvBtnClassPeriodoCancel.Visible = false; }
            if (this.OvBtnClassTonelagemD1Cancel.InvokeRequired == true)
            {
                this.OvBtnClassTonelagemD1Cancel.Invoke(new Action(() => { this.OvBtnClassTonelagemD1Cancel.Visible = false; }));
            }
            else { this.OvBtnClassTonelagemD1Cancel.Visible = false; }
            if (this.OvBtnClassTonelagemD2Cancel.InvokeRequired == true)
            {
                this.OvBtnClassTonelagemD2Cancel.Invoke(new Action(() => { this.OvBtnClassTonelagemD2Cancel.Visible = false; }));
            }
            else { this.OvBtnClassTonelagemD2Cancel.Visible = false; }
            if (this.OvBtnClassTonelagemD3Cancel.InvokeRequired == true)
            {
                this.OvBtnClassTonelagemD3Cancel.Invoke(new Action(() => { this.OvBtnClassTonelagemD3Cancel.Visible = false; }));
            }
            else { this.OvBtnClassTonelagemD3Cancel.Visible = false; }

            switch (FieldEdit)
            {
                case 1:
                    this.OvBtnClassRefClienteCancel.Visible = true;
                    break;
                case 2:
                    this.OvBtnClassRecebedorCancel.Visible = true;
                    break;
                case 3:
                    this.OvBtnClassLocalEntregaCancel.Visible = true;
                    break;
                case 4:
                    this.OvBtnClassPeriodoCancel.Visible = true;
                    break;
                case 5:
                    this.OvBtnClassTonelagemD1Cancel.Visible = true;
                    break;
                case 6:
                    this.OvBtnClassTonelagemD2Cancel.Visible = true;
                    break;
                case 7:
                    this.OvBtnClassTonelagemD3Cancel.Visible = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Bind specific text to Field SalesDto
        /// </summary>
        public void SaleDtoEdit(bool clear = false)
        {
            switch (FieldEdit)
            {
                case 1:
                    salesdto.RefClient = clear == false ? this.OvTxSelecaoRefCliente.Text : "";
                    break;
                case 2:
                    salesdto.Receiver = clear == false ? this.OvTxSelecaoRecebedor.Text : "";
                    break;
                case 3:
                    salesdto.Place = clear == false ? this.OvTxSelecaoLocalEntrega.Text : "";
                    break;
                case 4:
                    salesdto.DesiredPeriod = clear == false ? this.OvTxSelecaoPeriodo.Text : "";
                    break;
                case 5:
                    salesdto.D1 = clear == false ? this.OvTxSelecaoTonelagemD1.Text : "";
                    break;
                case 6:
                    salesdto.D2 = clear == false ? this.OvTxSelecaoTonelagemD2.Text : "";
                    break;
                case 7:
                    salesdto.D3 = clear == false ? this.OvTxSelecaoTonelagemD3.Text : "";
                    break;
            }
        }

        /// <summary>
        /// Data Bind adress from salesDto to text fields 
        /// </summary>
        public void FormSalesDtoBind()
        {

            if (OvTxSelecaoRefCliente.InvokeRequired == true)
            {
                OvTxSelecaoRefCliente.Invoke(new Action(() => { this.OvTxSelecaoRefCliente.Text = salesdto.RefClient; }));
            }
            else { this.OvTxSelecaoRefCliente.Text = salesdto.RefClient; }

            if (OvTxSelecaoRecebedor.InvokeRequired == true)
            {
                OvTxSelecaoRecebedor.Invoke(new Action(() => { this.OvTxSelecaoRecebedor.Text = salesdto.Receiver; }));
            }
            else { this.OvTxSelecaoRecebedor.Text = salesdto.Receiver; }

            if (OvTxSelecaoLocalEntrega.InvokeRequired == true)
            {
                OvTxSelecaoLocalEntrega.Invoke(new Action(() => { this.OvTxSelecaoLocalEntrega.Text = salesdto.Place; }));
            }
            else { this.OvTxSelecaoLocalEntrega.Text = salesdto.Place; }
            if (OvTxSelecaoPeriodo.InvokeRequired == true)
            {
                OvTxSelecaoPeriodo.Invoke(new Action(() => { this.OvTxSelecaoPeriodo.Text = salesdto.DesiredPeriod; }));
            }
            else { this.OvTxSelecaoPeriodo.Text = salesdto.DesiredPeriod; }

            if (OvTxSelecaoTonelagemD1.InvokeRequired == true)
            {
                OvTxSelecaoTonelagemD1.Invoke(new Action(() => { this.OvTxSelecaoTonelagemD1.Text = salesdto.D1; }));
            }
            else { this.OvTxSelecaoTonelagemD1.Text = salesdto.D1; }

            if (OvTxSelecaoTonelagemD2.InvokeRequired == true)
            {
                OvTxSelecaoTonelagemD2.Invoke(new Action(() => { this.OvTxSelecaoTonelagemD2.Text = salesdto.D2; }));
            }
            else { this.OvTxSelecaoTonelagemD2.Text = salesdto.D2; }

            if (OvTxSelecaoTonelagemD3.InvokeRequired == true)
            {
                OvTxSelecaoTonelagemD3.Invoke(new Action(() => { this.OvTxSelecaoTonelagemD3.Text = salesdto.D3; }));
            }
            else { this.OvTxSelecaoTonelagemD3.Text = salesdto.D3; }

        }

        public void InitialStageSelectfields()
        {
            FieldEdit = 0;
            ReadOnlySelectField();
            VisibleBtnClass();
            VisibleBtnCancel();
            FPTimer.Stop();
            FormSalesDtoBind();
            OvRdnull.Checked = true;
        }

        #endregion

        #region //////// botoes de classificação 

        private void OvBtnClassRefCliente_Click(object sender, EventArgs e)
        {
            FieldEdit = 1;
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
            FieldEdit = 1;
            SaleDtoEdit(true);
            InitialStageSelectfields();
        }

        private void OvBtnClassRecebedorCancel_Click(object sender, EventArgs e)
        {
            FieldEdit = 2;
            SaleDtoEdit(true);
            InitialStageSelectfields();
        }

        private void OvBtnClassLocalEntregaCancel_Click(object sender, EventArgs e)
        {
            FieldEdit = 3;
            SaleDtoEdit(true);
            InitialStageSelectfields();
        }

        private void OvBtnClassPeriodoCancel_Click(object sender, EventArgs e)
        {
            FieldEdit = 4;
            SaleDtoEdit(true);
            InitialStageSelectfields();
        }

        private void OvBtnClassTonelagemCancel_Click(object sender, EventArgs e)
        {
            FieldEdit = 5;
            SaleDtoEdit(true);
            InitialStageSelectfields();
        }
        private void OvBtnClassTonelagemD2Cancel_Click(object sender, EventArgs e)
        {
            FieldEdit = 6;
            SaleDtoEdit(true);
            InitialStageSelectfields();
        }

        private void OvBtnClassTonelagemD3Cancel_Click(object sender, EventArgs e)
        {
            FieldEdit = 7;
            SaleDtoEdit(true);
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

        #endregion

        #region Leitura de planilha

        #region ////////Delegates
        private delegate void DelPopulateGridMap(ref List<InfoPlaDto> ret);
        private delegate void DelAddColumReciver(List<ReceiverCorresp> receiverCorresp);
        private delegate void DelAddColumPlace(List<PlaceCorresp> PlaceCorresp);
        private delegate void DelPopulateReturnTempInvoce();


        #endregion

        #region //////// HandlerGrid

        /// <summary>
        /// bind the grid for maping fields from Excel
        /// </summary>
        /// <param name="ret"></param>
        private void PopulateGridMap(ref List<InfoPlaDto> ret)
        {
            if (GridSales.InvokeRequired == true)
            {
                GridSales.Invoke(new Action(() =>
                {
                    GridSales.Rows.Clear();
                }));
            }
            else
            {
                GridSales.Rows.Clear();
            }
            foreach (var item in ret)
            {

                if (GridSales.InvokeRequired == true)
                {
                    GridSales.Invoke(new Action(() =>
                    {
                        //GridSales.Controls.Clear();
                        GridSales.Rows.Add(item.RefClient, item.Id, item.Receiver, null, null, item.Place, null, null, item.Mensagem, item.D1, item.D2, item.D3, item.DesiredPeriod);
                    }));
                }
                else
                {
                    GridSales.Rows.Add(item.RefClient, item.Id, item.Receiver, null, null, item.Place, null, null, item.Mensagem, item.D1, item.D2, item.D3, item.DesiredPeriod);
                }
            }


        }

        /// <summary>
        /// create new collunms to bind form map
        /// </summary>
        private void AddColumReciver(List<ReceiverCorresp> receiverCorresp)
        {
            if (GridSales.InvokeRequired == true)
            {
                GridSales.Invoke(new Action(() =>
                {
                    foreach (DataGridViewRow item in GridSales.Rows)
                    {
                        DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(item.Cells[TabMapColGrid.RecebedorLista.Key]);
                        ContactCombo.DataSource = receiverCorresp.Select(p => p.Description).ToArray();

                        string preencher = Functions.GetValueintoListRecebedor(deParaRecebedorDto, receiverCorresp, item.Cells[TabMapColGrid.Recebedor.Key].Value.ToString());

                        if (preencher != null)
                        {
                            item.Cells[TabMapColGrid.RecebedorLista.Key].Value = preencher;
                            item.Cells[TabMapColGrid.RecebedorMapeado.Key].Value = preencher;
                            //altera o val or da lista existente
                            infoPlaDtos.Where(p => p.Id.ToString() == item.Cells[TabMapColGrid.RecebedorLista.Key].Value.ToString()).ToList().ForEach(s => s.PlacerMapped = preencher);
                            //dataGridView1.Rows[rowIndexYouWant].Cells["ComboColumn"].Value = "1";
                        }
                    }
                }));
            }
            else
            {
                foreach (DataGridViewRow item in GridSales.Rows)
                {
                    DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(item.Cells[TabMapColGrid.RecebedorLista.Key]);
                    ContactCombo.DataSource = receiverCorresp.Select(p => p.Description).ToArray();

                    string preencher = Functions.GetValueintoListRecebedor(deParaRecebedorDto, receiverCorresp, item.Cells[TabMapColGrid.Recebedor.Key].Value.ToString());

                    if (preencher != null)
                    {
                        item.Cells[TabMapColGrid.RecebedorLista.Key].Value = preencher;
                        item.Cells[TabMapColGrid.RecebedorMapeado.Key].Value = preencher;
                        //altera o val or da lista existente
                        infoPlaDtos.Where(p => p.Id.ToString() == item.Cells[TabMapColGrid.RecebedorLista.Key].Value.ToString()).ToList().ForEach(s => s.PlacerMapped = preencher);
                        //dataGridView1.Rows[rowIndexYouWant].Cells["ComboColumn"].Value = "1";
                    }
                }
            }


        }

        /// <summary> 
        /// create new collunms to bind form map
        /// </summary>
        private void AddColumPlace(List<PlaceCorresp> PlaceCorresp)
        {
            if (GridSales.InvokeRequired == true)
            {
                GridSales.Invoke(new Action(() =>
                {
                    foreach (DataGridViewRow item in GridSales.Rows)
                    {
                        DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(item.Cells[TabMapColGrid.BeneficiadorLista.Key]);
                        ContactCombo.DataSource = PlaceCorresp.Select(p => p.Description).ToArray();

                        //verifica se tem historico de mapeamento
                        if (item.Cells[TabMapColGrid.Beneficiador.Key].Value != null)
                        {
                            string preencher = Functions.GetValueintoListBeneficiador(deParaBeneficiadorDto, PlaceCorresp, item.Cells[TabMapColGrid.Beneficiador.Key].Value.ToString());
                            if (preencher != null)
                            {
                                item.Cells[TabMapColGrid.BeneficiadorLista.Key].ReadOnly = false;
                                item.Cells[TabMapColGrid.BeneficiadorMapeado.Key].ReadOnly = false;
                                item.Cells[TabMapColGrid.BeneficiadorLista.Key].Value = preencher;
                                item.Cells[TabMapColGrid.BeneficiadorMapeado.Key].Value = preencher;
                                //altera o valor da lista existente
                                infoPlaDtos.Where(p => p.Id.ToString() == item.Cells[TabMapColGrid.BeneficiadorLista.Key].Value.ToString()).ToList().ForEach(s => s.PlacerMapped = preencher);
                                //dataGridView1.Rows[rowIndexYouWant].Cells["ComboColumn"].Value = "1";
                            }
                        }
                        else
                        {
                            item.Cells[TabMapColGrid.BeneficiadorLista.Key].ReadOnly = true;
                            item.Cells[TabMapColGrid.BeneficiadorMapeado.Key].ReadOnly = true;
                        }
                    }
                }));
            }
            else
            {
                foreach (DataGridViewRow item in GridSales.Rows)
                {
                    DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(item.Cells[TabMapColGrid.BeneficiadorLista.Key]);
                    ContactCombo.DataSource = PlaceCorresp.Select(p => p.Description).ToArray();

                    //verifica se tem historico de mapeamento
                    if (item.Cells[TabMapColGrid.Beneficiador.Key].Value != null)
                    {
                        string preencher = Functions.GetValueintoListBeneficiador(deParaBeneficiadorDto, PlaceCorresp, item.Cells[TabMapColGrid.Beneficiador.Key].Value.ToString());
                        if (preencher != null)
                        {
                            item.Cells[TabMapColGrid.BeneficiadorLista.Key].ReadOnly = false;
                            item.Cells[TabMapColGrid.BeneficiadorMapeado.Key].ReadOnly = false;
                            item.Cells[TabMapColGrid.BeneficiadorLista.Key].Value = preencher;
                            item.Cells[TabMapColGrid.BeneficiadorMapeado.Key].Value = preencher;
                            //altera o valor da lista existente
                            infoPlaDtos.Where(p => p.Id.ToString() == item.Cells[TabMapColGrid.BeneficiadorLista.Key].Value.ToString()).ToList().ForEach(s => s.PlacerMapped = preencher);
                            //dataGridView1.Rows[rowIndexYouWant].Cells["ComboColumn"].Value = "1";
                        }
                    }
                    else
                    {
                        item.Cells[TabMapColGrid.BeneficiadorLista.Key].ReadOnly = true;
                        item.Cells[TabMapColGrid.BeneficiadorMapeado.Key].ReadOnly = true;
                    }
                }
            }
        }

        private string ValidGridToMap(int RowIndex)
        {
            string retstring = null;
            if (GridSales.Rows[RowIndex].Cells[TabMapColGrid.RecebedorLista.Key].Value == "" || GridSales.Rows[RowIndex].Cells[TabMapColGrid.RecebedorLista.Key].Value == null)
                retstring = string.Format("O campo {0} é obrigado a ter um recebedor mapeado, favor selecionar uma opção!", TabMapColGrid.Recebedor.Value);

            if (GridSales.Rows[RowIndex].Cells[TabMapColGrid.Beneficiador.Key].Value != null)
            {
                if (GridSales.Rows[RowIndex].Cells[TabMapColGrid.Beneficiador.Key].Value.ToString() != "")
                {
                    if (GridSales.Rows[RowIndex].Cells[TabMapColGrid.BeneficiadorLista.Key].Value == "" || GridSales.Rows[RowIndex].Cells[TabMapColGrid.BeneficiadorLista.Key].Value == null)
                    {
                        retstring += String.Format("O mapeamento do campo {0} é obrigado a ter um {1} mapeado, favor selecionar uma opção!", TabMapColGrid.BeneficiadorLista.Value, TabMapColGrid.Beneficiador.Value);
                    }
                }
            }

            return retstring;
        }

        private bool SelecionarValoresCombobox()
        {
            bool ValidGrd = true;
            for (int linha = 0; linha < GridSales.Rows.Count; linha++)
            {
                GridSales.Rows[linha].Cells[TabMapColGrid.Messagem.Key].Value = null;
                var validacao = ValidGridToMap(linha);
                if (validacao != null)
                {
                    GridSales.Rows[linha].Cells[TabMapColGrid.Messagem.Key].Value = validacao;
                    ValidGrd = false;
                }

            }
            return ValidGrd;
        }
        private void PreencherValoresColuna(string ColunaLista, string ColunaMapeada, string PreencherTexto, string FiltroCampo = null, string FiltroValor = null)
        {

            for (int linha = 0; linha < GridSales.Rows.Count; linha++)
            {

                if (FiltroCampo == null)
                {

                    GridSales.Rows[linha].Cells[ColunaLista].Value = PreencherTexto;
                    GridSales.Rows[linha].Cells[ColunaMapeada].Value = PreencherTexto;
                    if (ColunaLista == "RecebedorLista")
                    {
                        infoPlaDtos.Where(p => p.Id.ToString() == GridSales.Rows[linha].Cells[TabMapColGrid.Id.Key].Value.ToString()).ToList().ForEach(s => s.ReceiverMapped = PreencherTexto);
                    }
                    if (ColunaLista == "BeneficiadorLista")
                    {
                        infoPlaDtos.Where(p => p.Id.ToString() == GridSales.Rows[linha].Cells[TabMapColGrid.Id.Key].Value.ToString()).ToList().ForEach(s => s.PlacerMapped = PreencherTexto);
                    }
                }
                else if (GridSales.Rows[linha].Cells[FiltroCampo].Value.ToString() == FiltroValor)
                {
                    GridSales.Rows[linha].Cells[ColunaLista].Value = PreencherTexto;
                    GridSales.Rows[linha].Cells[ColunaMapeada].Value = PreencherTexto;
                    if (ColunaLista == "RecebedorLista")
                    {
                        infoPlaDtos.Where(p => p.Id.ToString() == GridSales.Rows[linha].Cells[TabMapColGrid.Id.Key].Value.ToString()).ToList().ForEach(s => s.ReceiverMapped = PreencherTexto);
                    }
                    if (ColunaLista == "BeneficiadorLista")
                    {
                        infoPlaDtos.Where(p => p.Id.ToString() == GridSales.Rows[linha].Cells[TabMapColGrid.Id.Key].Value.ToString()).ToList().ForEach(s => s.PlacerMapped = PreencherTexto);
                    }
                }
            }
        }

        #endregion

        #region//////// EventsGrid
        private void BtnIrParaCarrinho_Click(object sender, EventArgs e)
        {
            AbrirLoad("Montando carrinho...");
            if (SelecionarValoresCombobox() == false)
            {
                MessageBox.Show("Existem pendências no mapeamento!");

                FecharLoad("OvAbaCarrinhoTabela");

                return;
            }

            //caso exista novos mapeamentos, são salvos no banco
            var NovosMapeamentoBeneficiador = DeParaServices.NovosDeParaBeneficiador(deParaBeneficiadorDto, infoPlaDtos, auth.CurrentClient, auth.userName);

            var NovosMapeamentoRecebedor = DeParaServices.NovosDeParaRecebedor(deParaRecebedorDto, infoPlaDtos, auth.CurrentClient, auth.userName);

            PluginService pluginServices = new PluginService(auth);

            if (NovosMapeamentoBeneficiador != null && NovosMapeamentoBeneficiador.Count != 0)
                pluginServices.BeneficiadorDeParaPostAsync(NovosMapeamentoBeneficiador);

            if (NovosMapeamentoRecebedor != null && NovosMapeamentoRecebedor.Count != 0)
                pluginServices.RecebedorDeParaPostAsync(NovosMapeamentoRecebedor);

            PopulateItens();
            //SelectContext("OvAbaCarrinho");
            TabPopulateItens();

            //SelectContext("OvAbaCarrinhoTabela");

            FecharLoad("OvAbaCarrinhoTabela");
        }

        private void GridSales_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (GridSales.Columns[e.ColumnIndex].Name.Equals(TabMapColGrid.BeneficiadorLista.Key))
            {
                if (GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.Beneficiador.Key].Value != null)
                {
                    string novoValor = GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.BeneficiadorLista.Key].Value.ToString();
                    GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.BeneficiadorMapeado.Key].Value = novoValor;
                    infoPlaDtos.Where(p => p.Id.ToString() == GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.Id.Key].Value.ToString()).ToList().ForEach(s => s.PlacerMapped = novoValor);
                    //SelecionarValoresCombobox();
                }
            }

            if (GridSales.Columns[e.ColumnIndex].Name.Equals(TabMapColGrid.RecebedorLista.Key))
            {
                if (GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.Recebedor.Key].Value != null)
                {
                    string novoValor = GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.RecebedorLista.Key].Value.ToString();
                    GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.RecebedorMapeado.Key].Value = novoValor;
                    infoPlaDtos.Where(p => p.Id.ToString() == GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.Id.Key].Value.ToString()).ToList().ForEach(s => s.ReceiverMapped = novoValor);
                    //SelecionarValoresCombobox();
                }
            }
            //GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.Messagem.Key].Value = ValidGridToMap(e).ToString();
        }

        private void GridSales_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (GridSales.Columns[e.ColumnIndex].Name.Equals(TabMapColGrid.BeneficiadorLista.Key))
            {

                if (GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.BeneficiadorLista.Key].Value != null)
                {
                    F_AutoComplet autoComplet = new F_AutoComplet();
                    var acao = autoComplet.ShowDialog();
                    string novoValor;
                    switch (autoComplet.valor)
                    {
                        case 1:
                            novoValor = GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.BeneficiadorLista.Key].Value.ToString();
                            PreencherValoresColuna(TabMapColGrid.BeneficiadorLista.Key, TabMapColGrid.BeneficiadorMapeado.Key, GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.BeneficiadorLista.Key].Value.ToString());
                            break;
                        case 2:
                            novoValor = GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.BeneficiadorLista.Key].Value.ToString();
                            PreencherValoresColuna(TabMapColGrid.BeneficiadorLista.Key, TabMapColGrid.BeneficiadorMapeado.Key, GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.BeneficiadorLista.Key].Value.ToString(), TabMapColGrid.Beneficiador.Key, GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.Beneficiador.Value].Value.ToString());
                            break;
                    }

                }
            }

            if (GridSales.Columns[e.ColumnIndex].Name.Equals(TabMapColGrid.RecebedorLista.Key))
            {

                if (GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.RecebedorLista.Key].Value != null)
                {
                    F_AutoComplet autoComplet = new F_AutoComplet();
                    var acao = autoComplet.ShowDialog();
                    string novoValor;
                    switch (autoComplet.valor)
                    {
                        case 1:
                            novoValor = GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.RecebedorLista.Key].Value.ToString();
                            PreencherValoresColuna(TabMapColGrid.RecebedorLista.Key, TabMapColGrid.RecebedorMapeado.Key, GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.RecebedorLista.Key].Value.ToString());
                            break;
                        case 2:
                            novoValor = GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.RecebedorLista.Key].Value.ToString();
                            PreencherValoresColuna(TabMapColGrid.RecebedorLista.Key, TabMapColGrid.RecebedorMapeado.Key, GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.RecebedorLista.Key].Value.ToString(), TabMapColGrid.Recebedor.Key, GridSales.Rows[e.RowIndex].Cells[TabMapColGrid.Recebedor.Value].Value.ToString());
                            break;

                    }
                }
            }
        }
        #endregion

        #endregion

        #region Funcionalidades

        /// <summary>
        /// validate if user are autorized
        /// </summary>
        public bool ValidLogin()
        {
            if (auth.Token == null)
            {
                if (this.TabControl.Controls.Contains(OvAbaDados) == true)
                {
                    this.TabControl.Controls.Remove(this.OvAbaDados);
                    this.TabControl.Controls.Remove(this.OvAbaConfiguracao);
                }
                OvAbaConfiguracao.Focus();
                SelectContext(this.OvAbaConfiguracao.ToString());
                return false;
            }
            else
            {
                if (this.TabControl.Controls.Contains(OvAbaDados) == false)
                {
                    this.TabControl.Controls.Add(this.OvAbaDados);
                }
                TabControl.SelectedTab = OvAbaDados;
                return true;
            }
        }
     
        public void SelectContext(string context)
        {

            foreach (TabPage item in this.TabControl.TabPages)
            {
                if (item.Name.Equals(context))
                {
                    if (TabControl.InvokeRequired)
                    {
                        TabControl.Invoke(new Action(() =>
                        {
                            TabControl.SelectedTab = item;
                        }
                        ));
                    }
                    else
                    {
                        TabControl.SelectedTab = item;
                    }
                }
            }
        }
        public void NameClienteForm(string Nome)
        {
            if (OvLbClientePedido.InvokeRequired == true)
            {
                OvLbClientePedido.Invoke(new Action(() =>
                {
                    OvLbClientePedido.Text = "Olá " + Nome + "!";
                    OvLbClientePedido.Visible = true;
                }));
            }
            else
            {
                OvLbClientePedido.Text = "Olá " + Nome + "!";
                OvLbClientePedido.Visible = true;
            }
        }

        public void AbrirLoad(string textoLoad)
        {
            
            foreach (ListAbas Aba in ListAbas)
            {
                if (Aba.Tab.Name.ToString() != "OvAbaLoad")
                {

                    if (TabControl.InvokeRequired)
                    {
                        TabControl.Invoke(new Action(() =>
                        {
                            Aba.Tab.Hide();
                        }));
                    }
                    else
                    {
                        Aba.Tab.Hide();
                    }
                }
                else
                {
                    if (TabControl.InvokeRequired)
                    {
                        TabControl.Invoke(new Action(() =>
                        {
                            this.TabControl.Controls.Add(Aba.Tab);
                            Aba.Tab.Show();
                            Aba.Tab.Text = textoLoad;
                        }));
                    }
                    else
                    {
                        this.TabControl.Controls.Add(Aba.Tab);
                        Aba.Tab.Text = textoLoad;
                        Aba.Tab.Show();
                    }
                }
            }
            SelectContext("OvAbaLoad");
        }
        public void FecharLoad(string SelecionarAba)
        {
            foreach (ListAbas Aba in ListAbas)
            {
                if (Aba.Tab.Name.ToString() != "OvAbaLoad")
                {

                    if (TabControl.InvokeRequired)
                    {
                        TabControl.Invoke(new Action(() =>
                        {
                            Aba.Tab.Show();
                        }));
                    }
                    else
                    {
                        Aba.Tab.Show();
                    }
                }
                else
                {
                    if (TabControl.InvokeRequired)
                    {
                        TabControl.Invoke(new Action(() =>
                        {
                            Aba.Tab.Hide();
                            this.TabControl.Controls.Remove(Aba.Tab);
                        }));
                    }
                    else
                    {
                        Aba.Tab.Hide();
                        this.TabControl.Controls.Remove(Aba.Tab);
                    }
                }
            }
            SelectContext(SelecionarAba);
        }

        #endregion
    }
}


