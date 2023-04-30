using PASEDM.Data;
using PASEDM.Infrastructure.Command;
using PASEDM.Models;
using PASEDM.Services;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class CreateCardViewModel : BaseViewModels
    {
        private IEmployeeProvider _employeeProvider;
        private ITasksProvider _tasksProvider;

        private readonly UserStore _userStore;

        private PASEDMDbContextFactory _contextFactory;

        private readonly List<string> _listSecrecyStamp = new() 
        { 
            "Не секретно",
            "Секретно", 
            "Совершенно секретно",
            "Особая важность"
        };
        private readonly List<string> _listTaskStages = new () 
        { 
            "Стадия анализа задачи", 
            "Стадия поиска решения задачи", 
            "Стадия выполнения задачи", 
            "Стадия проверки выполненной задачи",
            "Задача выполнена"
        };
        private readonly List<string> _listDocStages = new()
        {
            "Поставлен на контроль",
            "Проверка своевременности доведения до исполнителей",
            "Проверка и регулирование хода исполнения",
            "Учет и обобщение результатов контроля исполнения",
            "Снят с контроля",
            "Не нуждается в контроле исполнения"
        };

        private ObservableCollection<Tasks> _tasks;
        private ObservableCollection<Case> _cases;
        private ObservableCollection<DocumentTypes> _docTypes;
        private ObservableCollection<User> _recipients;
        private ObservableCollection<Employee> _executors;
        private ObservableCollection<Deadlines> _deadlines;

        private Tasks _currentTask;
        private Case _currentCase;
        private DocumentTypes _currentDocTypes;
        private Recipient _currentRecipient;
        private Employee _currentExecutor;
        private Deadlines _currentTerm;
        //private User _userCreateCard;

        private DateTime _dateOfFormation = DateTime.Now;
        private DateTime _dateOfFormationDocument = DateTime.Now;

        private string _nameCard;
        private string _numberCard;
        private string _secrecyStamp;
        private string _summary;
        private string _conditionDoc;
        private string _conditionTask;
        private string _сomment;
        //private string _filePath;
        private string _docName;
        private string _docRegistrationNumber;
        public IEnumerable<string> ListSecrecyStamp => _listSecrecyStamp;
        public IEnumerable<string> ListDocStages => _listDocStages;
        public IEnumerable<string> ListTaskStages => _listTaskStages;
        public IEnumerable<Tasks> Tasks => _tasks; //2
        public IEnumerable<Case> Case => _cases;
        public IEnumerable<DocumentTypes> DocTypes => _docTypes;
        public IEnumerable<User> Recipients => _recipients;
        public IEnumerable<Employee> Executors => _executors; //1
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
        public Recipient CurrentRecipient
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

        public string UserCreateCard => _userStore.CurrentUser.UserName;
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
        public string NumberCard
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
        public string SecrecyStamp
        {
            get
            {
                return _secrecyStamp;
            }
            set
            {
                _secrecyStamp = value;
                OnPropertyChanged(nameof(SecrecyStamp));
            }
        }
        public string Comment
        {
            get
            {
                return _сomment;
            }
            set
            {
                _сomment = value;
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
        public string RegistrationNumber
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
        public string ConditionDoc
        {
            get
            {
                return _conditionDoc;
            }
            set
            {
                _conditionDoc = value;
                OnPropertyChanged(nameof(ConditionDoc));
            }
        }
        public string ConditionTask
        {
            get
            {
                return _conditionTask;
            }
            set
            {
                _conditionTask = value;
                OnPropertyChanged(nameof(ConditionTask));
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

        public ICommand NavigateRefundCommand { get; }

        public CreateCardViewModel(INavigationService navigationService, UserStore userStore, PASEDMDbContextFactory deferredContextFactory)
        {
            _contextFactory = deferredContextFactory;
            
            _userStore = userStore;

            GetExecutors();
            GetTasks();

            NavigateRefundCommand = new NavigateCommand(navigationService);
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
    }
}