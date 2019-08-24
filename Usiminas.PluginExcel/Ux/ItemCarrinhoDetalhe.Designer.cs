namespace Usiminas.PluginExcel.Ux
{
    partial class ItemCarrinhoDetalhe
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OvLbIcDecendio = new System.Windows.Forms.Label();
            this.OvLbIcMes = new System.Windows.Forms.Label();
            this.OvLbIcTonelage = new System.Windows.Forms.Label();
            this.OvLbIcTonelageMult = new System.Windows.Forms.Label();
            this.OvCbIcRecebedor = new System.Windows.Forms.ComboBox();
            this.OvCbIcBeneficiador = new System.Windows.Forms.ComboBox();
            this.OvLbIcRecebedor = new System.Windows.Forms.Label();
            this.OvLbIcBeneficiador = new System.Windows.Forms.Label();
            this.OvLbIcMesDesejadoPos = new System.Windows.Forms.Label();
            this.OvNuIcMultTonelage = new System.Windows.Forms.NumericUpDown();
            this.OvDtAceiteDisp = new System.Windows.Forms.DateTimePicker();
            this.OvLbIcDecendioMap = new System.Windows.Forms.Label();
            this.OvLbIcMesMap = new System.Windows.Forms.Label();
            this.OvLbIcTonelageMap = new System.Windows.Forms.Label();
            this.OvGbIcDisponível = new System.Windows.Forms.GroupBox();
            this.OvCbIcDecendio = new System.Windows.Forms.ComboBox();
            this.OvLbIcDecPossivel = new System.Windows.Forms.Label();
            this.OvGbIcDesejado = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.OvNuIcMultTonelage)).BeginInit();
            this.OvGbIcDisponível.SuspendLayout();
            this.OvGbIcDesejado.SuspendLayout();
            this.SuspendLayout();
            // 
            // OvLbIcDecendio
            // 
            this.OvLbIcDecendio.AutoSize = true;
            this.OvLbIcDecendio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbIcDecendio.Location = new System.Drawing.Point(8, 17);
            this.OvLbIcDecendio.Name = "OvLbIcDecendio";
            this.OvLbIcDecendio.Size = new System.Drawing.Size(39, 18);
            this.OvLbIcDecendio.TabIndex = 1;
            this.OvLbIcDecendio.Text = "Dec:";
            // 
            // OvLbIcMes
            // 
            this.OvLbIcMes.AutoSize = true;
            this.OvLbIcMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbIcMes.Location = new System.Drawing.Point(56, 17);
            this.OvLbIcMes.Name = "OvLbIcMes";
            this.OvLbIcMes.Size = new System.Drawing.Size(50, 18);
            this.OvLbIcMes.TabIndex = 3;
            this.OvLbIcMes.Text = "| Mês:";
            // 
            // OvLbIcTonelage
            // 
            this.OvLbIcTonelage.AutoSize = true;
            this.OvLbIcTonelage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbIcTonelage.Location = new System.Drawing.Point(148, 17);
            this.OvLbIcTonelage.Margin = new System.Windows.Forms.Padding(0);
            this.OvLbIcTonelage.Name = "OvLbIcTonelage";
            this.OvLbIcTonelage.Size = new System.Drawing.Size(95, 18);
            this.OvLbIcTonelage.TabIndex = 5;
            this.OvLbIcTonelage.Text = "| Tonelagem:";
            // 
            // OvLbIcTonelageMult
            // 
            this.OvLbIcTonelageMult.AutoSize = true;
            this.OvLbIcTonelageMult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbIcTonelageMult.Location = new System.Drawing.Point(250, 16);
            this.OvLbIcTonelageMult.Name = "OvLbIcTonelageMult";
            this.OvLbIcTonelageMult.Size = new System.Drawing.Size(114, 18);
            this.OvLbIcTonelageMult.TabIndex = 7;
            this.OvLbIcTonelageMult.Text = "Ton. Disponível:";
            // 
            // OvCbIcRecebedor
            // 
            this.OvCbIcRecebedor.Enabled = false;
            this.OvCbIcRecebedor.FormattingEnabled = true;
            this.OvCbIcRecebedor.Location = new System.Drawing.Point(62, 56);
            this.OvCbIcRecebedor.Name = "OvCbIcRecebedor";
            this.OvCbIcRecebedor.Size = new System.Drawing.Size(223, 21);
            this.OvCbIcRecebedor.TabIndex = 8;
            this.OvCbIcRecebedor.SelectedIndexChanged += new System.EventHandler(this.OvCbIcRecebedor_SelectedIndexChanged);
            // 
            // OvCbIcBeneficiador
            // 
            this.OvCbIcBeneficiador.Enabled = false;
            this.OvCbIcBeneficiador.FormattingEnabled = true;
            this.OvCbIcBeneficiador.Location = new System.Drawing.Point(347, 56);
            this.OvCbIcBeneficiador.Name = "OvCbIcBeneficiador";
            this.OvCbIcBeneficiador.Size = new System.Drawing.Size(266, 21);
            this.OvCbIcBeneficiador.TabIndex = 9;
            this.OvCbIcBeneficiador.SelectedIndexChanged += new System.EventHandler(this.OvCbIcBeneficiador_SelectedIndexChanged);
            // 
            // OvLbIcRecebedor
            // 
            this.OvLbIcRecebedor.AutoSize = true;
            this.OvLbIcRecebedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbIcRecebedor.Location = new System.Drawing.Point(6, 57);
            this.OvLbIcRecebedor.Name = "OvLbIcRecebedor";
            this.OvLbIcRecebedor.Size = new System.Drawing.Size(71, 15);
            this.OvLbIcRecebedor.TabIndex = 10;
            this.OvLbIcRecebedor.Text = "Recebedor:";
            // 
            // OvLbIcBeneficiador
            // 
            this.OvLbIcBeneficiador.AutoSize = true;
            this.OvLbIcBeneficiador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbIcBeneficiador.Location = new System.Drawing.Point(286, 57);
            this.OvLbIcBeneficiador.Name = "OvLbIcBeneficiador";
            this.OvLbIcBeneficiador.Size = new System.Drawing.Size(79, 15);
            this.OvLbIcBeneficiador.TabIndex = 11;
            this.OvLbIcBeneficiador.Text = "Beneficiador:";
            // 
            // OvLbIcMesDesejadoPos
            // 
            this.OvLbIcMesDesejadoPos.AutoSize = true;
            this.OvLbIcMesDesejadoPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbIcMesDesejadoPos.Location = new System.Drawing.Point(83, 18);
            this.OvLbIcMesDesejadoPos.Name = "OvLbIcMesDesejadoPos";
            this.OvLbIcMesDesejadoPos.Size = new System.Drawing.Size(113, 18);
            this.OvLbIcMesDesejadoPos.TabIndex = 15;
            this.OvLbIcMesDesejadoPos.Text = "Mês Disponivel:";
            // 
            // OvNuIcMultTonelage
            // 
            this.OvNuIcMultTonelage.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.OvNuIcMultTonelage.Location = new System.Drawing.Point(339, 18);
            this.OvNuIcMultTonelage.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.OvNuIcMultTonelage.Name = "OvNuIcMultTonelage";
            this.OvNuIcMultTonelage.Size = new System.Drawing.Size(51, 20);
            this.OvNuIcMultTonelage.TabIndex = 16;
            this.OvNuIcMultTonelage.ValueChanged += new System.EventHandler(this.OvNuIcMultTonelage_ValueChanged);
            // 
            // OvDtAceiteDisp
            // 
            this.OvDtAceiteDisp.CustomFormat = "MM-yyyy";
            this.OvDtAceiteDisp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.OvDtAceiteDisp.Location = new System.Drawing.Point(173, 18);
            this.OvDtAceiteDisp.Name = "OvDtAceiteDisp";
            this.OvDtAceiteDisp.Size = new System.Drawing.Size(71, 20);
            this.OvDtAceiteDisp.TabIndex = 17;
            this.OvDtAceiteDisp.ValueChanged += new System.EventHandler(this.OvDtAceiteDisp_ValueChanged);
            // 
            // OvLbIcDecendioMap
            // 
            this.OvLbIcDecendioMap.AutoSize = true;
            this.OvLbIcDecendioMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbIcDecendioMap.Location = new System.Drawing.Point(33, 21);
            this.OvLbIcDecendioMap.Name = "OvLbIcDecendioMap";
            this.OvLbIcDecendioMap.Size = new System.Drawing.Size(23, 13);
            this.OvLbIcDecendioMap.TabIndex = 18;
            this.OvLbIcDecendioMap.Text = "D1";
            // 
            // OvLbIcMesMap
            // 
            this.OvLbIcMesMap.AutoSize = true;
            this.OvLbIcMesMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbIcMesMap.Location = new System.Drawing.Point(86, 20);
            this.OvLbIcMesMap.Name = "OvLbIcMesMap";
            this.OvLbIcMesMap.Size = new System.Drawing.Size(60, 15);
            this.OvLbIcMesMap.TabIndex = 19;
            this.OvLbIcMesMap.Text = "08-2019";
            // 
            // OvLbIcTonelageMap
            // 
            this.OvLbIcTonelageMap.AutoSize = true;
            this.OvLbIcTonelageMap.BackColor = System.Drawing.Color.Transparent;
            this.OvLbIcTonelageMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbIcTonelageMap.Location = new System.Drawing.Point(204, 19);
            this.OvLbIcTonelageMap.Name = "OvLbIcTonelageMap";
            this.OvLbIcTonelageMap.Size = new System.Drawing.Size(23, 15);
            this.OvLbIcTonelageMap.TabIndex = 20;
            this.OvLbIcTonelageMap.Text = "12";
            // 
            // OvGbIcDisponível
            // 
            this.OvGbIcDisponível.Controls.Add(this.OvCbIcDecendio);
            this.OvGbIcDisponível.Controls.Add(this.OvLbIcDecPossivel);
            this.OvGbIcDisponível.Controls.Add(this.OvLbIcTonelageMult);
            this.OvGbIcDisponível.Controls.Add(this.OvLbIcMesDesejadoPos);
            this.OvGbIcDisponível.Controls.Add(this.OvNuIcMultTonelage);
            this.OvGbIcDisponível.Controls.Add(this.OvDtAceiteDisp);
            this.OvGbIcDisponível.Location = new System.Drawing.Point(238, 3);
            this.OvGbIcDisponível.Name = "OvGbIcDisponível";
            this.OvGbIcDisponível.Size = new System.Drawing.Size(397, 48);
            this.OvGbIcDisponível.TabIndex = 21;
            this.OvGbIcDisponível.TabStop = false;
            this.OvGbIcDisponível.Text = "Disponível";
            // 
            // OvCbIcDecendio
            // 
            this.OvCbIcDecendio.Enabled = false;
            this.OvCbIcDecendio.FormattingEnabled = true;
            this.OvCbIcDecendio.Location = new System.Drawing.Point(32, 17);
            this.OvCbIcDecendio.Name = "OvCbIcDecendio";
            this.OvCbIcDecendio.Size = new System.Drawing.Size(52, 21);
            this.OvCbIcDecendio.TabIndex = 22;
            // 
            // OvLbIcDecPossivel
            // 
            this.OvLbIcDecPossivel.AutoSize = true;
            this.OvLbIcDecPossivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbIcDecPossivel.Location = new System.Drawing.Point(2, 16);
            this.OvLbIcDecPossivel.Name = "OvLbIcDecPossivel";
            this.OvLbIcDecPossivel.Size = new System.Drawing.Size(39, 18);
            this.OvLbIcDecPossivel.TabIndex = 22;
            this.OvLbIcDecPossivel.Text = "Dec:";
            // 
            // OvGbIcDesejado
            // 
            this.OvGbIcDesejado.Controls.Add(this.OvLbIcTonelageMap);
            this.OvGbIcDesejado.Controls.Add(this.OvLbIcMes);
            this.OvGbIcDesejado.Controls.Add(this.OvLbIcMesMap);
            this.OvGbIcDesejado.Controls.Add(this.OvLbIcDecendio);
            this.OvGbIcDesejado.Controls.Add(this.OvLbIcDecendioMap);
            this.OvGbIcDesejado.Controls.Add(this.OvLbIcTonelage);
            this.OvGbIcDesejado.Location = new System.Drawing.Point(3, 3);
            this.OvGbIcDesejado.Name = "OvGbIcDesejado";
            this.OvGbIcDesejado.Size = new System.Drawing.Size(233, 47);
            this.OvGbIcDesejado.TabIndex = 22;
            this.OvGbIcDesejado.TabStop = false;
            this.OvGbIcDesejado.Text = "Desejado";
            // 
            // ItemCarrinhoDetalhe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.OvLbIcBeneficiador);
            this.Controls.Add(this.OvLbIcRecebedor);
            this.Controls.Add(this.OvCbIcBeneficiador);
            this.Controls.Add(this.OvCbIcRecebedor);
            this.Controls.Add(this.OvGbIcDisponível);
            this.Controls.Add(this.OvGbIcDesejado);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximumSize = new System.Drawing.Size(770, 107);
            this.Name = "ItemCarrinhoDetalhe";
            this.Size = new System.Drawing.Size(636, 81);
            ((System.ComponentModel.ISupportInitialize)(this.OvNuIcMultTonelage)).EndInit();
            this.OvGbIcDisponível.ResumeLayout(false);
            this.OvGbIcDisponível.PerformLayout();
            this.OvGbIcDesejado.ResumeLayout(false);
            this.OvGbIcDesejado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label OvLbIcDecendio;
        private System.Windows.Forms.Label OvLbIcMes;
        private System.Windows.Forms.Label OvLbIcTonelage;
        private System.Windows.Forms.Label OvLbIcTonelageMult;
        private System.Windows.Forms.ComboBox OvCbIcRecebedor;
        private System.Windows.Forms.ComboBox OvCbIcBeneficiador;
        private System.Windows.Forms.Label OvLbIcRecebedor;
        private System.Windows.Forms.Label OvLbIcBeneficiador;
        private System.Windows.Forms.Label OvLbIcMesDesejadoPos;
        private System.Windows.Forms.NumericUpDown OvNuIcMultTonelage;
        private System.Windows.Forms.DateTimePicker OvDtAceiteDisp;
        private System.Windows.Forms.Label OvLbIcDecendioMap;
        private System.Windows.Forms.Label OvLbIcMesMap;
        private System.Windows.Forms.Label OvLbIcTonelageMap;
        private System.Windows.Forms.GroupBox OvGbIcDisponível;
        private System.Windows.Forms.Label OvLbIcDecPossivel;
        private System.Windows.Forms.ComboBox OvCbIcDecendio;
        private System.Windows.Forms.GroupBox OvGbIcDesejado;
    }
}
