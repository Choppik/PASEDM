using PASEDM.Data;
using PASEDM.Infrastructure.Command.Base;
using PASEDM.Models;
using PASEDM.Services.PASEDMConflictValidator;
using PASEDM.Services.PASEDMCreator;
using PASEDM.Services.PASEDMProviders;
using PASEDM.ViewModels;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace PASEDM.Infrastructure.Command
{
    public class CreateUserCommand : AsyncBaseCommand
    {
        private Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!$%^&*-]).{8,}$");

        private string _userName;
        private string _password;
        private string _employeeName;

        private readonly UserGreatViewModel _userGreatViewModel;
        private readonly PASEDMDbContextFactory _deferredContextFactory;

        private IUserCreator _userCreator;
        private IUserProvider _userProvider;
        private IUserConflictValidator _userConflictValidator;

        public CreateUserCommand(
            UserGreatViewModel userGreatViewModel, 
            PASEDMDbContextFactory deferredContextFactory)
        {
            _userGreatViewModel = userGreatViewModel;
            _deferredContextFactory = deferredContextFactory;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            _userCreator = new DatabaseUserCreator(_deferredContextFactory);
            _userProvider = new DatabaseUserProvider(_deferredContextFactory);
            _userConflictValidator = new DatabaseUserConflictValidator(_deferredContextFactory);

            if (_userGreatViewModel.UserName != null && 
                _userGreatViewModel.UserName.Length <= 50 &&
                _userGreatViewModel.Password != null && 
                _userGreatViewModel.ReplayPassword != null && 
                _userGreatViewModel.Password == _userGreatViewModel.ReplayPassword &&
                _userGreatViewModel.ReplayPassword.Length <= 100 &&
                _userGreatViewModel.UserName != _userGreatViewModel.ReplayPassword && 
                regex.IsMatch(_userGreatViewModel.ReplayPassword) &&
                !_userGreatViewModel.UserName.Contains(" ") && 
                !_userGreatViewModel.ReplayPassword.Contains(" "))
            {
                _userName = _userGreatViewModel.UserName;
                _password = _userGreatViewModel.ReplayPassword;
                //_employeeName = _userGreatViewModel.EmployeeName;

                MoveUser currentUser = new(_userCreator, _userProvider, _userConflictValidator);

                bool unic = true;

                foreach (var user in await currentUser.GetAllNameUsers())
                {
                    if (user.UserName == _userName)
                    {
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
                    await currentUser.AddUser(new User(_userName, _password, 1));
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