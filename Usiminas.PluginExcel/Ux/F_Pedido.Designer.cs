using System.Windows.Forms;

namespace Usiminas.PluginExcel.Ux
{
    partial class F_Pedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Pedido));
            this.FPTimer = new System.Windows.Forms.Timer(this.components);
            this.TabControl = new System.Windows.Forms.TabControl();
            this.OvAbaConfiguracao = new System.Windows.Forms.TabPage();
            this.ObBtnChosenClient = new System.Windows.Forms.Button();
            this.OvLbClienteGrupo = new System.Windows.Forms.Label();
            this.ObCbClienteGrupo = new System.Windows.Forms.ComboBox();
            this.OvBtnLogin = new System.Windows.Forms.Button();
            this.OpLbSenha = new System.Windows.Forms.Label();
            this.OvTxSenha = new System.Windows.Forms.TextBox();
            this.OvLbLogin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OvTxLogin = new System.Windows.Forms.TextBox();
            this.OvAbaDados = new System.Windows.Forms.TabPage();
            this.OvFrCampos = new System.Windows.Forms.GroupBox();
            this.OvLbPeriodoDesejado = new System.Windows.Forms.Label();
            this.DtPrazoDesejado = new System.Windows.Forms.DateTimePicker();
            this.OvBtnClassTonelagemD3Cancel = new System.Windows.Forms.Button();
            this.OvRdTonelagemD3 = new System.Windows.Forms.RadioButton();
            this.OvBtnClassTonelagemD3 = new System.Windows.Forms.Button();
            this.OvTxSelecaoTonelagemD3 = new System.Windows.Forms.TextBox();
            this.OvBtnClassTonelagemD2Cancel = new System.Windows.Forms.Button();
            this.OvRdTonelagemD2 = new System.Windows.Forms.RadioButton();
            this.OvBtnClassTonelagemD2 = new System.Windows.Forms.Button();
            this.OvTxSelecaoTonelagemD2 = new System.Windows.Forms.TextBox();
            this.OvBtnClassTonelagemD1Cancel = new System.Windows.Forms.Button();
            this.OvBtnClassPeriodoCancel = new System.Windows.Forms.Button();
            this.OvBtnClassLocalEntregaCancel = new System.Windows.Forms.Button();
            this.OvBtnClassRecebedorCancel = new System.Windows.Forms.Button();
            this.OvBtnClassRefClienteCancel = new System.Windows.Forms.Button();
            this.OvRdnull = new System.Windows.Forms.RadioButton();
            this.OvRdTonelagemD1 = new System.Windows.Forms.RadioButton();
            this.OvRdPerioDesejado = new System.Windows.Forms.RadioButton();
            this.OvRdLocalEntrega = new System.Windows.Forms.RadioButton();
            this.OvRdRecebedor = new System.Windows.Forms.RadioButton();
            this.OvRdRefCliente = new System.Windows.Forms.RadioButton();
            this.OvBtnClassTonelagemD1 = new System.Windows.Forms.Button();
            this.OvBtnClassPeriodo = new System.Windows.Forms.Button();
            this.OvBtnClassLocalEntrega = new System.Windows.Forms.Button();
            this.OvBtnClassRecebedor = new System.Windows.Forms.Button();
            this.OvBtnClassRefCliente = new System.Windows.Forms.Button();
            this.OvTxSelecaoTonelagemD1 = new System.Windows.Forms.TextBox();
            this.OvTxSelecaoPeriodo = new System.Windows.Forms.TextBox();
            this.OvTxSelecaoLocalEntrega = new System.Windows.Forms.TextBox();
            this.OvTxSelecaoRecebedor = new System.Windows.Forms.TextBox();
            this.OvTxSelecaoRefCliente = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.OvBtnProcessSale = new System.Windows.Forms.Button();
            this.OvAbaPedido = new System.Windows.Forms.TabPage();
            this.BtnIrParaCarrinho = new System.Windows.Forms.Button();
            this.GridSales = new System.Windows.Forms.DataGridView();
            this.PartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recebedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecebedorMapeado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecebedorLista = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Beneficiador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeneficiadorMapeado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeneficiadorLista = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Mensagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.OvAbaCarrinho = new System.Windows.Forms.TabPage();
            this.OvLbTotalToneContFinal = new System.Windows.Forms.Label();
            this.OvLbTotalToneFinal = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.OvLbTotalToneCont = new System.Windows.Forms.Label();
            this.OvLbTotalToneMap = new System.Windows.Forms.Label();
            this.OvLbTotalItemCont = new System.Windows.Forms.Label();
            this.OvLbTotalItem = new System.Windows.Forms.Label();
            this.BtnEnviarPedido = new System.Windows.Forms.Button();
            this.flowLayoutPanelCarrinho = new System.Windows.Forms.FlowLayoutPanel();
            this.OvLbClientePedido = new System.Windows.Forms.Label();
            this.OvAbaCarrinhoTab = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DecMap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabControl.SuspendLayout();
            this.OvAbaConfiguracao.SuspendLayout();
            this.OvAbaDados.SuspendLayout();
            this.OvFrCampos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.OvAbaPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridSales)).BeginInit();
            this.OvAbaCarrinho.SuspendLayout();
            this.OvAbaCarrinhoTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // FPTimer
            // 
            this.FPTimer.Enabled = true;
            this.FPTimer.Tick += new System.EventHandler(this.FPTimer_Tick);
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.OvAbaConfiguracao);
            this.TabControl.Controls.Add(this.OvAbaDados);
            this.TabControl.Controls.Add(this.OvAbaPedido);
            this.TabControl.Controls.Add(this.OvAbaCarrinho);
            this.TabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl.Location = new System.Drawing.Point(14, 42);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.ShowToolTips = true;
            this.TabControl.Size = new System.Drawing.Size(1051, 760);
            this.TabControl.TabIndex = 0;
            this.TabControl.Tag = "";
            // 
            // OvAbaConfiguracao
            // 
            this.OvAbaConfiguracao.Controls.Add(this.ObBtnChosenClient);
            this.OvAbaConfiguracao.Controls.Add(this.OvLbClienteGrupo);
            this.OvAbaConfiguracao.Controls.Add(this.ObCbClienteGrupo);
            this.OvAbaConfiguracao.Controls.Add(this.OvBtnLogin);
            this.OvAbaConfiguracao.Controls.Add(this.OpLbSenha);
            this.OvAbaConfiguracao.Controls.Add(this.OvTxSenha);
            this.OvAbaConfiguracao.Controls.Add(this.OvLbLogin);
            this.OvAbaConfiguracao.Controls.Add(this.label1);
            this.OvAbaConfiguracao.Controls.Add(this.OvTxLogin);
            this.OvAbaConfiguracao.Location = new System.Drawing.Point(4, 27);
            this.OvAbaConfiguracao.Name = "OvAbaConfiguracao";
            this.OvAbaConfiguracao.Padding = new System.Windows.Forms.Padding(3);
            this.OvAbaConfiguracao.Size = new System.Drawing.Size(1043, 729);
            this.OvAbaConfiguracao.TabIndex = 0;
            this.OvAbaConfiguracao.Text = "Configuracao";
            this.OvAbaConfiguracao.UseVisualStyleBackColor = true;
            // 
            // ObBtnChosenClient
            // 
            this.ObBtnChosenClient.Location = new System.Drawing.Point(792, 96);
            this.ObBtnChosenClient.Name = "ObBtnChosenClient";
            this.ObBtnChosenClient.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ObBtnChosenClient.Size = new System.Drawing.Size(155, 32);
            this.ObBtnChosenClient.TabIndex = 20;
            this.ObBtnChosenClient.Text = "Escolher cliente";
            this.ObBtnChosenClient.UseVisualStyleBackColor = true;
            this.ObBtnChosenClient.Visible = false;
            this.ObBtnChosenClient.Click += new System.EventHandler(this.ObBtnChosenClient_Click);
            // 
            // OvLbClienteGrupo
            // 
            this.OvLbClienteGrupo.AutoSize = true;
            this.OvLbClienteGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.OvLbClienteGrupo.Location = new System.Drawing.Point(346, 64);
            this.OvLbClienteGrupo.Name = "OvLbClienteGrupo";
            this.OvLbClienteGrupo.Size = new System.Drawing.Size(115, 17);
            this.OvLbClienteGrupo.TabIndex = 19;
            this.OvLbClienteGrupo.Text = "Escolha o cliente";
            // 
            // ObCbClienteGrupo
            // 
            this.ObCbClienteGrupo.DropDownWidth = 571;
            this.ObCbClienteGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObCbClienteGrupo.FormattingEnabled = true;
            this.ObCbClienteGrupo.Location = new System.Drawing.Point(349, 98);
            this.ObCbClienteGrupo.Name = "ObCbClienteGrupo";
            this.ObCbClienteGrupo.Size = new System.Drawing.Size(400, 23);
            this.ObCbClienteGrupo.TabIndex = 18;
            this.ObCbClienteGrupo.SelectedValueChanged += new System.EventHandler(this.ObCbClienteGrupo_SelectedValueChanged);
            // 
            // OvBtnLogin
            // 
            this.OvBtnLogin.Location = new System.Drawing.Point(149, 154);
            this.OvBtnLogin.Name = "OvBtnLogin";
            this.OvBtnLogin.Size = new System.Drawing.Size(75, 32);
            this.OvBtnLogin.TabIndex = 17;
            this.OvBtnLogin.Text = "Login";
            this.OvBtnLogin.UseVisualStyleBackColor = true;
            this.OvBtnLogin.Click += new System.EventHandler(this.OvBtnLogin_Click);
            // 
            // OpLbSenha
            // 
            this.OpLbSenha.AutoSize = true;
            this.OpLbSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.OpLbSenha.Location = new System.Drawing.Point(57, 107);
            this.OpLbSenha.Name = "OpLbSenha";
            this.OpLbSenha.Size = new System.Drawing.Size(49, 17);
            this.OpLbSenha.TabIndex = 16;
            this.OpLbSenha.Text = "Senha";
            // 
            // OvTxSenha
            // 
            this.OvTxSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvTxSenha.Location = new System.Drawing.Point(124, 107);
            this.OvTxSenha.Name = "OvTxSenha";
            this.OvTxSenha.Size = new System.Drawing.Size(100, 21);
            this.OvTxSenha.TabIndex = 15;
            this.OvTxSenha.UseSystemPasswordChar = true;
            // 
            // OvLbLogin
            // 
            this.OvLbLogin.AutoSize = true;
            this.OvLbLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.OvLbLogin.Location = new System.Drawing.Point(57, 62);
            this.OvLbLogin.Name = "OvLbLogin";
            this.OvLbLogin.Size = new System.Drawing.Size(43, 17);
            this.OvLbLogin.TabIndex = 3;
            this.OvLbLogin.Text = "Login";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // OvTxLogin
            // 
            this.OvTxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvTxLogin.Location = new System.Drawing.Point(124, 62);
            this.OvTxLogin.Name = "OvTxLogin";
            this.OvTxLogin.Size = new System.Drawing.Size(100, 21);
            this.OvTxLogin.TabIndex = 2;
            // 
            // OvAbaDados
            // 
            this.OvAbaDados.Controls.Add(this.OvFrCampos);
            this.OvAbaDados.Controls.Add(this.pictureBox1);
            this.OvAbaDados.Controls.Add(this.OvBtnProcessSale);
            this.OvAbaDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvAbaDados.Location = new System.Drawing.Point(4, 27);
            this.OvAbaDados.Name = "OvAbaDados";
            this.OvAbaDados.Padding = new System.Windows.Forms.Padding(3);
            this.OvAbaDados.Size = new System.Drawing.Size(1043, 729);
            this.OvAbaDados.TabIndex = 1;
            this.OvAbaDados.Text = "Dados";
            this.OvAbaDados.UseVisualStyleBackColor = true;
            // 
            // OvFrCampos
            // 
            this.OvFrCampos.Controls.Add(this.OvLbPeriodoDesejado);
            this.OvFrCampos.Controls.Add(this.DtPrazoDesejado);
            this.OvFrCampos.Controls.Add(this.OvBtnClassTonelagemD3Cancel);
            this.OvFrCampos.Controls.Add(this.OvRdTonelagemD3);
            this.OvFrCampos.Controls.Add(this.OvBtnClassTonelagemD3);
            this.OvFrCampos.Controls.Add(this.OvTxSelecaoTonelagemD3);
            this.OvFrCampos.Controls.Add(this.OvBtnClassTonelagemD2Cancel);
            this.OvFrCampos.Controls.Add(this.OvRdTonelagemD2);
            this.OvFrCampos.Controls.Add(this.OvBtnClassTonelagemD2);
            this.OvFrCampos.Controls.Add(this.OvTxSelecaoTonelagemD2);
            this.OvFrCampos.Controls.Add(this.OvBtnClassTonelagemD1Cancel);
            this.OvFrCampos.Controls.Add(this.OvBtnClassPeriodoCancel);
            this.OvFrCampos.Controls.Add(this.OvBtnClassLocalEntregaCancel);
            this.OvFrCampos.Controls.Add(this.OvBtnClassRecebedorCancel);
            this.OvFrCampos.Controls.Add(this.OvBtnClassRefClienteCancel);
            this.OvFrCampos.Controls.Add(this.OvRdnull);
            this.OvFrCampos.Controls.Add(this.OvRdTonelagemD1);
            this.OvFrCampos.Controls.Add(this.OvRdPerioDesejado);
            this.OvFrCampos.Controls.Add(this.OvRdLocalEntrega);
            this.OvFrCampos.Controls.Add(this.OvRdRecebedor);
            this.OvFrCampos.Controls.Add(this.OvRdRefCliente);
            this.OvFrCampos.Controls.Add(this.OvBtnClassTonelagemD1);
            this.OvFrCampos.Controls.Add(this.OvBtnClassPeriodo);
            this.OvFrCampos.Controls.Add(this.OvBtnClassLocalEntrega);
            this.OvFrCampos.Controls.Add(this.OvBtnClassRecebedor);
            this.OvFrCampos.Controls.Add(this.OvBtnClassRefCliente);
            this.OvFrCampos.Controls.Add(this.OvTxSelecaoTonelagemD1);
            this.OvFrCampos.Controls.Add(this.OvTxSelecaoPeriodo);
            this.OvFrCampos.Controls.Add(this.OvTxSelecaoLocalEntrega);
            this.OvFrCampos.Controls.Add(this.OvTxSelecaoRecebedor);
            this.OvFrCampos.Controls.Add(this.OvTxSelecaoRefCliente);
            this.OvFrCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvFrCampos.Location = new System.Drawing.Point(15, 21);
            this.OvFrCampos.Name = "OvFrCampos";
            this.OvFrCampos.Size = new System.Drawing.Size(522, 503);
            this.OvFrCampos.TabIndex = 18;
            this.OvFrCampos.TabStop = false;
            this.OvFrCampos.Text = "Campos";
            // 
            // OvLbPeriodoDesejado
            // 
            this.OvLbPeriodoDesejado.AutoSize = true;
            this.OvLbPeriodoDesejado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.OvLbPeriodoDesejado.Location = new System.Drawing.Point(32, 315);
            this.OvLbPeriodoDesejado.Name = "OvLbPeriodoDesejado";
            this.OvLbPeriodoDesejado.Size = new System.Drawing.Size(122, 20);
            this.OvLbPeriodoDesejado.TabIndex = 50;
            this.OvLbPeriodoDesejado.Text = "Prazo Desejado";
            // 
            // DtPrazoDesejado
            // 
            this.DtPrazoDesejado.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtPrazoDesejado.CustomFormat = "MM-yyyy";
            this.DtPrazoDesejado.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.DtPrazoDesejado.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtPrazoDesejado.Location = new System.Drawing.Point(209, 315);
            this.DtPrazoDesejado.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.DtPrazoDesejado.Name = "DtPrazoDesejado";
            this.DtPrazoDesejado.Size = new System.Drawing.Size(100, 27);
            this.DtPrazoDesejado.TabIndex = 49;
            // 
            // OvBtnClassTonelagemD3Cancel
            // 
            this.OvBtnClassTonelagemD3Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvBtnClassTonelagemD3Cancel.Location = new System.Drawing.Point(424, 266);
            this.OvBtnClassTonelagemD3Cancel.Name = "OvBtnClassTonelagemD3Cancel";
            this.OvBtnClassTonelagemD3Cancel.Size = new System.Drawing.Size(75, 23);
            this.OvBtnClassTonelagemD3Cancel.TabIndex = 48;
            this.OvBtnClassTonelagemD3Cancel.Text = "Cancelar";
            this.OvBtnClassTonelagemD3Cancel.UseVisualStyleBackColor = true;
            this.OvBtnClassTonelagemD3Cancel.Click += new System.EventHandler(this.OvBtnClassTonelagemD3Cancel_Click);
            // 
            // OvRdTonelagemD3
            // 
            this.OvRdTonelagemD3.AutoSize = true;
            this.OvRdTonelagemD3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvRdTonelagemD3.Location = new System.Drawing.Point(25, 267);
            this.OvRdTonelagemD3.Name = "OvRdTonelagemD3";
            this.OvRdTonelagemD3.Size = new System.Drawing.Size(131, 24);
            this.OvRdTonelagemD3.TabIndex = 47;
            this.OvRdTonelagemD3.Text = "Tonelagem D3";
            this.OvRdTonelagemD3.UseVisualStyleBackColor = true;
            this.OvRdTonelagemD3.CheckedChanged += new System.EventHandler(this.OvRdTonelagemD3_CheckedChanged);
            // 
            // OvBtnClassTonelagemD3
            // 
            this.OvBtnClassTonelagemD3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvBtnClassTonelagemD3.Location = new System.Drawing.Point(334, 267);
            this.OvBtnClassTonelagemD3.Name = "OvBtnClassTonelagemD3";
            this.OvBtnClassTonelagemD3.Size = new System.Drawing.Size(75, 23);
            this.OvBtnClassTonelagemD3.TabIndex = 46;
            this.OvBtnClassTonelagemD3.Text = "Classificar";
            this.OvBtnClassTonelagemD3.UseVisualStyleBackColor = true;
            this.OvBtnClassTonelagemD3.Click += new System.EventHandler(this.OvBtnClassTonelagemD3_Click);
            // 
            // OvTxSelecaoTonelagemD3
            // 
            this.OvTxSelecaoTonelagemD3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvTxSelecaoTonelagemD3.Location = new System.Drawing.Point(209, 267);
            this.OvTxSelecaoTonelagemD3.Name = "OvTxSelecaoTonelagemD3";
            this.OvTxSelecaoTonelagemD3.ReadOnly = true;
            this.OvTxSelecaoTonelagemD3.Size = new System.Drawing.Size(100, 21);
            this.OvTxSelecaoTonelagemD3.TabIndex = 45;
            // 
            // OvBtnClassTonelagemD2Cancel
            // 
            this.OvBtnClassTonelagemD2Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvBtnClassTonelagemD2Cancel.Location = new System.Drawing.Point(424, 221);
            this.OvBtnClassTonelagemD2Cancel.Name = "OvBtnClassTonelagemD2Cancel";
            this.OvBtnClassTonelagemD2Cancel.Size = new System.Drawing.Size(75, 23);
            this.OvBtnClassTonelagemD2Cancel.TabIndex = 44;
            this.OvBtnClassTonelagemD2Cancel.Text = "Cancelar";
            this.OvBtnClassTonelagemD2Cancel.UseVisualStyleBackColor = true;
            this.OvBtnClassTonelagemD2Cancel.Click += new System.EventHandler(this.OvBtnClassTonelagemD2Cancel_Click);
            // 
            // OvRdTonelagemD2
            // 
            this.OvRdTonelagemD2.AutoSize = true;
            this.OvRdTonelagemD2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvRdTonelagemD2.Location = new System.Drawing.Point(25, 222);
            this.OvRdTonelagemD2.Name = "OvRdTonelagemD2";
            this.OvRdTonelagemD2.Size = new System.Drawing.Size(131, 24);
            this.OvRdTonelagemD2.TabIndex = 43;
            this.OvRdTonelagemD2.Text = "Tonelagem D2";
            this.OvRdTonelagemD2.UseVisualStyleBackColor = true;
            this.OvRdTonelagemD2.CheckedChanged += new System.EventHandler(this.OvRdTonelagemD2_CheckedChanged);
            // 
            // OvBtnClassTonelagemD2
            // 
            this.OvBtnClassTonelagemD2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvBtnClassTonelagemD2.Location = new System.Drawing.Point(334, 222);
            this.OvBtnClassTonelagemD2.Name = "OvBtnClassTonelagemD2";
            this.OvBtnClassTonelagemD2.Size = new System.Drawing.Size(75, 23);
            this.OvBtnClassTonelagemD2.TabIndex = 42;
            this.OvBtnClassTonelagemD2.Text = "Classificar";
            this.OvBtnClassTonelagemD2.UseVisualStyleBackColor = true;
            this.OvBtnClassTonelagemD2.Click += new System.EventHandler(this.OvBtnClassTonelagemD2_Click);
            // 
            // OvTxSelecaoTonelagemD2
            // 
            this.OvTxSelecaoTonelagemD2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvTxSelecaoTonelagemD2.Location = new System.Drawing.Point(209, 222);
            this.OvTxSelecaoTonelagemD2.Name = "OvTxSelecaoTonelagemD2";
            this.OvTxSelecaoTonelagemD2.ReadOnly = true;
            this.OvTxSelecaoTonelagemD2.Size = new System.Drawing.Size(100, 21);
            this.OvTxSelecaoTonelagemD2.TabIndex = 41;
            // 
            // OvBtnClassTonelagemD1Cancel
            // 
            this.OvBtnClassTonelagemD1Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvBtnClassTonelagemD1Cancel.Location = new System.Drawing.Point(424, 173);
            this.OvBtnClassTonelagemD1Cancel.Name = "OvBtnClassTonelagemD1Cancel";
            this.OvBtnClassTonelagemD1Cancel.Size = new System.Drawing.Size(75, 23);
            this.OvBtnClassTonelagemD1Cancel.TabIndex = 40;
            this.OvBtnClassTonelagemD1Cancel.Text = "Cancelar";
            this.OvBtnClassTonelagemD1Cancel.UseVisualStyleBackColor = true;
            this.OvBtnClassTonelagemD1Cancel.Click += new System.EventHandler(this.OvBtnClassTonelagemCancel_Click);
            // 
            // OvBtnClassPeriodoCancel
            // 
            this.OvBtnClassPeriodoCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvBtnClassPeriodoCancel.Location = new System.Drawing.Point(424, 365);
            this.OvBtnClassPeriodoCancel.Name = "OvBtnClassPeriodoCancel";
            this.OvBtnClassPeriodoCancel.Size = new System.Drawing.Size(75, 23);
            this.OvBtnClassPeriodoCancel.TabIndex = 39;
            this.OvBtnClassPeriodoCancel.Text = "Cancelar";
            this.OvBtnClassPeriodoCancel.UseVisualStyleBackColor = true;
            this.OvBtnClassPeriodoCancel.Visible = false;
            this.OvBtnClassPeriodoCancel.Click += new System.EventHandler(this.OvBtnClassPeriodoCancel_Click);
            // 
            // OvBtnClassLocalEntregaCancel
            // 
            this.OvBtnClassLocalEntregaCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvBtnClassLocalEntregaCancel.Location = new System.Drawing.Point(424, 131);
            this.OvBtnClassLocalEntregaCancel.Name = "OvBtnClassLocalEntregaCancel";
            this.OvBtnClassLocalEntregaCancel.Size = new System.Drawing.Size(75, 23);
            this.OvBtnClassLocalEntregaCancel.TabIndex = 38;
            this.OvBtnClassLocalEntregaCancel.Text = "Cancelar";
            this.OvBtnClassLocalEntregaCancel.UseVisualStyleBackColor = true;
            this.OvBtnClassLocalEntregaCancel.Click += new System.EventHandler(this.OvBtnClassLocalEntregaCancel_Click);
            // 
            // OvBtnClassRecebedorCancel
            // 
            this.OvBtnClassRecebedorCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvBtnClassRecebedorCancel.Location = new System.Drawing.Point(424, 86);
            this.OvBtnClassRecebedorCancel.Name = "OvBtnClassRecebedorCancel";
            this.OvBtnClassRecebedorCancel.Size = new System.Drawing.Size(75, 23);
            this.OvBtnClassRecebedorCancel.TabIndex = 37;
            this.OvBtnClassRecebedorCancel.Text = "Cancelar";
            this.OvBtnClassRecebedorCancel.UseVisualStyleBackColor = true;
            this.OvBtnClassRecebedorCancel.Click += new System.EventHandler(this.OvBtnClassRecebedorCancel_Click);
            // 
            // OvBtnClassRefClienteCancel
            // 
            this.OvBtnClassRefClienteCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvBtnClassRefClienteCancel.Location = new System.Drawing.Point(424, 41);
            this.OvBtnClassRefClienteCancel.Name = "OvBtnClassRefClienteCancel";
            this.OvBtnClassRefClienteCancel.Size = new System.Drawing.Size(75, 23);
            this.OvBtnClassRefClienteCancel.TabIndex = 36;
            this.OvBtnClassRefClienteCancel.Text = "Cancelar";
            this.OvBtnClassRefClienteCancel.UseVisualStyleBackColor = true;
            this.OvBtnClassRefClienteCancel.Click += new System.EventHandler(this.OvBtnClassRefClienteCancel_Click);
            // 
            // OvRdnull
            // 
            this.OvRdnull.AutoSize = true;
            this.OvRdnull.Checked = true;
            this.OvRdnull.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvRdnull.Location = new System.Drawing.Point(25, 412);
            this.OvRdnull.Name = "OvRdnull";
            this.OvRdnull.Size = new System.Drawing.Size(101, 24);
            this.OvRdnull.TabIndex = 35;
            this.OvRdnull.TabStop = true;
            this.OvRdnull.Text = "sem editar";
            this.OvRdnull.UseVisualStyleBackColor = false;
            this.OvRdnull.Visible = false;
            this.OvRdnull.CheckedChanged += new System.EventHandler(this.OvRdnull_CheckedChanged);
            // 
            // OvRdTonelagemD1
            // 
            this.OvRdTonelagemD1.AutoSize = true;
            this.OvRdTonelagemD1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvRdTonelagemD1.Location = new System.Drawing.Point(25, 174);
            this.OvRdTonelagemD1.Name = "OvRdTonelagemD1";
            this.OvRdTonelagemD1.Size = new System.Drawing.Size(131, 24);
            this.OvRdTonelagemD1.TabIndex = 34;
            this.OvRdTonelagemD1.Text = "Tonelagem D1";
            this.OvRdTonelagemD1.UseVisualStyleBackColor = true;
            this.OvRdTonelagemD1.CheckedChanged += new System.EventHandler(this.OvRdTonelagem_CheckedChanged);
            // 
            // OvRdPerioDesejado
            // 
            this.OvRdPerioDesejado.AutoSize = true;
            this.OvRdPerioDesejado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvRdPerioDesejado.Location = new System.Drawing.Point(25, 368);
            this.OvRdPerioDesejado.Name = "OvRdPerioDesejado";
            this.OvRdPerioDesejado.Size = new System.Drawing.Size(140, 24);
            this.OvRdPerioDesejado.TabIndex = 33;
            this.OvRdPerioDesejado.Text = "Prazo Desejado";
            this.OvRdPerioDesejado.UseVisualStyleBackColor = true;
            this.OvRdPerioDesejado.Visible = false;
            this.OvRdPerioDesejado.CheckedChanged += new System.EventHandler(this.OvRdPerioDesejado_CheckedChanged);
            // 
            // OvRdLocalEntrega
            // 
            this.OvRdLocalEntrega.AutoSize = true;
            this.OvRdLocalEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvRdLocalEntrega.Location = new System.Drawing.Point(25, 134);
            this.OvRdLocalEntrega.Name = "OvRdLocalEntrega";
            this.OvRdLocalEntrega.Size = new System.Drawing.Size(116, 24);
            this.OvRdLocalEntrega.TabIndex = 32;
            this.OvRdLocalEntrega.Text = "Beneficiador";
            this.OvRdLocalEntrega.UseVisualStyleBackColor = true;
            this.OvRdLocalEntrega.CheckedChanged += new System.EventHandler(this.OvRdLocalEntrega_CheckedChanged);
            // 
            // OvRdRecebedor
            // 
            this.OvRdRecebedor.AutoSize = true;
            this.OvRdRecebedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvRdRecebedor.Location = new System.Drawing.Point(25, 88);
            this.OvRdRecebedor.Name = "OvRdRecebedor";
            this.OvRdRecebedor.Size = new System.Drawing.Size(106, 24);
            this.OvRdRecebedor.TabIndex = 31;
            this.OvRdRecebedor.Text = "Recebedor";
            this.OvRdRecebedor.UseVisualStyleBackColor = true;
            this.OvRdRecebedor.CheckedChanged += new System.EventHandler(this.OvRdRecebedor_CheckedChanged);
            // 
            // OvRdRefCliente
            // 
            this.OvRdRefCliente.AutoSize = true;
            this.OvRdRefCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvRdRefCliente.Location = new System.Drawing.Point(25, 42);
            this.OvRdRefCliente.Name = "OvRdRefCliente";
            this.OvRdRefCliente.Size = new System.Drawing.Size(116, 24);
            this.OvRdRefCliente.TabIndex = 30;
            this.OvRdRefCliente.Text = "Part Number";
            this.OvRdRefCliente.UseVisualStyleBackColor = true;
            this.OvRdRefCliente.CheckedChanged += new System.EventHandler(this.OvRdRefCliente_CheckedChanged);
            // 
            // OvBtnClassTonelagemD1
            // 
            this.OvBtnClassTonelagemD1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvBtnClassTonelagemD1.Location = new System.Drawing.Point(334, 174);
            this.OvBtnClassTonelagemD1.Name = "OvBtnClassTonelagemD1";
            this.OvBtnClassTonelagemD1.Size = new System.Drawing.Size(75, 23);
            this.OvBtnClassTonelagemD1.TabIndex = 29;
            this.OvBtnClassTonelagemD1.Text = "Classificar";
            this.OvBtnClassTonelagemD1.UseVisualStyleBackColor = true;
            this.OvBtnClassTonelagemD1.Click += new System.EventHandler(this.OvBtnClassTonelagemD1_Click);
            // 
            // OvBtnClassPeriodo
            // 
            this.OvBtnClassPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvBtnClassPeriodo.Location = new System.Drawing.Point(334, 366);
            this.OvBtnClassPeriodo.Name = "OvBtnClassPeriodo";
            this.OvBtnClassPeriodo.Size = new System.Drawing.Size(75, 23);
            this.OvBtnClassPeriodo.TabIndex = 28;
            this.OvBtnClassPeriodo.Text = "Classificar";
            this.OvBtnClassPeriodo.UseVisualStyleBackColor = true;
            this.OvBtnClassPeriodo.Visible = false;
            this.OvBtnClassPeriodo.Click += new System.EventHandler(this.OvBtnClassPeriodo_Click);
            // 
            // OvBtnClassLocalEntrega
            // 
            this.OvBtnClassLocalEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvBtnClassLocalEntrega.Location = new System.Drawing.Point(334, 132);
            this.OvBtnClassLocalEntrega.Name = "OvBtnClassLocalEntrega";
            this.OvBtnClassLocalEntrega.Size = new System.Drawing.Size(75, 23);
            this.OvBtnClassLocalEntrega.TabIndex = 27;
            this.OvBtnClassLocalEntrega.Text = "Classificar";
            this.OvBtnClassLocalEntrega.UseVisualStyleBackColor = true;
            this.OvBtnClassLocalEntrega.Click += new System.EventHandler(this.OvBtnClassLocalEntrega_Click);
            // 
            // OvBtnClassRecebedor
            // 
            this.OvBtnClassRecebedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvBtnClassRecebedor.Location = new System.Drawing.Point(334, 87);
            this.OvBtnClassRecebedor.Name = "OvBtnClassRecebedor";
            this.OvBtnClassRecebedor.Size = new System.Drawing.Size(75, 23);
            this.OvBtnClassRecebedor.TabIndex = 26;
            this.OvBtnClassRecebedor.Text = "Classificar";
            this.OvBtnClassRecebedor.UseVisualStyleBackColor = true;
            this.OvBtnClassRecebedor.Click += new System.EventHandler(this.OvBtnClassRecebedor_Click);
            // 
            // OvBtnClassRefCliente
            // 
            this.OvBtnClassRefCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvBtnClassRefCliente.Location = new System.Drawing.Point(334, 42);
            this.OvBtnClassRefCliente.Name = "OvBtnClassRefCliente";
            this.OvBtnClassRefCliente.Size = new System.Drawing.Size(75, 23);
            this.OvBtnClassRefCliente.TabIndex = 19;
            this.OvBtnClassRefCliente.Text = "Classificar";
            this.OvBtnClassRefCliente.UseVisualStyleBackColor = true;
            this.OvBtnClassRefCliente.Click += new System.EventHandler(this.OvBtnClassRefCliente_Click);
            // 
            // OvTxSelecaoTonelagemD1
            // 
            this.OvTxSelecaoTonelagemD1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvTxSelecaoTonelagemD1.Location = new System.Drawing.Point(209, 174);
            this.OvTxSelecaoTonelagemD1.Name = "OvTxSelecaoTonelagemD1";
            this.OvTxSelecaoTonelagemD1.ReadOnly = true;
            this.OvTxSelecaoTonelagemD1.Size = new System.Drawing.Size(100, 21);
            this.OvTxSelecaoTonelagemD1.TabIndex = 25;
            // 
            // OvTxSelecaoPeriodo
            // 
            this.OvTxSelecaoPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvTxSelecaoPeriodo.Location = new System.Drawing.Point(209, 368);
            this.OvTxSelecaoPeriodo.Name = "OvTxSelecaoPeriodo";
            this.OvTxSelecaoPeriodo.ReadOnly = true;
            this.OvTxSelecaoPeriodo.Size = new System.Drawing.Size(100, 21);
            this.OvTxSelecaoPeriodo.TabIndex = 24;
            this.OvTxSelecaoPeriodo.Visible = false;
            // 
            // OvTxSelecaoLocalEntrega
            // 
            this.OvTxSelecaoLocalEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvTxSelecaoLocalEntrega.Location = new System.Drawing.Point(209, 134);
            this.OvTxSelecaoLocalEntrega.Name = "OvTxSelecaoLocalEntrega";
            this.OvTxSelecaoLocalEntrega.ReadOnly = true;
            this.OvTxSelecaoLocalEntrega.Size = new System.Drawing.Size(100, 21);
            this.OvTxSelecaoLocalEntrega.TabIndex = 23;
            // 
            // OvTxSelecaoRecebedor
            // 
            this.OvTxSelecaoRecebedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvTxSelecaoRecebedor.Location = new System.Drawing.Point(209, 88);
            this.OvTxSelecaoRecebedor.Name = "OvTxSelecaoRecebedor";
            this.OvTxSelecaoRecebedor.ReadOnly = true;
            this.OvTxSelecaoRecebedor.Size = new System.Drawing.Size(100, 21);
            this.OvTxSelecaoRecebedor.TabIndex = 22;
            // 
            // OvTxSelecaoRefCliente
            // 
            this.OvTxSelecaoRefCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvTxSelecaoRefCliente.Location = new System.Drawing.Point(209, 42);
            this.OvTxSelecaoRefCliente.Name = "OvTxSelecaoRefCliente";
            this.OvTxSelecaoRefCliente.ReadOnly = true;
            this.OvTxSelecaoRefCliente.Size = new System.Drawing.Size(100, 21);
            this.OvTxSelecaoRefCliente.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Usiminas.PluginExcel.Properties.Resources.usiminas_original;
            this.pictureBox1.Location = new System.Drawing.Point(554, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(291, 220);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // OvBtnProcessSale
            // 
            this.OvBtnProcessSale.Location = new System.Drawing.Point(649, 622);
            this.OvBtnProcessSale.Name = "OvBtnProcessSale";
            this.OvBtnProcessSale.Size = new System.Drawing.Size(101, 31);
            this.OvBtnProcessSale.TabIndex = 1;
            this.OvBtnProcessSale.Text = "Montar pedido";
            this.OvBtnProcessSale.UseVisualStyleBackColor = true;
            this.OvBtnProcessSale.Click += new System.EventHandler(this.OvBtnEnviar_Click);
            // 
            // OvAbaPedido
            // 
            this.OvAbaPedido.Controls.Add(this.BtnIrParaCarrinho);
            this.OvAbaPedido.Controls.Add(this.GridSales);
            this.OvAbaPedido.Controls.Add(this.BtnCancelar);
            this.OvAbaPedido.Location = new System.Drawing.Point(4, 27);
            this.OvAbaPedido.Name = "OvAbaPedido";
            this.OvAbaPedido.Padding = new System.Windows.Forms.Padding(3);
            this.OvAbaPedido.Size = new System.Drawing.Size(1043, 729);
            this.OvAbaPedido.TabIndex = 2;
            this.OvAbaPedido.Text = "Validação de Mapeamento";
            this.OvAbaPedido.UseVisualStyleBackColor = true;
            // 
            // BtnIrParaCarrinho
            // 
            this.BtnIrParaCarrinho.Location = new System.Drawing.Point(865, 6);
            this.BtnIrParaCarrinho.Name = "BtnIrParaCarrinho";
            this.BtnIrParaCarrinho.Size = new System.Drawing.Size(142, 31);
            this.BtnIrParaCarrinho.TabIndex = 5;
            this.BtnIrParaCarrinho.Text = "Ir para carrinho";
            this.BtnIrParaCarrinho.UseVisualStyleBackColor = true;
            this.BtnIrParaCarrinho.Click += new System.EventHandler(this.BtnIrParaCarrinho_Click);
            // 
            // GridSales
            // 
            this.GridSales.AllowUserToAddRows = false;
            this.GridSales.AllowUserToDeleteRows = false;
            this.GridSales.AllowUserToResizeRows = false;
            this.GridSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartNumber,
            this.Id,
            this.Recebedor,
            this.RecebedorMapeado,
            this.RecebedorLista,
            this.Beneficiador,
            this.BeneficiadorMapeado,
            this.BeneficiadorLista,
            this.Mensagem,
            this.D1,
            this.D2,
            this.D3,
            this.period});
            this.GridSales.Location = new System.Drawing.Point(19, 52);
            this.GridSales.Name = "GridSales";
            this.GridSales.RowHeadersVisible = false;
            this.GridSales.Size = new System.Drawing.Size(1008, 614);
            this.GridSales.TabIndex = 4;
            this.GridSales.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridSales_CellMouseDoubleClick);
            this.GridSales.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridSales_CellValueChanged);
            // 
            // PartNumber
            // 
            this.PartNumber.Frozen = true;
            this.PartNumber.HeaderText = "PartNumber";
            this.PartNumber.Name = "PartNumber";
            this.PartNumber.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Recebedor
            // 
            this.Recebedor.HeaderText = "Recebedor";
            this.Recebedor.Name = "Recebedor";
            this.Recebedor.ReadOnly = true;
            // 
            // RecebedorMapeado
            // 
            this.RecebedorMapeado.HeaderText = "RecebedorMapeado";
            this.RecebedorMapeado.Name = "RecebedorMapeado";
            this.RecebedorMapeado.Visible = false;
            // 
            // RecebedorLista
            // 
            this.RecebedorLista.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RecebedorLista.HeaderText = "Mapeamento  Recebedor";
            this.RecebedorLista.MaxDropDownItems = 12;
            this.RecebedorLista.Name = "RecebedorLista";
            this.RecebedorLista.Width = 164;
            // 
            // Beneficiador
            // 
            this.Beneficiador.HeaderText = "Beneficiador";
            this.Beneficiador.Name = "Beneficiador";
            this.Beneficiador.ReadOnly = true;
            // 
            // BeneficiadorMapeado
            // 
            this.BeneficiadorMapeado.HeaderText = "BeneficiadorMapeado";
            this.BeneficiadorMapeado.Name = "BeneficiadorMapeado";
            this.BeneficiadorMapeado.Visible = false;
            // 
            // BeneficiadorLista
            // 
            this.BeneficiadorLista.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BeneficiadorLista.HeaderText = "Mapeamento Beneficiador";
            this.BeneficiadorLista.Name = "BeneficiadorLista";
            this.BeneficiadorLista.Width = 168;
            // 
            // Mensagem
            // 
            this.Mensagem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Mensagem.HeaderText = "Mensagem";
            this.Mensagem.Name = "Mensagem";
            this.Mensagem.ReadOnly = true;
            this.Mensagem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Mensagem.Width = 107;
            // 
            // D1
            // 
            this.D1.HeaderText = "D1";
            this.D1.Name = "D1";
            this.D1.ReadOnly = true;
            this.D1.Width = 50;
            // 
            // D2
            // 
            this.D2.HeaderText = "D2";
            this.D2.Name = "D2";
            this.D2.ReadOnly = true;
            this.D2.Width = 50;
            // 
            // D3
            // 
            this.D3.HeaderText = "D3";
            this.D3.Name = "D3";
            this.D3.ReadOnly = true;
            this.D3.Width = 50;
            // 
            // period
            // 
            this.period.HeaderText = "Periodo";
            this.period.Name = "period";
            this.period.ReadOnly = true;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(917, 682);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(90, 31);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // OvAbaCarrinho
            // 
            this.OvAbaCarrinho.BackColor = System.Drawing.Color.Transparent;
            this.OvAbaCarrinho.Controls.Add(this.OvLbTotalToneContFinal);
            this.OvAbaCarrinho.Controls.Add(this.OvLbTotalToneFinal);
            this.OvAbaCarrinho.Controls.Add(this.button2);
            this.OvAbaCarrinho.Controls.Add(this.OvLbTotalToneCont);
            this.OvAbaCarrinho.Controls.Add(this.OvLbTotalToneMap);
            this.OvAbaCarrinho.Controls.Add(this.OvLbTotalItemCont);
            this.OvAbaCarrinho.Controls.Add(this.OvLbTotalItem);
            this.OvAbaCarrinho.Controls.Add(this.BtnEnviarPedido);
            this.OvAbaCarrinho.Controls.Add(this.flowLayoutPanelCarrinho);
            this.OvAbaCarrinho.Location = new System.Drawing.Point(4, 27);
            this.OvAbaCarrinho.Name = "OvAbaCarrinho";
            this.OvAbaCarrinho.Padding = new System.Windows.Forms.Padding(3);
            this.OvAbaCarrinho.Size = new System.Drawing.Size(1043, 729);
            this.OvAbaCarrinho.TabIndex = 3;
            this.OvAbaCarrinho.Text = "Carrinho";
            // 
            // OvLbTotalToneContFinal
            // 
            this.OvLbTotalToneContFinal.AutoSize = true;
            this.OvLbTotalToneContFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbTotalToneContFinal.Location = new System.Drawing.Point(491, 32);
            this.OvLbTotalToneContFinal.Name = "OvLbTotalToneContFinal";
            this.OvLbTotalToneContFinal.Size = new System.Drawing.Size(18, 20);
            this.OvLbTotalToneContFinal.TabIndex = 8;
            this.OvLbTotalToneContFinal.Text = "0";
            // 
            // OvLbTotalToneFinal
            // 
            this.OvLbTotalToneFinal.AutoSize = true;
            this.OvLbTotalToneFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbTotalToneFinal.Location = new System.Drawing.Point(339, 32);
            this.OvLbTotalToneFinal.Name = "OvLbTotalToneFinal";
            this.OvLbTotalToneFinal.Size = new System.Drawing.Size(157, 20);
            this.OvLbTotalToneFinal.TabIndex = 7;
            this.OvLbTotalToneFinal.Text = "Total tonelagem real:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(716, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OvLbTotalToneCont
            // 
            this.OvLbTotalToneCont.AutoSize = true;
            this.OvLbTotalToneCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbTotalToneCont.Location = new System.Drawing.Point(211, 33);
            this.OvLbTotalToneCont.Name = "OvLbTotalToneCont";
            this.OvLbTotalToneCont.Size = new System.Drawing.Size(18, 20);
            this.OvLbTotalToneCont.TabIndex = 5;
            this.OvLbTotalToneCont.Text = "0";
            // 
            // OvLbTotalToneMap
            // 
            this.OvLbTotalToneMap.AutoSize = true;
            this.OvLbTotalToneMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbTotalToneMap.Location = new System.Drawing.Point(19, 32);
            this.OvLbTotalToneMap.Name = "OvLbTotalToneMap";
            this.OvLbTotalToneMap.Size = new System.Drawing.Size(196, 20);
            this.OvLbTotalToneMap.TabIndex = 4;
            this.OvLbTotalToneMap.Text = "Total tonelagem desejada:";
            // 
            // OvLbTotalItemCont
            // 
            this.OvLbTotalItemCont.AutoSize = true;
            this.OvLbTotalItemCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbTotalItemCont.Location = new System.Drawing.Point(98, 8);
            this.OvLbTotalItemCont.Name = "OvLbTotalItemCont";
            this.OvLbTotalItemCont.Size = new System.Drawing.Size(18, 20);
            this.OvLbTotalItemCont.TabIndex = 3;
            this.OvLbTotalItemCont.Text = "0";
            // 
            // OvLbTotalItem
            // 
            this.OvLbTotalItem.AutoSize = true;
            this.OvLbTotalItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbTotalItem.Location = new System.Drawing.Point(19, 8);
            this.OvLbTotalItem.Name = "OvLbTotalItem";
            this.OvLbTotalItem.Size = new System.Drawing.Size(86, 20);
            this.OvLbTotalItem.TabIndex = 2;
            this.OvLbTotalItem.Text = "Total itens:";
            // 
            // BtnEnviarPedido
            // 
            this.BtnEnviarPedido.Location = new System.Drawing.Point(898, 12);
            this.BtnEnviarPedido.Name = "BtnEnviarPedido";
            this.BtnEnviarPedido.Size = new System.Drawing.Size(126, 36);
            this.BtnEnviarPedido.TabIndex = 1;
            this.BtnEnviarPedido.Text = "Finalizar pedido";
            this.BtnEnviarPedido.UseVisualStyleBackColor = true;
            this.BtnEnviarPedido.Click += new System.EventHandler(this.BtnEnviarPedido_Click);
            // 
            // flowLayoutPanelCarrinho
            // 
            this.flowLayoutPanelCarrinho.AutoScroll = true;
            this.flowLayoutPanelCarrinho.Location = new System.Drawing.Point(6, 67);
            this.flowLayoutPanelCarrinho.Name = "flowLayoutPanelCarrinho";
            this.flowLayoutPanelCarrinho.Size = new System.Drawing.Size(1018, 659);
            this.flowLayoutPanelCarrinho.TabIndex = 0;
            // 
            // OvLbClientePedido
            // 
            this.OvLbClientePedido.AutoSize = true;
            this.OvLbClientePedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbClientePedido.Location = new System.Drawing.Point(17, 9);
            this.OvLbClientePedido.Name = "OvLbClientePedido";
            this.OvLbClientePedido.Size = new System.Drawing.Size(117, 20);
            this.OvLbClientePedido.TabIndex = 1;
            this.OvLbClientePedido.Text = "Cliente XXXXX";
            this.OvLbClientePedido.Visible = false;
            // 
            // OvAbaCarrinhoTab
            // 
            this.OvAbaCarrinhoTab.Controls.Add(this.dataGridView1);
            this.OvAbaCarrinhoTab.Location = new System.Drawing.Point(4, 27);
            this.OvAbaCarrinhoTab.Name = "OvAbaCarrinhoTab";
            this.OvAbaCarrinhoTab.Padding = new System.Windows.Forms.Padding(3);
            this.OvAbaCarrinhoTab.Size = new System.Drawing.Size(1043, 729);
            this.OvAbaCarrinhoTab.TabIndex = 4;
            this.OvAbaCarrinhoTab.Text = "Carrinho Tabela";
            this.OvAbaCarrinhoTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DecMap});
            this.dataGridView1.Location = new System.Drawing.Point(46, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // DecMap
            // 
            this.DecMap.HeaderText = "DecMap";
            this.DecMap.Name = "DecMap";
            // 
            // F_Pedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1112, 814);
            this.Controls.Add(this.OvLbClientePedido);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.Name = "F_Pedido";
            this.Text = "Tools B2B Usiminas";
            this.Load += new System.EventHandler(this.F_Pedido_Load);
            this.TabControl.ResumeLayout(false);
            this.OvAbaConfiguracao.ResumeLayout(false);
            this.OvAbaConfiguracao.PerformLayout();
            this.OvAbaDados.ResumeLayout(false);
            this.OvFrCampos.ResumeLayout(false);
            this.OvFrCampos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.OvAbaPedido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridSales)).EndInit();
            this.OvAbaCarrinho.ResumeLayout(false);
            this.OvAbaCarrinho.PerformLayout();
            this.OvAbaCarrinhoTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage OvAbaDados;
        private System.Windows.Forms.TabPage OvAbaConfiguracao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox OvTxLogin;
        private System.Windows.Forms.Label OvLbLogin;

        private System.Windows.Forms.Label OpLbSenha;
        private System.Windows.Forms.TextBox OvTxSenha;
        private System.Windows.Forms.Button OvBtnProcessSale;
        private System.Windows.Forms.Timer FPTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button OvBtnLogin;
        private System.Windows.Forms.GroupBox OvFrCampos;
        private System.Windows.Forms.TextBox OvTxSelecaoTonelagemD1;
        private System.Windows.Forms.TextBox OvTxSelecaoPeriodo;
        private System.Windows.Forms.TextBox OvTxSelecaoLocalEntrega;
        private System.Windows.Forms.TextBox OvTxSelecaoRecebedor;
        private System.Windows.Forms.TextBox OvTxSelecaoRefCliente;
        private System.Windows.Forms.Button OvBtnClassTonelagemD1;
        private System.Windows.Forms.Button OvBtnClassPeriodo;
        private System.Windows.Forms.Button OvBtnClassLocalEntrega;
        private System.Windows.Forms.Button OvBtnClassRecebedor;
        private System.Windows.Forms.Button OvBtnClassRefCliente;
        private System.Windows.Forms.RadioButton OvRdLocalEntrega;
        private System.Windows.Forms.RadioButton OvRdRecebedor;
        private System.Windows.Forms.RadioButton OvRdRefCliente;
        private System.Windows.Forms.RadioButton OvRdnull;
        private System.Windows.Forms.RadioButton OvRdTonelagemD1;
        private System.Windows.Forms.RadioButton OvRdPerioDesejado;
        private System.Windows.Forms.Button OvBtnClassTonelagemD1Cancel;
        private System.Windows.Forms.Button OvBtnClassPeriodoCancel;
        private System.Windows.Forms.Button OvBtnClassLocalEntregaCancel;
        private System.Windows.Forms.Button OvBtnClassRecebedorCancel;
        private System.Windows.Forms.Button OvBtnClassRefClienteCancel;
        private System.Windows.Forms.TabPage OvAbaPedido;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.DataGridView GridSales;
        private System.Windows.Forms.Button OvBtnClassTonelagemD3Cancel;
        private System.Windows.Forms.RadioButton OvRdTonelagemD3;
        private System.Windows.Forms.Button OvBtnClassTonelagemD3;
        private System.Windows.Forms.TextBox OvTxSelecaoTonelagemD3;
        private System.Windows.Forms.Button OvBtnClassTonelagemD2Cancel;
        private System.Windows.Forms.RadioButton OvRdTonelagemD2;
        private System.Windows.Forms.Button OvBtnClassTonelagemD2;
        private System.Windows.Forms.TextBox OvTxSelecaoTonelagemD2;
        private System.Windows.Forms.DateTimePicker DtPrazoDesejado;
        private TabPage OvAbaCarrinho;
        private Label OvLbPeriodoDesejado;
        private Label OvLbClienteGrupo;
        private ComboBox ObCbClienteGrupo;
        private Button ObBtnChosenClient;
        private Button BtnIrParaCarrinho;
        private DataGridViewTextBoxColumn PartNumber;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Recebedor;
        private DataGridViewTextBoxColumn RecebedorMapeado;
        private DataGridViewComboBoxColumn RecebedorLista;
        private DataGridViewTextBoxColumn Beneficiador;
        private DataGridViewTextBoxColumn BeneficiadorMapeado;
        private DataGridViewComboBoxColumn BeneficiadorLista;
        private DataGridViewTextBoxColumn Mensagem;
        private DataGridViewTextBoxColumn D1;
        private DataGridViewTextBoxColumn D2;
        private DataGridViewTextBoxColumn D3;
        private DataGridViewTextBoxColumn period;
        public FlowLayoutPanel flowLayoutPanelCarrinho;
        private Button BtnEnviarPedido;
        private Label OvLbTotalItemCont;
        private Label OvLbTotalItem;
        private Label OvLbTotalToneCont;
        private Label OvLbTotalToneMap;
        private Label OvLbClientePedido;
        private Label OvLbTotalToneFinal;
        private Label OvLbTotalToneContFinal;
        private Button button2;
        private TabPage OvAbaCarrinhoTab;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn DecMap;
    }
}