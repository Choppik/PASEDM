using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string login, string password) 
        {
            Login = login;
            Password = password;
        }
    }
}
