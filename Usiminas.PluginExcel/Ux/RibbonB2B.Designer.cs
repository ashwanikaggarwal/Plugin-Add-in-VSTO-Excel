namespace Usiminas.PluginExcel
{
    partial class RibbonB2B : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonB2B()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.B2BGroup = this.Factory.CreateRibbonGroup();
            this.RibbonBtnFormulario = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.B2BGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.B2BGroup);
            this.tab1.Label = "Usiminas B2B";
            this.tab1.Name = "tab1";
            // 
            // B2BGroup
            // 
            this.B2BGroup.Items.Add(this.RibbonBtnFormulario);
            this.B2BGroup.Label = "B2B";
            this.B2BGroup.Name = "B2BGroup";
            // 
            // RibbonBtnFormulario
            // 
            this.RibbonBtnFormulario.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.RibbonBtnFormulario.Image = global::Usiminas.PluginExcel.Properties.Resources.usiminas_logo;
            this.RibbonBtnFormulario.ImageName = "logoUsiminas";
            this.RibbonBtnFormulario.Label = "Emitir Pedido";
            this.RibbonBtnFormulario.Name = "RibbonBtnFormulario";
            this.RibbonBtnFormulario.ShowImage = true;
            this.RibbonBtnFormulario.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.RibbonB2BCallForm);
            // 
            // RibbonB2B
            // 
            this.Name = "RibbonB2B";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonB2B_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.B2BGroup.ResumeLayout(false);
            this.B2BGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup B2BGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton RibbonBtnFormulario;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonB2B RibbonB2B
        {
            get {

                return this.GetRibbon<RibbonB2B>(); 
}
        }
    }
}
