using Microsoft.Win32;
using PASEDM.Data;
using PASEDM.Infrastructure.Command;
using PASEDM.Models;
using PASEDM.Services;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class CreateCardViewModel : BaseViewModels, INotifyDataErrorInfo
    {
        #region Переменные и свойства
        private readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;

        private IEmployeeProvider _employeeProvider;
        private ITasksProvider _tasksProvider;
        private ICasesProvider _casesProvider;
        private IDocTypProvider _docTypProvider;
        private IUserProvider _userProvider;
        private IDeadlinesProvider _deadlinesProvider;
        private ITaskStagesProvider _taskStagesProvider;
        private IDocStagesProvider _docStagesProvider;
        private ISecrecyStampsProvider _secrecyStampsProvider;

        private readonly UserStore _userStore;

        private PASEDMDbContextFactory _contextFactory;

        private ObservableCollection<Tasks> _tasks;
        private ObservableCollection<Case> _cases;
        private ObservableCollection<DocumentTypes> _docTypes;
        private ObservableCollection<User> _recipients;
        private ObservableCollection<Employee> _executors;
        private ObservableCollection<Deadlines> _deadlines;
        private ObservableCollection<SecrecyStamps> _secrecyStamp;
        private ObservableCollection<TaskStages> _taskStages;
        private ObservableCollection<DocStages> _docStages;

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

        private bool _isCheckedTask = true;
        public bool IsCheckedTask
        {
            get
            {
                return _isCheckedTask;
            }
            set
            {
                _isCheckedTask = value;
                OnPropertyChanged(nameof(IsCheckedTask));
                ClearErrors(nameof(CurrentTask));
            }
        }

        public IEnumerable<SecrecyStamps> ListSecrecyStamp => _secrecyStamp;
        public IEnumerable<DocStages> ListDocStages => _docStages;
        public IEnumerable<TaskStages> ListTaskStages => _taskStages;
        public IEnumerable<Tasks> Tasks => _tasks;
        public IEnumerable<Case> Case => _cases;
        public IEnumerable<DocumentTypes> DocTypes => _docTypes;
        public IEnumerable<User> Recipients => _recipients;
        public IEnumerable<Employee> Executors => _executors;
        public IEnumerable<Deadlines> Deadlines => _deadlines;

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
                ClearErrors(nameof(CurrentTask));

                if (CurrentTask == null)
                {
                    AddErrors("Необходимо выбрать значение из списка", nameof(CurrentTask));
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
                ClearErrors(nameof(CurrentDocTypes));

                if (CurrentDocTypes == null)
                {
                    AddErrors("Необходимо выбрать значение из списка", nameof(CurrentDocTypes));
                }
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
                ClearErrors(nameof(CurrentCase));

                if (CurrentCase == null)
                {
                    AddErrors("Необходимо выбрать значение из списка", nameof(CurrentCase));
                }
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
                ClearErrors(nameof(CurrentRecipient));

                if (CurrentRecipient == null)
                {
                    AddErrors("Необходимо выбрать значение из списка", nameof(CurrentRecipient));
                }
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
                ClearErrors(nameof(CurrentExecutor));

                if (CurrentExecutor == null)
                {
                    AddErrors("Необходимо выбрать значение из списка", nameof(CurrentExecutor));
                }
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
                ClearErrors(nameof(CurrentTerm));

                if (CurrentTerm == null)
                {
                    AddErrors("Необходимо выбрать значение из списка", nameof(CurrentTerm));
                }
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
                ClearErrors(nameof(CurrentSecrecyStamp));

                if (CurrentSecrecyStamp == null)
                {
                    AddErrors("Необходимо выбрать значение из списка", nameof(CurrentSecrecyStamp));
                }
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
                ClearErrors(nameof(CurrentTaskStages));

                if (CurrentTaskStages == null)
                {
                    AddErrors("Необходимо выбрать значение из списка", nameof(CurrentTaskStages));
                }
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
                ClearErrors(nameof(CurrentDocStages));

                if (CurrentDocStages == null)
                {
                    AddErrors("Необходимо выбрать значение из списка", nameof(CurrentDocStages));
                }
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

        public string UserCreateCard => CurrentUser.UserName;

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
                ClearErrors(nameof(RegistrationNumber));

                if (RegistrationNumber == null)
                {
                    AddErrors("Необходимо ввести значение", nameof(RegistrationNumber));
                }
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
                ClearErrors(nameof(NumberCard));

                if (NumberCard == null)
                {
                    AddErrors("Необходимо ввести значение", nameof(NumberCard));
                }
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
                ClearErrors(nameof(NameCard));

                if (NameCard == null)
                {
                    AddErrors("Необходимо ввести текст", nameof(NameCard));
                }
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
                ClearErrors(nameof(Summary));

                if (Summary == null)
                {
                    AddErrors("Необходимо ввести текст", nameof(Summary));
                }
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
                ClearErrors(nameof(NameTask));

                if (NameTask == null)
                {
                    AddErrors("Необходимо ввести текст", nameof(NameTask));
                }
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
                ClearErrors(nameof(ContentTask));

                if (ContentTask == null)
                {
                    AddErrors("Необходимо ввести текст", nameof(ContentTask));
                }
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

        private ICommand _addDocCommand;
        public ICommand NavigateRefundCommand { get; }
        public ICommand CreateCardCommand { get; }
        public ICommand AddDocCommand
        {
            get => _addDocCommand;
            set
            {
                _addDocCommand = value;
                OnPropertyChanged(nameof(AddDocCommand));
                //OpenFile();
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        public bool HasErrors => _propertyNameToErrorsDictionary.Any();
        #endregion

        public CreateCardViewModel(INavigationService navigationService, 
            OutgoingViewModel outgoingViewModel,
            IncomingViewModel incomingViewModel,
            UserStore userStore, 
            PASEDMDbContextFactory deferredContextFactory,
            OpenFileDialog openFileDialog)
        {
            _contextFactory = deferredContextFactory;
            
            _userStore = userStore;

            _propertyNameToErrorsDictionary = new Dictionary<string, List<string>>();

            GetExecutors();
            GetTasks();
            GetCases();
            GetRecipient();
            GetTaskStages();
            GetDocTyp();
            GetDeadlines();
            GetDocStages();
            GetSecrecyStamps();

            if (outgoingViewModel.CurrentMoveUser.Id != null)
            {
                _nameCard = outgoingViewModel.CurrentMoveUser.Card.NameCard;
                _docRegistrationNumber = outgoingViewModel.CurrentMoveUser.Card.Documents.RegistrationNumber;
                _numberCard = outgoingViewModel.CurrentMoveUser.Card.NumberCard;
                _summary = outgoingViewModel.CurrentMoveUser.Card.Documents.Summary;
                _comment = outgoingViewModel.CurrentMoveUser.Card.Comment;
                //_filePath = outgoingViewModel.CurrentMoveUser.Document.File;
                _docName = outgoingViewModel.CurrentMoveUser.Card.Documents.NameDoc;
                _dateOfFormation = outgoingViewModel.CurrentMoveUser.Card.DateOfFormation;
                CurrentTask = outgoingViewModel.CurrentMoveUser.Card.Tasks;
                CurrentTaskStages = outgoingViewModel.CurrentMoveUser.Card.Tasks.TaskStage;
                CurrentCase = outgoingViewModel.CurrentMoveUser.Card.Cases;
                CurrentDocStages = outgoingViewModel.CurrentMoveUser.Card.Documents.DocStages;
                CurrentDocTypes = outgoingViewModel.CurrentMoveUser.Card.Documents.DocumentTypes;
                CurrentExecutor = outgoingViewModel.CurrentMoveUser.Card.Employee;
                CurrentSecrecyStamp = outgoingViewModel.CurrentMoveUser.Card.Documents.SecrecyStamp;
                CurrentTerm = outgoingViewModel.CurrentMoveUser.Card.Documents.Term;
            }
            if (incomingViewModel.CurrentMoveUser.Id != null)
            {
                _nameCard = outgoingViewModel.CurrentMoveUser.Card.NameCard;
                _docRegistrationNumber = outgoingViewModel.CurrentMoveUser.Card.Documents.RegistrationNumber;
                _numberCard = outgoingViewModel.CurrentMoveUser.Card.NumberCard;
                _summary = outgoingViewModel.CurrentMoveUser.Card.Documents.Summary;
                _comment = outgoingViewModel.CurrentMoveUser.Card.Comment;
                //_filePath = outgoingViewModel.CurrentMoveUser.Document.File;
                _docName = outgoingViewModel.CurrentMoveUser.Card.Documents.NameDoc;
                _dateOfFormation = outgoingViewModel.CurrentMoveUser.Card.DateOfFormation;
                CurrentTask = outgoingViewModel.CurrentMoveUser.Card.Tasks;
                CurrentTaskStages = outgoingViewModel.CurrentMoveUser.Card.Tasks.TaskStage;
                CurrentCase = outgoingViewModel.CurrentMoveUser.Card.Cases;
                CurrentDocStages = outgoingViewModel.CurrentMoveUser.Card.Documents.DocStages;
                CurrentDocTypes = outgoingViewModel.CurrentMoveUser.Card.Documents.DocumentTypes;
                CurrentExecutor = outgoingViewModel.CurrentMoveUser.Card.Employee;
                CurrentSecrecyStamp = outgoingViewModel.CurrentMoveUser.Card.Documents.SecrecyStamp;
                CurrentTerm = outgoingViewModel.CurrentMoveUser.Card.Documents.Term;
            }

            NavigateRefundCommand = new NavigateCommand(navigationService); 
            CreateCardCommand = new CreateCardCommand(this, deferredContextFactory, navigationService);
            AddDocCommand = new CommandAdd();
        }
        private async void GetExecutors()
        {
            try
            {
                _employeeProvider = new DatabaseEmployeeProvider(_contextFactory);
                _executors = new ObservableCollection<Employee>();
                _currentExecutor = new Employee(_employeeProvider);

                foreach (var item in await _currentExecutor.GetAllEmployee())
                {
                    _executors.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void GetTasks()
        {
            try
            {
                _tasksProvider = new DatabaseTasksProvider(_contextFactory);
                _tasks = new ObservableCollection<Tasks>();
                _currentTask = new Tasks(_tasksProvider);

                foreach (var item in await _currentTask.GetAllTasks())
                {
                    _tasks.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void GetCases()
        {
            try
            {
                _casesProvider = new DatabaseCaseProvider(_contextFactory);
                _cases = new ObservableCollection<Case>();
                _currentCase = new Case(_casesProvider);

                foreach (var item in await _currentCase.GetAllCase())
                {
                    _cases.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void GetRecipient()
        {
            try
            {
                _userProvider = new DatabaseUserProvider(_contextFactory);
                _recipients = new ObservableCollection<User>();
                _currentRecipient = new User(_userProvider);

                foreach (var item in await _currentRecipient.GetAllUsers())
                {
                    if(_userStore.CurrentUser.Employee.FullName != item.Employee.FullName)
                    _recipients.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void GetTaskStages()
        {
            try
            {
                _taskStagesProvider = new DatabaseTaskStagesProvider(_contextFactory);
                _taskStages = new ObservableCollection<TaskStages>();
                _currentTaskStages = new TaskStages(_taskStagesProvider);

                foreach (var item in await _currentTaskStages.GetAllTaskStages())
                {
                    _taskStages.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void GetDocTyp()
        {
            try
            {
                _docTypProvider = new DatabaseDocTypProvider(_contextFactory);
                _docTypes = new ObservableCollection<DocumentTypes>();
                _currentDocTypes = new DocumentTypes(_docTypProvider);

                foreach (var item in await _currentDocTypes.GetAllDocTyp())
                {
                    _docTypes.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void GetDeadlines()
        {
            try
            {
                _deadlinesProvider = new DatabaseDeadlinesProvider(_contextFactory);
                _deadlines = new ObservableCollection<Deadlines>();
                _currentTerm = new Deadlines(_deadlinesProvider);

                foreach (var item in await _currentTerm.GetAllDeadlines())
                {
                    _deadlines.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void GetDocStages()
        {
            try
            {
                _docStagesProvider = new DatabaseDocStagesProvider(_contextFactory);
                _docStages = new ObservableCollection<DocStages>();
                _currentDocStages = new DocStages(_docStagesProvider);

                foreach (var item in await _currentDocStages.GetAllDocStages())
                {
                    _docStages.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void GetSecrecyStamps()
        {
            try
            {
                _secrecyStampsProvider = new DatabaseSecrecyStampsProvider(_contextFactory);
                _secrecyStamp = new ObservableCollection<SecrecyStamps>();
                _currentSecrecyStamp = new SecrecyStamps(_secrecyStampsProvider);

                foreach (var item in await _currentSecrecyStamp.GetAllSecrecyStamps())
                {
                    if(_userStore.CurrentUser.Employee.AccessRights.AccessRightsValue >= item.SecrecyStampValue)
                    _secrecyStamp.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyNameToErrorsDictionary.GetValueOrDefault(propertyName, new List<string>());
        }
        private void ClearErrors(string property)
        {
            _propertyNameToErrorsDictionary.Remove(property);
            OnErrorsChanged(property);
        }
        private void OnErrorsChanged(string property)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(property));
        }
        private void AddErrors(string errorMessage, string property)
        {
            if (!_propertyNameToErrorsDictionary.ContainsKey(property))
            {
                _propertyNameToErrorsDictionary.Add(property, new List<string>());
            }
            _propertyNameToErrorsDictionary[property].Add(errorMessage);
            OnErrorsChanged(property);
        }
        private void OpenFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            FilePath = openFile.FileName;
            DateOfFormationDocument = File.GetLastWriteTime(FilePath);
            /*return AddDocCommand = new SimpleCommand();*/
        }
    }
}