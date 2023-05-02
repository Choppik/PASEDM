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

        private IEmployeeProvider _employeeProvider;

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

            _employeeProvider = new DatabaseEmployeeProvider(_deferredContextFactory);

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
                Employee employee = new(_employeeProvider);

                bool unic = false;
                DateTime dateTime = DateTime.Now;

                foreach (var user in await currentUser.GetAllNameUsers())
                {
                    if (user.UserName == _userName)
                    {
                        MessageBox.Show("Данное имя не уникально.");
                        unic = false;
                        break;
                    }
                    else
                    {
                        unic = true;
                    }
                }
                if (unic == true)
                {
                    foreach (var item  in await employee.GetAllEmployee())
                    {
                        if (item.FullName == _userCreateViewModel.Employee.FullName)
                        {
                            _employee = item.ID;
                            break;
                        }
                    }

                    await currentUser.AddUser(new User(_userName, _password, dateTime, "user", _employee));
                    //await currentUser.AddUser(new User { UserName = _userName, Password = _password, DateOfCreation = dateTime, Role = "user", EmployeeID = _employee });
                    MessageBox.Show("Пользователь создан. Пробуйте войти в аккаунт.");
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