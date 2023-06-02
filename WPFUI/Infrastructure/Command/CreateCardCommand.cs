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
using System.IO;
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
        private string _path;
        private byte[] _file;
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
        private IMoveCardCreator _moveUserCreator;
        private ICardCreator _cardCreator;
        private ITaskCreator _taskCreator;

        private IDocProvider _docProvider;
        private ICardProvider _cardProvider;
        private ITypeCardProvider _typeCardProvider;
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
                _moveUserCreator = new DatabaseMoveCardCreator(_deferredContextFactory);
                _cardCreator = new DatabaseCardCreator(_deferredContextFactory);
                _taskCreator = new DatabaseTaskCreator(_deferredContextFactory);

                _docProvider = new DatabaseDocProvider(_deferredContextFactory);
                _cardProvider = new DatabaseCardProvider(_deferredContextFactory);
                _typeCardProvider = new DatabaseTypeUserProvider(_deferredContextFactory);
                _tasksProvider = new DatabaseTasksProvider(_deferredContextFactory);

                Document document = new(_documentCreator, _docProvider);
                TypeCard typeCard = new(_typeCardProvider);
                Card card = new(_cardCreator, _cardProvider);
                MoveCard moveCard = new(_moveUserCreator);
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
                _path = @"C:\\Users\\egkol\\OneDrive\\Рабочий стол\\txtPr.docx";
                _file = ReadFile(_path);
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

                await document.AddDoc(new(_docName, _docRegistrationNumber, _summary, _file, _term, _secrecyStamps, _docStages, _documentType));
                var docDB = await document.GetDoc(new(_docName, _docRegistrationNumber, _summary, _file, _term, _secrecyStamps, _docStages, _documentType));

                if (_createCardViewModel.IsCheckedTask)
                {
                    if (_task != null) await tasks.EditTask(new(_task.Id, _task.NameTask, _task.Contents, _taskStages));
                    await card.CreateCard(new(_numberCard, _nameCard, _comment, _dateOfFormation, docDB, _task, _case, _executor));
                }
                else
                {
                    await tasks.AddTask(new(_nameTask, _contentTask, _taskStages));
                    var taskDB = await tasks.GetTask(new(_nameTask, _contentTask, _taskStages));

                    await card.CreateCard(new(_numberCard, _nameCard, _comment, _dateOfFormation, docDB, taskDB, _case, _executor));
                }

                var cardDB = await card.GetCard(new(_dateOfFormation));

                foreach (var item in await typeCard.GetAllTypeUsers())
                {
                    switch (item.TypeCardValue)
                    {
                        case 0:
                            await moveCard.AddMoveCard(new(_viewed, cardDB, item, _createCardUser));
                            break;
                        case 1:
                            await moveCard.AddMoveCard(new(_viewed, cardDB, item, _recipient));
                            break;
                    }
                }

                _navigationService.Navigate();

                MessageBox.Show("Карта создана");
            }
            else MessageBox.Show("Проверьте корректность ввода данных");
        }

        private static byte[] ReadFile(string path)
        {
            using(FileStream fs = new(path, FileMode.Open))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
                fs.Close();
                return buffer;
            }
        }
    }
}