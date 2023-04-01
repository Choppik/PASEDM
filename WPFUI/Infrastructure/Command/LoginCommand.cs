using PASEDM.Data;
using PASEDM.Infrastructure.Command.Base;
using PASEDM.Models;
using PASEDM.Store;
using PASEDM.View.UserControlAll;
using PASEDM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PASEDM.Services;

namespace PASEDM.Infrastructure.Command
{
    public class LoginCommand : BaseCommand
    {
        private string _login;
        private string _password;

        private readonly MenuViewModel _menuViewModel;
        private readonly NavigationService<MenuViewModel> _navigationService;

        public LoginCommand(MenuViewModel menuViewModel, NavigationService<MenuViewModel> navigationService)
        {
            _menuViewModel = menuViewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            if (/*TextBoxLogEntry.Text != null && PasswordBoxEntry.Password != null*/1==1)
            {
                /*_login = TextBoxLogEntry.Text;
                _password = PasswordBoxEntry.Password;*/
                _login = "1";
                _password = "1";

                using var db = new PASEDMContext();
                var dbTable = db.Users;
                bool unic = true;
                List<User> users = dbTable.ToList();
                if (users.Count != 0)
                {
                    foreach (var user in users)
                    {
                        if (user.Login == _login && user.Password == _password)
                        {
                            unic = true;
                            break;
                        }
                        else
                        {
                            unic = false;
                        }
                    }
                    if (unic == false)
                    {
                        MessageBox.Show("Неверно введено имя пользователя или пароль.");
                    }
                    else
                    {
                        _navigationService.Navigate();
                    }
                }
                else
                {
                    MessageBox.Show("Неверно введено имя пользователя или пароль.");
                }
            }
        }
    }
}
