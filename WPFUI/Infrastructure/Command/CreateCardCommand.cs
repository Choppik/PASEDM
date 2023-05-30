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
        #region Переменные и свойтва
        private DateTime _dateOfFormation;
        private DateTime _dateOfFormationDocument;

        private int _numberCard;
        private int _docRegistrationNumber;
        private string _nameCard;
        private string _summary;
        private string _comment;
        private string _filePath;
        private string _docName;
        private string _nameTask;
        private string _contentTask;

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
        private IMoveCardCreator _moveUserCreator;
        private ICardCreator _cardCreator;
        private ITaskCreator _taskCreator;

        private IDocProvider _docProvider;
        private IRecipientProvider _recipientProvider;
        private ICardProvider _cardProvider;
        private ITypeUserProvider _typeUserProvider;
        private ITasksProvider _tasksProvider;
        #endregion

        public CreateCardCommand(CreateCardViewModel createCardViewModel, PASEDMDbContextFactory deferredContextFactory, INavigationService navigationService)
        {
            _createCardViewModel = createCardViewModel;
            _deferredContextFactory = deferredContextFactory;
            _navigationService = navigationService;

        }

        public async override Task ExecuteAsync(object? parameter)
        {
            if (!_createCardViewModel.HasErrors)
            {
                _documentCreator = new DatabaseDocumentCreator(_deferredContextFactory);
                _recipientCreator = new DatabaseRecipientCreator(_deferredContextFactory);
                _moveUserCreator = new DatabaseMoveCardCreator(_deferredContextFactory);
                _cardCreator = new DatabaseCardCreator(_deferredContextFactory);
                _taskCreator = new DatabaseTaskCreator(_deferredContextFactory);

                _docProvider = new DatabaseDocProvider(_deferredContextFactory);
                _recipientProvider = new DatabaseRecipientProvider(_deferredContextFactory);
                _cardProvider = new DatabaseCardProvider(_deferredContextFactory);
                _typeUserProvider = new DatabaseTypeUserProvider(_deferredContextFactory);
                _tasksProvider = new DatabaseTasksProvider(_deferredContextFactory);

                Document document = new(_documentCreator, _docProvider);
                Recipient recipient = new(_recipientCreator, _recipientProvider);
                TypeUser typeUser = new(_typeUserProvider);
                Card card = new(_cardCreator, _cardProvider);
                MoveCard moveUser = new(_moveUserCreator);
                Tasks tasks = new(_taskCreator, _tasksProvider);

                _numberCard = _createCardViewModel.NumberCard;
                _nameCard = _createCardViewModel.NameCard;
                _dateOfFormation = DateTime.Now;

                _docName = _createCardViewModel.Document;
                _docRegistrationNumber = _createCardViewModel.RegistrationNumber;
                _dateOfFormationDocument = _createCardViewModel.DateOfFormationDocument;
                _summary = _createCardViewModel.Summary;
                _docStages = _createCardViewModel.CurrentDocStages;
                _secrecyStamps = _createCardViewModel.CurrentSecrecyStamp;
                _filePath = "...filePath";
                _documentType = _createCardViewModel.CurrentDocTypes;
                _term = _createCardViewModel.CurrentTerm;
                _task = _createCardViewModel.CurrentTask;
                _taskStages = _createCardViewModel.CurrentTaskStages;
                _nameTask = _createCardViewModel.NameTask;
                _contentTask = _createCardViewModel.ContentTask;
                _recipient = _createCardViewModel.CurrentRecipient;
                _case = _createCardViewModel.CurrentCase;
                _executor = _createCardViewModel.CurrentExecutor;
                _createCardUser = _createCardViewModel.CurrentUser;
                _comment = _createCardViewModel.Comment;

                var _viewed = 0;

                await document.AddDoc(new(_docName, _docRegistrationNumber, _dateOfFormationDocument, _summary, _filePath, _term, _secrecyStamps, _docStages, _documentType));
                var docDB = await document.GetDoc(new(_docName, _docRegistrationNumber, _dateOfFormationDocument, _summary, _filePath, _term, _secrecyStamps, _docStages, _documentType));

                await recipient.AddRecipient(new(_recipient.Id));
                var recipientDB = await recipient.GetRecipient(new(_recipient.Id));

                if (_createCardViewModel.IsCheckedTask)
                {
                    if (_task != null) await tasks.EditTask(new(_task.Id, _task.NameTask, _task.Contents, _taskStages));
                    await card.CreateCard(new(_numberCard, _nameCard, _comment, _dateOfFormation, docDB, _documentType, _task, _case, _executor, _createCardUser, recipientDB));
                }
                else
                {
                    await tasks.AddTask(new(_nameTask, _contentTask, _taskStages));
                    var taskDB = await tasks.GetTask(new(_nameTask, _contentTask, _taskStages));

                    await card.CreateCard(new(_numberCard, _nameCard, _comment, _dateOfFormation, docDB, _documentType, taskDB, _case, _executor, _createCardUser, recipientDB));
                }

                var cardDB = await card.GetCard(new(_dateOfFormation));

                foreach (var item in await typeUser.GetAllTypeUsers())
                {
                    await moveUser.AddMoveUser(new(item.Id, _viewed, cardDB.Id));
                }

                _navigationService.Navigate();

                MessageBox.Show("Карта создана");
            }
            else MessageBox.Show("Проверьте корректность ввода данных");
        }
    }
}