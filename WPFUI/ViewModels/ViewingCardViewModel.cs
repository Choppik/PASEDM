using PASEDM.Data;
using PASEDM.Models;
using PASEDM.Services;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Xml.Linq;
using System;
using PASEDM.Infrastructure.Command;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class ViewingCardViewModel : BaseViewModels
    {
        private readonly UserStore _userStore;
        private PASEDMDbContextFactory _contextFactory;
        private IParamNavigationService<ViewingCardViewModel> _parameterNavigationService;
        private INavigationService _navigationService;

        private Tasks _currentTask;
        private Case _currentCase;
        private DocumentTypes _currentDocTypes;
        private User _currentRecipient;
        private Employee _currentExecutor;
        private Deadlines _currentTerm;
        private SecrecyStamps _currentSecrecyStamp;
        private TaskStages _currentTaskStages;
        private DocStages _currentDocStages;

        private DateTime _dateOfFormation = DateTime.Now;
        private DateTime _dateOfFormationDocument = DateTime.Now;

        private int _numberCard;
        private int _docRegistrationNumber;
        private string _nameCard;
        private string _summary;
        private string _comment;
        private string _filePath;
        private string _docName = "text";
        private string _nameTask;
        private string _contentTask;
        private string _userCreateCard;
        public Tasks CurrentTask
        {
            get
            {
                return _currentTask;
            }
            set
            {
                _currentTask = value;
                OnPropertyChanged(nameof(CurrentTask));
                //ClearErrors(nameof(CurrentTask));

                if (CurrentTask == null)
                {
                    //AddErrors("Необходимо выбрать значение из списка", nameof(CurrentTask));
                }
            }
        }
        public DocumentTypes CurrentDocTypes
        {
            get
            {
                return _currentDocTypes;
            }
            set
            {
                _currentDocTypes = value;
                OnPropertyChanged(nameof(CurrentDocTypes));
            }
        }
        public Case CurrentCase
        {
            get
            {
                return _currentCase;
            }
            set
            {
                _currentCase = value;
                OnPropertyChanged(nameof(CurrentCase));
            }
        }
        public User CurrentRecipient
        {
            get
            {
                return _currentRecipient;
            }
            set
            {
                _currentRecipient = value;
                OnPropertyChanged(nameof(CurrentRecipient));
            }
        }
        public Employee CurrentExecutor
        {
            get
            {
                return _currentExecutor;
            }
            set
            {
                _currentExecutor = value;
                OnPropertyChanged(nameof(CurrentExecutor));
            }
        }
        public Deadlines CurrentTerm
        {
            get
            {
                return _currentTerm;
            }
            set
            {
                _currentTerm = value;
                OnPropertyChanged(nameof(CurrentTerm));
            }
        }
        public SecrecyStamps CurrentSecrecyStamp
        {
            get
            {
                return _currentSecrecyStamp;
            }
            set
            {
                _currentSecrecyStamp = value;
                OnPropertyChanged(nameof(CurrentSecrecyStamp));
            }
        }
        public TaskStages CurrentTaskStages
        {
            get
            {
                return _currentTaskStages;
            }
            set
            {
                _currentTaskStages = value;
                OnPropertyChanged(nameof(CurrentTaskStages));
            }
        }
        public DocStages CurrentDocStages
        {
            get
            {
                return _currentDocStages;
            }
            set
            {
                _currentDocStages = value;
                OnPropertyChanged(nameof(CurrentDocStages));
            }
        }

        public DateTime DateOfFormation => _dateOfFormation;
        public DateTime DateOfFormationDocument
        {
            get
            {
                return _dateOfFormationDocument;
            }
            set
            {
                _dateOfFormationDocument = value;
                OnPropertyChanged(nameof(DateOfFormationDocument));
            }
        }

        public User CurrentUser => _userStore.CurrentUser;

        public string UserCreateCard
        {
            get
            {
                return _userCreateCard;
            }
            set
            {
                _userCreateCard = value;
                OnPropertyChanged(nameof(UserCreateCard));
            }
        }

        public int RegistrationNumber
        {
            get
            {
                return _docRegistrationNumber;
            }
            set
            {
                _docRegistrationNumber = value;
                OnPropertyChanged(nameof(RegistrationNumber));
            }
        }
        public int NumberCard
        {
            get
            {
                return _numberCard;
            }
            set
            {
                _numberCard = value;
                OnPropertyChanged(nameof(NumberCard));
            }
        }
        public string NameCard
        {
            get
            {
                return _nameCard;
            }
            set
            {
                _nameCard = value;
                OnPropertyChanged(nameof(NameCard));
            }
        }
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }
        public string Document
        {
            get
            {
                return _docName;
            }
            set
            {
                _docName = value;
                OnPropertyChanged(nameof(Document));
            }
        }
        public string Summary
        {
            get
            {
                return _summary;
            }
            set
            {
                _summary = value;
                OnPropertyChanged(nameof(Summary));
            }
        }
        public string NameTask
        {
            get
            {
                return _nameTask;
            }
            set
            {
                _nameTask = value;
                OnPropertyChanged(nameof(NameTask));
            }
        }
        public string ContentTask
        {
            get
            {
                return _contentTask;
            }
            set
            {
                _contentTask = value;
                OnPropertyChanged(nameof(ContentTask));
            }
        }
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }
        public ICommand NavigateRefundCommand { get; }

        public ViewingCardViewModel(
            IncomingViewModel incomingViewModel,
            INavigationService navigationService,
            PASEDMDbContextFactory deferredContextFactory,
            UserStore userStore)
        {
            _contextFactory = deferredContextFactory;
            _userStore = userStore;
            _navigationService = navigationService;

            if (incomingViewModel.CurrentMoveUser.Card.Id != 0)
            {
                _nameCard = incomingViewModel.CurrentMoveUser.Card.NameCard;
                _docRegistrationNumber = incomingViewModel.CurrentMoveUser.Card.Documents.RegistrationNumber;
                _numberCard = incomingViewModel.CurrentMoveUser.Card.NumberCard;
                _summary = incomingViewModel.CurrentMoveUser.Card.Documents.Summary;
                _comment = incomingViewModel.CurrentMoveUser.Card.Comment;
                //_filePath = incomingViewModel.CurrentMoveUser.Document.File;
                _docName = incomingViewModel.CurrentMoveUser.Card.Documents.NameDoc;
                _dateOfFormation = incomingViewModel.CurrentMoveUser.Card.DateOfFormation;
                CurrentTask = incomingViewModel.CurrentMoveUser.Card.Tasks;
                CurrentTaskStages = incomingViewModel.CurrentMoveUser.Card.Tasks.TaskStage;
                CurrentCase = incomingViewModel.CurrentMoveUser.Card.Cases;
                CurrentDocTypes = incomingViewModel.CurrentMoveUser.Card.Documents.DocumentTypes;
                CurrentExecutor = incomingViewModel.CurrentMoveUser.Card.Employee;
                CurrentSecrecyStamp = incomingViewModel.CurrentMoveUser.Card.Documents.SecrecyStamp;
                CurrentTerm = incomingViewModel.CurrentMoveUser.Card.Documents.Term;
            }
            NavigateRefundCommand = new NavigateCommand(navigationService);
        }
    }
}