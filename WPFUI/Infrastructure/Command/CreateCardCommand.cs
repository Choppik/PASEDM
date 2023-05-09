using PASEDM.Data;
using PASEDM.Infrastructure.Command.Base;
using PASEDM.Models;
using PASEDM.Services;
using PASEDM.Services.PASEDMConflictValidator;
using PASEDM.Services.PASEDMCreator;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace PASEDM.Infrastructure.Command
{
    public class CreateCardCommand : AsyncBaseCommand
    {
        private DateTime _dateOfFormation;
        private DateTime _dateOfFormationDocument;

        private string _nameCard;
        private int _numberCard;
        private string _summary;
        private string _comment;
        private string _filePath;
        private string _docName;
        private int _docRegistrationNumber;

        private User _createCardUser;

        private Deadlines _term;
        private Tasks _task;
        private User _recipient;
        private Case _case;
        private DocumentTypes _documentType;
        private Employee _executor;
        private SecrecyStamps _secrecyStamps;
        private DocStages _docStages;
        private TaskStages _taskStages;

        private readonly CreateCardViewModel _createCardViewModel;
        private readonly PASEDMDbContextFactory _deferredContextFactory;
        private readonly INavigationService _navigationService;

        private IDocumentCreator _documentCreator;
        private IRecipientCreator _recipientCreator;
        private IMoveUserCreator _moveUserCreator;
        private ICardCreator _cardCreator;

        private IDocProvider _docProvider;
        private IRecipientProvider _recipientProvider;
        private ICardProvider _cardProvider;
        private ITypeUserProvider _typeUserProvider;

        public CreateCardCommand(CreateCardViewModel createCardViewModel, PASEDMDbContextFactory deferredContextFactory, INavigationService navigationService)
        {
            _createCardViewModel = createCardViewModel;
            _deferredContextFactory = deferredContextFactory;
            _navigationService = navigationService;

        }

        public async override Task ExecuteAsync(object? parameter)
        {
            _documentCreator = new DatabaseDocumentCreator(_deferredContextFactory);
            _recipientCreator = new DatabaseRecipientCreator(_deferredContextFactory);
            _moveUserCreator = new DatabaseMoveUserCreator(_deferredContextFactory);
            _cardCreator = new DatabaseCardCreator(_deferredContextFactory);

            _docProvider = new DatabaseDocProvider(_deferredContextFactory);
            _recipientProvider = new DatabaseRecipientProvider(_deferredContextFactory);
            _cardProvider = new DatabaseCardProvider(_deferredContextFactory);
            _typeUserProvider = new DatabaseTypeUserProvider(_deferredContextFactory);

            Document document = new(_documentCreator, _docProvider);
            Recipient recipient = new(_recipientCreator, _recipientProvider);
            TypeUser typeUser = new(_typeUserProvider);
            Card card = new(_cardCreator, _cardProvider);
            MoveUser moveUser = new(_moveUserCreator);

            _numberCard = _createCardViewModel.NumberCard;
            _nameCard = _createCardViewModel.NameCard;
            _dateOfFormation = _createCardViewModel.DateOfFormation;
            _docName = _createCardViewModel.Document;
            _docRegistrationNumber = _createCardViewModel.RegistrationNumber;
            _dateOfFormationDocument = _createCardViewModel.DateOfFormationDocument;
            _summary = _createCardViewModel.Summary;
            _docStages = _createCardViewModel.CurrentDocStages;
            _secrecyStamps = _createCardViewModel.CurrentSecrecyStamp;
            _taskStages = _createCardViewModel.CurrentTaskStages;
            _filePath = "...filePath";
            _term = _createCardViewModel.CurrentTerm;
            _task = _createCardViewModel.CurrentTask;
            _recipient = _createCardViewModel.CurrentRecipient;
            _case = _createCardViewModel.CurrentCase;
            _documentType = _createCardViewModel.CurrentDocTypes;
            _executor = _createCardViewModel.CurrentExecutor;
            _createCardUser = _createCardViewModel.CurrentUser;
            _comment = _createCardViewModel.Comment;

            await document.AddDoc(new(_docName, _docRegistrationNumber, _dateOfFormationDocument, _summary, _filePath, _term.Id, _secrecyStamps.Id, _docStages.Id));
            var docDB = await document.GetDoc(new(_docName));

            //Создание задачи

            await recipient.AddRecipient(new(_recipient.Id));
            var recipientDB = await recipient.GetRecipient(new(_recipient.Id));

            await card.CreateCard(new(_numberCard, _nameCard, _comment, _dateOfFormation, docDB.Id, _documentType.Id, _task.Id, _case.Id, _executor.Id, _createCardUser.Id, recipientDB.Id));
            var cardDB = await card.GetCard(new(_nameCard));

            foreach(var item in await typeUser.GetAllTypeUsers())
            {
                await moveUser.AddMoveUser(new(item.Id, cardDB.Id));
            }

            _navigationService.Navigate();
            MessageBox.Show("Карта создана");
        }
    }
}