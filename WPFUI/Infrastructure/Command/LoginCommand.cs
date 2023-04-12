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
using System;

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
            _navigationService = navigationService;
            _userStore = userStore;
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
                User user1 = new(_userCreator, _userProvider, _userConflictValidator);
                //User userCurrent = new(_userName, _password);
                User userCurrentStore = new(_userName);

                bool unic = true;

                if (await user1.GetAllUsers() != null)
                {
                    foreach (var user in await user1.GetAllUsers())
                    {
                        if (user.UserName == _userName && user.Password == _password)
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
                        _userStore.CurrentUser = userCurrentStore;
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
