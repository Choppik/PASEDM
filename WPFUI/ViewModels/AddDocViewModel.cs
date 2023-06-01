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
using System.Windows;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class AddDocViewModel : BaseViewModels
    {
        #region Переменные и свойтва
        private readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;

        private IDocTypProvider _docTypProvider;
        private IUserProvider _userProvider;
        private IDeadlinesProvider _deadlinesProvider;
        private IDocStagesProvider _docStagesProvider;
        private ISecrecyStampsProvider _secrecyStampsProvider;

        private readonly UserStore _userStore;

        private PASEDMDbContextFactory _contextFactory;

        private ObservableCollection<DocumentTypes> _docTypes;
        private ObservableCollection<Deadlines> _deadlines;
        private ObservableCollection<SecrecyStamps> _secrecyStamp;
        private ObservableCollection<DocStages> _docStages;

        private DocumentTypes _currentDocTypes;
        private Deadlines _currentTerm;
        private SecrecyStamps _currentSecrecyStamp;
        private DocStages _currentDocStages;

        private DateTime _dateOfFormationDocument = DateTime.Now;

        private int _docRegistrationNumber;
        private string _summary;
        private string _filePath;
        private string _docName = "text";

        public IEnumerable<SecrecyStamps> ListSecrecyStamp => _secrecyStamp;
        public IEnumerable<DocStages> ListDocStages => _docStages;
        public IEnumerable<DocumentTypes> DocTypes => _docTypes;
        public IEnumerable<Deadlines> Deadlines => _deadlines;

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

        private ICommand _openDocCommand;
        public ICommand NavigateRefundCommand { get; }
        public ICommand AddDocCommand { get; }
        public ICommand OpenDocCommand
        {
            get => _openDocCommand;
            set
            {
                _openDocCommand = value;
                OnPropertyChanged(nameof(OpenDocCommand));
                //OpenFile();
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        //public bool HasErrors => _propertyNameToErrorsDictionary.Any();
        #endregion

        public AddDocViewModel(INavigationService navigationService,
            MyDocumentsViewModel myDocumentsViewModel, 
            UserStore userStore,
            PASEDMDbContextFactory contextFactory)
        {
            _userStore = userStore;
            _contextFactory = contextFactory;

            GetDocTyp();
            GetDeadlines();
            GetDocStages();
            GetSecrecyStamps();

            if (myDocumentsViewModel.CurrentMoveDocument.Id != 0)
            {
                _docRegistrationNumber = myDocumentsViewModel.CurrentMoveDocument.Document.RegistrationNumber;
                _summary = myDocumentsViewModel.CurrentMoveDocument.Document.Summary;
               // _filePath = myDocumentsViewModel.CurrentMoveDocument.Document.File;
                _docName = myDocumentsViewModel.CurrentMoveDocument.Document.NameDoc;
                CurrentDocStages = myDocumentsViewModel.CurrentMoveDocument.Document.DocStages;
                CurrentDocTypes = myDocumentsViewModel.CurrentMoveDocument.Document.DocumentTypes;
                CurrentSecrecyStamp = myDocumentsViewModel.CurrentMoveDocument.Document.SecrecyStamp;
                CurrentTerm = myDocumentsViewModel.CurrentMoveDocument.Document.Term;
            }

            NavigateRefundCommand = new NavigateCommand(navigationService);
            AddDocCommand = new AddDocCommand(this, contextFactory, navigationService);
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
                    if (_userStore.CurrentUser.Employee.AccessRights.AccessRightsValue >= item.SecrecyStampValue)
                        _secrecyStamp.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public IEnumerable GetErrors(string? propertyName)
        {
            throw new NotImplementedException();
        }
    }
}