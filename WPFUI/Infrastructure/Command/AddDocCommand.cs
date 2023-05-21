using PASEDM.Data;
using PASEDM.Infrastructure.Command.Base;
using PASEDM.Models;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.Services;
using PASEDM.ViewModels;
using System;
using System.Threading.Tasks;
using PASEDM.Services.PASEDMCreator;
using PASEDM.Services.PASEDMProviders;
using System.Windows;

namespace PASEDM.Infrastructure.Command
{
    public class AddDocCommand : AsyncBaseCommand
    {
        #region Переменные и свойтва
        private DateTime _dateOfFormationDocument;

        private int _docRegistrationNumber;
        private string _summary;
        private string _filePath;
        private string _docName;

        private Deadlines _term;
        private DocumentTypes _documentType;
        private SecrecyStamps _secrecyStamps;
        private DocStages _docStages;

        private readonly AddDocViewModel _addDocViewModel;
        private readonly PASEDMDbContextFactory _deferredContextFactory;
        private readonly INavigationService _navigationService;

        private IDocumentCreator _documentCreator;
        private IMoveDocumentCreator _moveDocumentCreator;

        private IDocProvider _docProvider;
        #endregion

        public AddDocCommand(AddDocViewModel addDocViewModel, PASEDMDbContextFactory deferredContextFactory, INavigationService navigationService)
        {
            _addDocViewModel = addDocViewModel;
            _deferredContextFactory = deferredContextFactory;
            _navigationService = navigationService;
        }
        public async override Task ExecuteAsync(object? parameter)
        {
            _documentCreator = new DatabaseDocumentCreator(_deferredContextFactory);
            _moveDocumentCreator = new DatabaseMoveDocumentCreator(_deferredContextFactory);
            _docProvider = new DatabaseDocProvider(_deferredContextFactory);
            Document document = new(_documentCreator, _docProvider);
            MoveDocument moveDocument = new(_moveDocumentCreator);

            _docName = _addDocViewModel.Document;
            _docRegistrationNumber = _addDocViewModel.RegistrationNumber;
            _dateOfFormationDocument = _addDocViewModel.DateOfFormationDocument;
            _summary = _addDocViewModel.Summary;
            _docStages = _addDocViewModel.CurrentDocStages;
            _secrecyStamps = _addDocViewModel.CurrentSecrecyStamp;
            _filePath = "...filePath";
            _documentType = _addDocViewModel.CurrentDocTypes;
            _term = _addDocViewModel.CurrentTerm;

            await document.AddDoc(new(_docName, _docRegistrationNumber, _dateOfFormationDocument, _summary, _filePath, _term, _secrecyStamps, _docStages, _documentType));
            var docDB = await document.GetDoc(new(_dateOfFormationDocument));
            await moveDocument.AddMoveDocument(new(_addDocViewModel.CurrentUser, docDB));

            _navigationService.Navigate();

            MessageBox.Show("Документ добавлен.", "Добавление документа", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
