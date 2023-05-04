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
        private string _secrecyStamp;
        private string _summary;
        private string _conditionDoc;
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

        private readonly CreateCardViewModel _createCardViewModel;
        private readonly PASEDMDbContextFactory _deferredContextFactory;

        private IDocumentCreator _documentCreator;
        private IRecipientCreator _recipientCreator;
        private ICardCreator _cardCreator;

        private IDocProvider _docProvider;
        private IRecipientProvider _recipientProvider;
        private IUserProvider _userProvider;

        public CreateCardCommand(CreateCardViewModel createCardViewModel, PASEDMDbContextFactory deferredContextFactory)
        {
            _createCardViewModel = createCardViewModel;
            _deferredContextFactory = deferredContextFactory;
        }

        public async override Task ExecuteAsync(object? parameter)
        {
            _documentCreator = new DatabaseDocumentCreator(_deferredContextFactory);
            _recipientCreator = new DatabaseRecipientCreator(_deferredContextFactory);
            _cardCreator = new DatabaseCardCreator(_deferredContextFactory);

            _docProvider = new DatabaseDocProvider(_deferredContextFactory);
            _recipientProvider = new DatabaseRecipientProvider(_deferredContextFactory);
            _userProvider = new DatabaseUserProvider(_deferredContextFactory);

            Document document = new(_documentCreator);
            Recipient recipient = new(_recipientCreator);
            Card card = new(_cardCreator);

            Document document1 = new(_docProvider);
            Recipient recipient1 = new(_recipientProvider);
            User user = new(_userProvider);

            _numberCard = _createCardViewModel.NumberCard;
            _nameCard = _createCardViewModel.NameCard;
            _dateOfFormation = _createCardViewModel.DateOfFormation;
            _docName = _createCardViewModel.Document;
            _docRegistrationNumber = _createCardViewModel.RegistrationNumber;
            _dateOfFormationDocument = _createCardViewModel.DateOfFormationDocument;
            _summary = _createCardViewModel.Summary;
            //_conditionDoc = _createCardViewModel.ConditionDoc;
            //_secrecyStamp = _createCardViewModel.SecrecyStamp;
            _filePath = "...filePath";
            _term = _createCardViewModel.CurrentTerm;
            _task = _createCardViewModel.CurrentTask;
            _recipient = _createCardViewModel.CurrentRecipient;
            _case = _createCardViewModel.CurrentCase;
            _documentType = _createCardViewModel.CurrentDocTypes;
            _executor = _createCardViewModel.CurrentExecutor;
            _createCardUser = _createCardViewModel.CurrentUser;
            _comment = _createCardViewModel.Comment;

            //await document.AddDoc(new Document(_docName, _docRegistrationNumber, _dateOfFormationDocument, _summary, _conditionDoc, _secrecyStamp, _filePath, _term.ID));
            //await recipient.AddRecipient(new Recipient(_dateOfFormation, _task.Id, _recipient.Id));

            var docDB = await document1.GetDoc(new(_docName));
            var recipientDB = await recipient1.GetRecipient(new(_dateOfFormation, _recipient.Id));
            var userDB = await user.GetUser(new(_createCardUser.UserName));

            //await card.CreateCard(new Card(_numberCard, _nameCard, _comment, docDB.Id, _documentType.ID, _case.ID, userDB.Id, _executor.ID, recipientDB.Id));
            MessageBox.Show("Карта создана");
        }
    }
}