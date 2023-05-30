using PASEDM.Data;
using PASEDM.Models;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Services;
using System.Threading.Tasks;
using System.Windows;
using PASEDM.Infrastructure.Command.Base;

namespace PASEDM.Infrastructure.Command
{
    public class DeleteDocCommand : AsyncBaseCommand
    {
        private readonly MoveDocument _moveDocument;
        private readonly PASEDMDbContextFactory _deferredContextFactory;
        private readonly INavigationService _navigationService;

        private IMoveDocumentProvider _moveDocumentProvider;

        public DeleteDocCommand(MoveDocument moveDocument, PASEDMDbContextFactory deferredContextFactory, INavigationService navigationService)
        {
            _moveDocument = moveDocument;
            _deferredContextFactory = deferredContextFactory;
            _navigationService = navigationService;
        }

        public async override Task ExecuteAsync(object? parameter)
        {
            _moveDocumentProvider = new DatabaseMoveDocumentProvider(_deferredContextFactory);
            MoveDocument moveDocumentProvider = new(_moveDocumentProvider);
            await moveDocumentProvider.DeleteMoveDocument(_moveDocument);

            MessageBox.Show("Документ удален", "Удаление документа", MessageBoxButton.OK, MessageBoxImage.Information);
            _navigationService.Navigate();
        }
    }
}