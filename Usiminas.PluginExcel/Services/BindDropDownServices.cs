using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usiminas.PluginExcel.Dto;
using Usiminas.PluginExcel.Entities;
using Usiminas.PluginExcel.Util;

namespace Usiminas.PluginExcel.Services
{
    public static class BindDropDownServices
    {
        public static DataGridViewComboBoxColumn DropDown(string CodClient)
        {
            var column = new DataGridViewComboBoxColumn();
            column.DataSource = new List<string>() { "10", "30", "80", "100" };
            return column;
        }

    }
}
