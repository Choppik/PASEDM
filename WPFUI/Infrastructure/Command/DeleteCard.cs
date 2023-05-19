using PASEDM.Data;
using PASEDM.Infrastructure.Command.Base;
using PASEDM.Services;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Threading.Tasks;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Models;
using System.Windows;

namespace PASEDM.Infrastructure.Command
{
    public class DeleteCard : AsyncBaseCommand
    {
        private readonly MoveUser _moveUser;
        private readonly PASEDMDbContextFactory _deferredContextFactory;
        private readonly INavigationService _navigationService;

        private IMoveUserProvider _moveUserProvider;

        public DeleteCard(MoveUser moveUser, PASEDMDbContextFactory deferredContextFactory, INavigationService navigationService)
        {
            _moveUser = moveUser;
            _deferredContextFactory = deferredContextFactory;
            _navigationService = navigationService;
        }

        public async override Task ExecuteAsync(object? parameter)
        {
            _moveUserProvider = new DatabaseMoveUserProvider(_deferredContextFactory);
            MoveUser moveUserProvider = new(_moveUserProvider);
            await moveUserProvider.DeleteMoveUser(_moveUser);

            MessageBox.Show("Карта удалена");
            _navigationService.Navigate();
        }
    }
}