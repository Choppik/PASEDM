using PASEDM.Data;
using PASEDM.Infrastructure.Command;
using PASEDM.Models;
using PASEDM.Services;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class MyDocumentsViewModel : BaseViewModels
    {
        #region Переменные и свойства
        private PASEDMDbContextFactory _contextFactory;
        private IParamNavigationService<MyDocumentsViewModel> _parameterNavigationService;
        private INavigationService _navigationService;
        private readonly UserStore _userStore;

        private bool _isLoading;
        private bool _isActive;

        private ObservableCollection<MoveDocument> _moveDocument;

        private ICommand _navigateEditDocCommand;
        private ICommand _deleteDocumentCommand;

        private IMoveDocumentProvider _moveDocumentProvider;
        private MoveDocument _currentMoveDocument;
        public IEnumerable<MoveDocument> MoveDocuments => _moveDocument;
        public MoveDocument CurrentMoveDocument
        {
            get
            {
                return _currentMoveDocument;
            }
            set
            {
                _currentMoveDocument = value;
                OnPropertyChanged(nameof(CurrentMoveDocument));
                EditCommand();
                DeleteCommand();
                IsActive = true;
            }
        }
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
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
        public ICommand NavigateEditDocCommand
        {
            get => _navigateEditDocCommand;
            set
            {
                _navigateEditDocCommand = value;
                OnPropertyChanged(nameof(NavigateEditDocCommand));
            }
        }
        public ICommand DeleteDocumentCommand
        {
            get => _deleteDocumentCommand;
            set
            {
                _deleteDocumentCommand = value;
                OnPropertyChanged(nameof(DeleteDocumentCommand));
            }
        }
        public ICommand NavigateAddDocCommand { get; }
        #endregion
        public MyDocumentsViewModel(IParamNavigationService<MyDocumentsViewModel> parameterNavigationService,
            INavigationService navigationBackService,
            INavigationService navigationAddDocService,
            PASEDMDbContextFactory deferredContextFactory,
            UserStore userStore)
        {
            _navigationService = navigationBackService;
            _parameterNavigationService = parameterNavigationService;
            _contextFactory = deferredContextFactory;
            _userStore = userStore;

            NavigateAddDocCommand = new NavigateCommand(navigationAddDocService);
            GetMoveDoc();
        }
        private ICommand EditCommand() => NavigateEditDocCommand = new NavigateEditDocCommand(this, _parameterNavigationService);
        private ICommand DeleteCommand() => DeleteDocumentCommand = new DeleteDocCommand(_currentMoveDocument, _contextFactory, _navigationService);
        private async void GetMoveDoc()
        {
            try
            {
                IsLoading = true;
                _moveDocumentProvider = new DatabaseMoveDocumentProvider(_contextFactory);
                _moveDocument = new ObservableCollection<MoveDocument>();
                _currentMoveDocument = new MoveDocument(_moveDocumentProvider);

                foreach (var item in await _currentMoveDocument.GetAllMoveDocument(_userStore.CurrentUser))
                {
                    _moveDocument.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            IsLoading = false;
        }
    }
}