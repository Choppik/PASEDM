using PASEDM.Data;
using PASEDM.Models;
using PASEDM.Services;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class ReferencesViewModel : BaseViewModels
    {
        private readonly PASEDMDbContextFactory _contextFactory;
        private readonly UserStore _userStore;

        private ISecrecyStampsProvider _secrecyStampsProvider;
        private IEmployeeProvider _employeeProvider;
        private ICasesProvider _casesProvider;
        private IDocTypProvider _docTypProvider;
        private IDeadlinesProvider _deadlinesProvider;
        private ITaskStagesProvider _taskStagesProvider;
        private IDocStagesProvider _docStagesProvider;
        private IDivisionProvider _divisionProvider;
        private IAccessRightsProvider _accessRightsProvider;
        private ITypeUserProvider _typeUserProvider;
        private IRoleProvider _roleProvider;

        private bool _isActive;

        private ObservableCollection<SecrecyStamps> _secrecyStamps;
        private ObservableCollection<Case> _cases;
        private ObservableCollection<DocumentTypes> _docTypes;
        private ObservableCollection<Employee> _employee;
        private ObservableCollection<Deadlines> _deadlines;
        private ObservableCollection<TaskStages> _taskStages;
        private ObservableCollection<DocStages> _docStages;
        private ObservableCollection<Division> _divisions;
        private ObservableCollection<AccessRights> _accessRights;
        private ObservableCollection<Role> _role;
        private ObservableCollection<TypeUser> _typeUser;

        private SecrecyStamps _currentSecrecyStamp;
        private Case _currentCase;
        private DocumentTypes _currentDocTypes;
        private Employee _currentEmployee;
        private Deadlines _currentTerm;
        private TaskStages _currentTaskStages;
        private DocStages _currentDocStages;
        private Division _currentDivisions;
        private AccessRights _currentAccessRights;
        private Role _currentRole;
        private TypeUser _currentTypeUser;

        private ICommand _saveCommand;
        private ICommand _deleteCommand;
        public ObservableCollection<SecrecyStamps> SecrecyStamps
        {
            get => _secrecyStamps;
            set
            {
                _secrecyStamps = value;
                OnPropertyChanged(nameof(SecrecyStamps));
            }
        }
        public ObservableCollection<Case> Cases
        {
            get => _cases;
            set
            {
                _cases = value;
                OnPropertyChanged(nameof(Cases));
            }
        }
        public ObservableCollection<DocumentTypes> DocTypes
        {
            get => _docTypes;
            set
            {
                _docTypes = value;
                OnPropertyChanged(nameof(DocTypes));
            }
        }
        public ObservableCollection<Employee> Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                OnPropertyChanged(nameof(Employee));
            }
        }
        public ObservableCollection<Deadlines> Deadlines
        {
            get => _deadlines;
            set
            {
                _deadlines = value;
                OnPropertyChanged(nameof(Deadlines));
            }
        }
        public ObservableCollection<TaskStages> TaskStages
        {
            get => _taskStages;
            set
            {
                _taskStages = value;
                OnPropertyChanged(nameof(TaskStages));
            }
        }
        public ObservableCollection<DocStages> DocStages
        {
            get => _docStages;
            set
            {
                _docStages = value;
                OnPropertyChanged(nameof(DocStages));
            }
        }
        public ObservableCollection<Division> Divisions
        {
            get => _divisions;
            set
            {
                _divisions = value;
                OnPropertyChanged(nameof(Divisions));
            }
        }
        public ObservableCollection<AccessRights> AccessRights
        {
            get => _accessRights;
            set
            {
                _accessRights = value;
                OnPropertyChanged(nameof(AccessRights));
            }
        }
        public ObservableCollection<Role> Role
        {
            get => _role;
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }
        public ObservableCollection<TypeUser> TypeUser
        {
            get => _typeUser;
            set
            {
                _typeUser = value;
                OnPropertyChanged(nameof(TypeUser));
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
                OnPropertyChanged(nameof(SecrecyStamps));
                IsActive = true;
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
        public Employee CurrentEmployee
        {
            get
            {
                return _currentEmployee;
            }
            set
            {
                _currentEmployee = value;
                OnPropertyChanged(nameof(CurrentEmployee));
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
        public Division CurrentDivision
        {
            get
            {
                return _currentDivisions;
            }
            set
            {
                _currentDivisions = value;
                OnPropertyChanged(nameof(CurrentDivision));
            }
        }
        public AccessRights CurrentAccessRights
        {
            get
            {
                return _currentAccessRights;
            }
            set
            {
                _currentAccessRights = value;
                OnPropertyChanged(nameof(CurrentAccessRights));
            }
        }
        public Role CurrentRole
        {
            get
            {
                return _currentRole;
            }
            set
            {
                _currentRole = value;
                OnPropertyChanged(nameof(CurrentRole));
            }
        }
        public TypeUser CurrentTypeUser
        {
            get
            {
                return _currentTypeUser;
            }
            set
            {
                _currentTypeUser = value;
                OnPropertyChanged(nameof(CurrentTypeUser));
            }
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }
        public ICommand SaveCommand
        {
            get => _saveCommand;
            set
            {
                _saveCommand = value;
                OnPropertyChanged(nameof(SaveCommand));
            }
        }
        public ICommand DeleteCommand
        {
            get => _deleteCommand;
            set
            {
                _deleteCommand = value;
                OnPropertyChanged(nameof(DeleteCommand));
            }
        }


        public ReferencesViewModel(PASEDMDbContextFactory contextFactory, UserStore userStore)
        {
            _contextFactory = contextFactory;
            _userStore = userStore;


            GetSecrecyStamps();
            GetCases();
            GetDeadlines();
            GetDocStages();
            GetTaskStages();
            GetDocType();
            GetEmployee();
            GetDivisions();
            GetRole();
            GetAccessRights();
            GetTypeUser();


        }
        private async void GetSecrecyStamps()
        {
            try
            {
                _secrecyStampsProvider = new DatabaseSecrecyStampsProvider(_contextFactory);
                _secrecyStamps = new ObservableCollection<SecrecyStamps>();
                _currentSecrecyStamp = new SecrecyStamps(_secrecyStampsProvider);

                foreach (var item in await _currentSecrecyStamp.GetAllSecrecyStamps())
                {
                    _secrecyStamps.Add(item);
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
        private async void GetEmployee()
        {
            try
            {
                _employeeProvider = new DatabaseEmployeeProvider(_contextFactory);
                _employee = new ObservableCollection<Employee>();
                _currentEmployee = new Employee(_employeeProvider);

                foreach (var item in await _currentEmployee.GetAllEmployee())
                {
                    _employee.Add(item);
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
        private async void GetDocType()
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
        private async void GetDivisions()
        {
            try
            {
                _divisionProvider = new DatabaseDivisionProvider(_contextFactory);
                _divisions = new ObservableCollection<Division>();
                _currentDivisions = new Division(_divisionProvider);

                foreach (var item in await _currentDivisions.GetAllDivisions())
                {
                    _divisions.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void GetRole()
        {
            try
            {
                _roleProvider = new DatabaseRoleProvider(_contextFactory);
                _role = new ObservableCollection<Role>();
                _currentRole = new Role(_roleProvider);

                foreach (var item in await _currentRole.GetAllRole())
                {
                    _role.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void GetAccessRights()
        {
            try
            {
                _accessRightsProvider = new DatabaseAccessRightsProvider(_contextFactory);
                _accessRights = new ObservableCollection<AccessRights>();
                _currentAccessRights = new AccessRights(_accessRightsProvider);

                foreach (var item in await _currentAccessRights.GetAllAccessRights())
                {
                    _accessRights.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void GetTypeUser()
        {
            try
            {
                _typeUserProvider = new DatabaseTypeUserProvider(_contextFactory);
                _typeUser = new ObservableCollection<TypeUser>();
                _currentTypeUser = new TypeUser(_typeUserProvider);

                foreach (var item in await _currentTypeUser.GetAllTypeUsers())
                {
                    _typeUser.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}