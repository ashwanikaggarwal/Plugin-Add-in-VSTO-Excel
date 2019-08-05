using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using Usiminas.PluginExcel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Usiminas.PluginExcel.Services;

namespace Usiminas.PluginExcel
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {

        }
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        public Excel.Range Worksheet_SelectionChange()
        {
            return (Excel.Range)Application.ActiveCell;

        }
        public Excel.Worksheet GetActiveWorkSheet()
        {
            return (Excel.Worksheet)Application.ActiveSheet;
        }
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);

        }

        #endregion
    }
}
