using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ViewModels
{
    public class UserSession
    {
        User CurrentUser { get; set; }
        public UserSession()
        {
            CurrentUser = new User();
            CurrentUser.IdUser = 1;
            CurrentUser.Login = "User1";
            CurrentUser.Password = "1234567890";
        }
    }
}
