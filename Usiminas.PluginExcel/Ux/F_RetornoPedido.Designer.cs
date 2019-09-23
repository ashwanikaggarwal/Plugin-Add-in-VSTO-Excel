namespace Usiminas.PluginExcel.Ux
{
    partial class F_RetornoPedido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_RetornoPedido));
            this.GridRetorno = new System.Windows.Forms.DataGridView();
            this.OvLbFimPedido = new System.Windows.Forms.Label();
            this.OvRetorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OvModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNumberModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mensagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridRetorno)).BeginInit();
            this.SuspendLayout();
            // 
            // GridRetorno
            // 
            this.GridRetorno.AllowUserToAddRows = false;
            this.GridRetorno.AllowUserToDeleteRows = false;
            this.GridRetorno.AllowUserToOrderColumns = true;
            this.GridRetorno.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridRetorno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridRetorno.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridRetorno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridRetorno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OvRetorno,
            this.OvModelo,
            this.ItemModelo,
            this.PartNumberModelo,
            this.Status,
            this.Mensagem});
            this.GridRetorno.Location = new System.Drawing.Point(12, 44);
            this.GridRetorno.Name = "GridRetorno";
            this.GridRetorno.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridRetorno.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridRetorno.Size = new System.Drawing.Size(837, 427);
            this.GridRetorno.TabIndex = 0;
            // 
            // OvLbFimPedido
            // 
            this.OvLbFimPedido.AutoSize = true;
            this.OvLbFimPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvLbFimPedido.Location = new System.Drawing.Point(12, 9);
            this.OvLbFimPedido.Name = "OvLbFimPedido";
            this.OvLbFimPedido.Size = new System.Drawing.Size(238, 20);
            this.OvLbFimPedido.TabIndex = 1;
            this.OvLbFimPedido.Text = "Pedido Realizado com sucesso! ";
            // 
            // OvRetorno
            // 
            this.OvRetorno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OvRetorno.Frozen = true;
            this.OvRetorno.HeaderText = "Ov criada";
            this.OvRetorno.Name = "OvRetorno";
            this.OvRetorno.ReadOnly = true;
            // 
            // OvModelo
            // 
            this.OvModelo.HeaderText = "Ov modelo";
            this.OvModelo.Name = "OvModelo";
            this.OvModelo.ReadOnly = true;
            this.OvModelo.Visible = false;
            // 
            // ItemModelo
            // 
            this.ItemModelo.HeaderText = "Item Modelo";
            this.ItemModelo.Name = "ItemModelo";
            this.ItemModelo.ReadOnly = true;
            this.ItemModelo.Visible = false;
            // 
            // PartNumberModelo
            // 
            this.PartNumberModelo.HeaderText = "PartNumber";
            this.PartNumberModelo.Name = "PartNumberModelo";
            this.PartNumberModelo.ReadOnly = true;
            this.PartNumberModelo.Width = 119;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 81;
            // 
            // Mensagem
            // 
            this.Mensagem.HeaderText = "Mensagem";
            this.Mensagem.Name = "Mensagem";
            this.Mensagem.ReadOnly = true;
            this.Mensagem.Width = 113;
            // 
            // F_RetornoPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 483);
            this.Controls.Add(this.OvLbFimPedido);
            this.Controls.Add(this.GridRetorno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F_RetornoPedido";
            this.Text = "F_RetornoPedido";
            ((System.ComponentModel.ISupportInitialize)(this.GridRetorno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridRetorno;
        private System.Windows.Forms.Label OvLbFimPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn OvRetorno;
        private System.Windows.Forms.DataGridViewTextBoxColumn OvModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNumberModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mensagem;
    }
}