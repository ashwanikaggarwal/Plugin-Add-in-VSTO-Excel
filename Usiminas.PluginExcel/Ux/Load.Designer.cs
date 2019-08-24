namespace Usiminas.PluginExcel.Ux
{
    partial class Load
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Load));
            this.LoadOvLbAguarde = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoadOvLbAguarde
            // 
            this.LoadOvLbAguarde.AutoSize = true;
            this.LoadOvLbAguarde.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadOvLbAguarde.Location = new System.Drawing.Point(12, 201);
            this.LoadOvLbAguarde.Name = "LoadOvLbAguarde";
            this.LoadOvLbAguarde.Size = new System.Drawing.Size(112, 24);
            this.LoadOvLbAguarde.TabIndex = 0;
            this.LoadOvLbAguarde.Text = "Aguarde!!!!";
            // 
            // Load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(359, 234);
            this.Controls.Add(this.LoadOvLbAguarde);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "Load";
            this.Text = "Load";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoadOvLbAguarde;
    }
}