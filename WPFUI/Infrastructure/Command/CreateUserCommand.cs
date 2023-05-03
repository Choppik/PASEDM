using PASEDM.Data;
using PASEDM.Infrastructure.Command.Base;
using PASEDM.Models;
using PASEDM.Services.PASEDMConflictValidator;
using PASEDM.Services.PASEDMCreator;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.ViewModels;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace PASEDM.Infrastructure.Command
{
    public class CreateUserCommand : AsyncBaseCommand
    {
        private readonly Regex regex = new(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!$%^&*-]).{8,}$");

        private string _userName;
        private string _password;
        private int _employee;

        private readonly UserCreateViewModel _userCreateViewModel;
        private readonly PASEDMDbContextFactory _deferredContextFactory;

        private IUserCreator _userCreator;
        private IUserProvider _userProvider;
        private IUserConflictValidator _userConflictValidator;

        public CreateUserCommand(
            UserCreateViewModel userGreatViewModel, 
            PASEDMDbContextFactory deferredContextFactory)
        {
            _userCreateViewModel = userGreatViewModel;
            _deferredContextFactory = deferredContextFactory;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            _userCreator = new DatabaseUserCreator(_deferredContextFactory);
            _userProvider = new DatabaseUserProvider(_deferredContextFactory);
            _userConflictValidator = new DatabaseUserConflictValidator(_deferredContextFactory);

            if (_userCreateViewModel.UserName != null && 
                _userCreateViewModel.UserName.Length <= 50 &&
                _userCreateViewModel.Password != null && 
                _userCreateViewModel.ReplayPassword != null && 
                _userCreateViewModel.Password == _userCreateViewModel.ReplayPassword &&
                _userCreateViewModel.ReplayPassword.Length <= 100 &&
                _userCreateViewModel.UserName != _userCreateViewModel.ReplayPassword && 
                regex.IsMatch(_userCreateViewModel.ReplayPassword) &&
                !_userCreateViewModel.UserName.Contains(' ') && 
                !_userCreateViewModel.ReplayPassword.Contains(' ') &&
                _userCreateViewModel.Employee != null)
            {
                _userName = _userCreateViewModel.UserName;
                _password = _userCreateViewModel.ReplayPassword;

                User currentUser = new(_userCreator, _userProvider, _userConflictValidator);

                DateTime dateTime = DateTime.Now;

                var userDB = await currentUser.GetUser(new(_userName));

                if(userDB)
                {
                    _employee = _userCreateViewModel.Employee.ID;

                    await currentUser.AddUser(new User(_userName, _password, dateTime, "user", _employee));
                    MessageBox.Show("Пользователь создан. Пробуйте войти в аккаунт.");
                }
                else
                {
                    MessageBox.Show("Данное имя не уникально.");
                }
            }
            else
            {
                MessageBox.Show($"Что-то введено неверно. Пароль должен соответствовать следующему формату: только латинские символы," +
                    $" длина пароля не менее 8 символов," +
                    $" минимум один символ в верхнем регистре и один в нижнем, минимум один специальный символ (!$%^&*-) и минимум одна цифра");
            }
        }
    }
}