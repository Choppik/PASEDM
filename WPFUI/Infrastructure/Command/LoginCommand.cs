using PASEDM.Data;
using PASEDM.Infrastructure.Command.Base;
using PASEDM.Models;
using PASEDM.Store;
using PASEDM.ViewModels;
using System.Threading.Tasks;
using System.Windows;
using PASEDM.Services;
using PASEDM.Services.PASEDMCreator;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Services.PASEDMConflictValidator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;

namespace PASEDM.Infrastructure.Command
{
    public class LoginCommand : AsyncBaseCommand
    {
        private string _userName;
        private string _password;

        private readonly UserEntryViewModel _userEntryViewModel;
        private readonly UserStore _userStore;
        private readonly INavigationService _navigationService;
        private readonly PASEDMDbContextFactory _deferredContextFactory;

        private IUserCreator _userCreator;
        private IUserProvider _userProvider;
        private IUserConflictValidator _userConflictValidator;


        public LoginCommand(
            UserEntryViewModel userEntryViewModel, 
            UserStore userStore, 
            INavigationService navigationService, 
            PASEDMDbContextFactory deferredContextFactory)
        {
            _userEntryViewModel = userEntryViewModel;
            _userStore = userStore;
            _navigationService = navigationService;
            _deferredContextFactory = deferredContextFactory;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            _userCreator = new DatabaseUserCreator(_deferredContextFactory);
            _userProvider = new DatabaseUserProvider(_deferredContextFactory);
            _userConflictValidator = new DatabaseUserConflictValidator(_deferredContextFactory);


            if (_userEntryViewModel.UserName != null && _userEntryViewModel.Password != null)
            {
                _userName = _userEntryViewModel.UserName;
                _password = _userEntryViewModel.Password;

                User currentUser = new(_userCreator, _userProvider, _userConflictValidator);

                bool unic = false;

                if (await currentUser.GetAllUsers() != null)
                {
                    foreach (var user in await currentUser.GetAllUsers())
                    {
                        if (user.UserName == _userName && user.Password == _password)
                        {
                            unic = true;
                            break;
                        }
                    }
                    if (unic == false)
                    {
                        MessageBox.Show("Неверно введено имя пользователя или пароль.");
                    }
                    else
                    {
                        _userStore.CurrentUser = new(_userName);
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