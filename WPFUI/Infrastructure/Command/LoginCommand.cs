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
using System.Windows.Controls;

namespace PASEDM.Infrastructure.Command
{
    public class LoginCommand : BaseCommand
    {
        private string _login;
        private string _password;

        private readonly UserEntryViewModel _userEntryViewModel;
        private readonly UserStore _userStore;
        private readonly INavigationService<MenuViewModel> _navigationService;


        public LoginCommand(UserEntryViewModel userEntryViewModel, UserStore userStore, INavigationService<MenuViewModel> navigationService)
        {
            _userEntryViewModel = userEntryViewModel;
            _navigationService = navigationService;
            _userStore = userStore;
        }

        public override void Execute(object? parameter)
        {
            var passwordBox = (PasswordBox) parameter;

            if (_userEntryViewModel.Login != null && passwordBox.Password != null)
            {
                _login = _userEntryViewModel.Login;
                _password = passwordBox.Password;
                User userCurrent = new()
                {
                    Login = _login,
                    Password = _password
                };

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
                        _userStore.CurrentUser = userCurrent;
                        _navigationService.Navigate();
                    }
                }
            }
                else
                {
                    MessageBox.Show("Неверно введено имя пользователя или пароль.");
                }
        }
    }
}
