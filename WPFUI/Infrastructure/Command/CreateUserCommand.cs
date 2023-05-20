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
        private Employee _employee;
        private int _role;
        private Role _roleDB;
        private int _recordConfirmation = 0;

        private readonly UserCreateViewModel _userCreateViewModel;
        private readonly PASEDMDbContextFactory _deferredContextFactory;

        private IUserCreator _userCreator;
        private IUserProvider _userProvider;
        private IUserConflictValidator _userConflictValidator;

        private IRoleProvider _roleProvider;

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

            _roleProvider = new DatabaseRoleProvider(_deferredContextFactory);

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

                if (_userCreateViewModel.IsChecked) _role = 1;
                else _role = 0;

                User currentUser = new(_userCreator, _userProvider, _userConflictValidator);
                Role currentRole = new(_roleProvider);

                DateTime dateTime = DateTime.Now;

                var userDB = await currentUser.GetUserBool(new(_userName));

                foreach(var role in await currentRole.GetAllRole())
                {
                    if (role != null && _role == role.SignificanceRole)
                    {
                        _roleDB = role;
                        break;
                    }
                }

                if(userDB)
                {
                    _employee = _userCreateViewModel.Employee;
                    await currentUser.AddUser(new User(_userName, _password, _recordConfirmation, dateTime, _roleDB, _employee));
                    MessageBox.Show("Пользователь создан. После подтверждения учетной записи пробуйте войти в аккаунт.");
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
                    $" минимум один символ в верхнем регистре и один в нижнем, минимум один специальный символ (!$%^&*-) и минимум одна цифра.");
            }
        }
    }
}