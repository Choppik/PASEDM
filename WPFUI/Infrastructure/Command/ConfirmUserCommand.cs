using PASEDM.Data;
using PASEDM.Infrastructure.Command.Base;
using PASEDM.Models;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.Services;
using System;
using System.Threading.Tasks;
using PASEDM.Services.PASEDMProviders;
using System.Windows;

namespace PASEDM.Infrastructure.Command
{
    public class ConfirmUserCommand : AsyncBaseCommand
    {
        private readonly User _user;
        private readonly PASEDMDbContextFactory _deferredContextFactory;
        private readonly INavigationService _navigationService;

        private IUserProvider _userProvider;

        public ConfirmUserCommand(User user, PASEDMDbContextFactory deferredContextFactory, INavigationService navigationService)
        {
            _user = user;
            _deferredContextFactory = deferredContextFactory;
            _navigationService = navigationService;
        }

        public async override Task ExecuteAsync(object? parameter)
        {
            _userProvider = new DatabaseUserProvider(_deferredContextFactory);
            User userProvider = new(_userProvider);
            await userProvider.ConfirmationUser(_user);

            MessageBox.Show("Учетная запись подтверждена", "Подтверждение учетной записи", MessageBoxButton.OK, MessageBoxImage.Information);
            _navigationService.Navigate();
        }
    }
}
