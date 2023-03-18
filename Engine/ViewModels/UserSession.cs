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
        private List<User> _users { get; set; }
        private User CurrentUser { get; set; }
        public UserSession() { }
        public UserSession(string login, string password)
        {
            CurrentUser = new User(1, login, password);
            //_users.Add(CurrentUser);
        }
        public string Check ()
        {
            string log = CurrentUser?.Login;
            if (log is not null)
            {
                return log;
            }
            else 
            {
                return null;
            }
        }
        public string Check2 ()
        {
            string pas = CurrentUser?.Password;
            if (pas is not null)
            {
                return pas;
            }
            else
            {
                return null;
            }
        }
    }
}
