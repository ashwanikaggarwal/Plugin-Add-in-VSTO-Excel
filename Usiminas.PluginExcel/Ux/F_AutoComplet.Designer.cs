namespace Usiminas.PluginExcel.Ux
{
    partial class F_AutoComplet
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
            this.BtnOvOptionTodas = new System.Windows.Forms.Button();
            this.BtnOvOptionIgual = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnOvOptionTodas
            // 
            this.BtnOvOptionTodas.Location = new System.Drawing.Point(27, 12);
            this.BtnOvOptionTodas.Name = "BtnOvOptionTodas";
            this.BtnOvOptionTodas.Size = new System.Drawing.Size(132, 34);
            this.BtnOvOptionTodas.TabIndex = 0;
            this.BtnOvOptionTodas.Text = "Todas as linhas";
            this.BtnOvOptionTodas.UseVisualStyleBackColor = true;
            this.BtnOvOptionTodas.Click += new System.EventHandler(this.BtnOvOptionTodas_Click);
            // 
            // BtnOvOptionIgual
            // 
            this.BtnOvOptionIgual.Location = new System.Drawing.Point(27, 70);
            this.BtnOvOptionIgual.Name = "BtnOvOptionIgual";
            this.BtnOvOptionIgual.Size = new System.Drawing.Size(132, 34);
            this.BtnOvOptionIgual.TabIndex = 1;
            this.BtnOvOptionIgual.Text = "Linhas com texto igual";
            this.BtnOvOptionIgual.UseVisualStyleBackColor = true;
            this.BtnOvOptionIgual.Click += new System.EventHandler(this.BtnOvOptionIgual_Click);
            // 
            // F_AutoComplet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 130);
            this.Controls.Add(this.BtnOvOptionIgual);
            this.Controls.Add(this.BtnOvOptionTodas);
            this.Name = "F_AutoComplet";
            this.Text = "Completar";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnOvOptionTodas;
        private System.Windows.Forms.Button BtnOvOptionIgual;
    }
}