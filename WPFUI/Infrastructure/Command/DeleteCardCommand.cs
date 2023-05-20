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
    public class DeleteCardCommand : AsyncBaseCommand
    {
        private readonly MoveCard _moveUser;
        private readonly PASEDMDbContextFactory _deferredContextFactory;
        private readonly INavigationService _navigationService;

        private IMoveCardProvider _moveUserProvider;

        public DeleteCardCommand(MoveCard moveUser, PASEDMDbContextFactory deferredContextFactory, INavigationService navigationService)
        {
            _moveUser = moveUser;
            _deferredContextFactory = deferredContextFactory;
            _navigationService = navigationService;
        }

        public async override Task ExecuteAsync(object? parameter)
        {
            _moveUserProvider = new DatabaseMoveCardProvider(_deferredContextFactory);
            MoveCard moveUserProvider = new(_moveUserProvider);
            await moveUserProvider.DeleteMoveUser(_moveUser);

            MessageBox.Show("Карта удалена", "Удаление карты", MessageBoxButton.OK, MessageBoxImage.Information);
            _navigationService.Navigate();
        }
    }
}