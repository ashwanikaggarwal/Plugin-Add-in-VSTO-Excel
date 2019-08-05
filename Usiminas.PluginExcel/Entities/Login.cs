using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Usiminas.PluginExcel.Entities;

namespace Usiminas.PluginExcel.Entities
{
    public sealed class Login
    {
        [Required(ErrorMessage = "O login é Obrigatório")]
        public string LoginClient { get; private set; }
        [Required(ErrorMessage = "A senha é Obrigatória")]
        public string Password { get; private set; }
        public void CreateLogin(string login, string password)
        {
            LoginClient = login;
            Password = password;
        }
    }
}
