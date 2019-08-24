namespace Usiminas.PluginExcel.Ux
{
    partial class ItemCarrinho
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
            this.ICPartNumber = new System.Windows.Forms.Label();
            this.ICDetalhamento = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ICPartNumber
            // 
            this.ICPartNumber.AutoSize = true;
            this.ICPartNumber.BackColor = System.Drawing.Color.Silver;
            this.ICPartNumber.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ICPartNumber.Location = new System.Drawing.Point(6, 6);
            this.ICPartNumber.Name = "ICPartNumber";
            this.ICPartNumber.Size = new System.Drawing.Size(84, 17);
            this.ICPartNumber.TabIndex = 0;
            this.ICPartNumber.Text = "PartNumber";
            // 
            // ICDetalhamento
            // 
            this.ICDetalhamento.AutoSize = true;
            this.ICDetalhamento.BackColor = System.Drawing.Color.Silver;
            this.ICDetalhamento.Location = new System.Drawing.Point(9, 27);
            this.ICDetalhamento.Name = "ICDetalhamento";
            this.ICDetalhamento.Size = new System.Drawing.Size(129, 13);
            this.ICDetalhamento.TabIndex = 1;
            this.ICDetalhamento.Text = "Datalhamento partnumber";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(636, 42);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ItemCarrinho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ICDetalhamento);
            this.Controls.Add(this.ICPartNumber);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ItemCarrinho";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(635, 46);
            this.Load += new System.EventHandler(this.ItemCarrinho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ICPartNumber;
        private System.Windows.Forms.Label ICDetalhamento;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
