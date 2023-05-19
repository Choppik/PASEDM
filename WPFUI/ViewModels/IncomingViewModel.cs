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
using System.Windows.Navigation;

namespace PASEDM.ViewModels
{
    public class IncomingViewModel : BaseViewModels
    {
        #region Переменные и свойства
        private PASEDMDbContextFactory _contextFactory;
        private IParamNavigationService<IncomingViewModel> _parameterNavigationService;
        private INavigationService _navigationService;
        private readonly UserStore _userStore;

        private bool _isLoading;
        private ObservableCollection<MoveUser> _moveUser;
        private ICommand _navigateIncEditCardCommand;
        private ICommand _deleteCardCommand;
        private IMoveUserProvider _moveUserProvider;
        private MoveUser _currentMoveUser;
        public IEnumerable<MoveUser> MoveUsers => _moveUser;
        public MoveUser CurrentMoveUser
        {
            get
            {
                return _currentMoveUser;
            }
            set
            {
                _currentMoveUser = value;
                OnPropertyChanged(nameof(CurrentMoveUser));
                EditCommand();
                DeleteCommand();
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
        public ICommand NavigateIncEditCardCommand
        {
            get => _navigateIncEditCardCommand;
            set
            {
                _navigateIncEditCardCommand = value;
                OnPropertyChanged(nameof(NavigateIncEditCardCommand));
            }
        }
        public ICommand DeleteCardCommand
        {
            get => _deleteCardCommand;
            set
            {
                _deleteCardCommand = value;
                OnPropertyChanged(nameof(DeleteCardCommand));
            }
        }
        #endregion
        public IncomingViewModel(
            IParamNavigationService<IncomingViewModel> parameterNavigationService,
            INavigationService navigationService, 
            PASEDMDbContextFactory deferredContextFactory, 
            UserStore userStore)
        {
            _navigationService = navigationService;
            _parameterNavigationService = parameterNavigationService;
            _contextFactory = deferredContextFactory;
            _userStore = userStore;
            GetMoveUser();

            EditCommand();
            DeleteCommand();
        }
        private async void GetMoveUser()
        {
            try
            {
                IsLoading = true;
                _moveUserProvider = new DatabaseMoveUserProvider(_contextFactory);
                _moveUser = new ObservableCollection<MoveUser>();
                _currentMoveUser = new MoveUser(_moveUserProvider);

                foreach (var item in await _currentMoveUser.GetAllMoveUserRecipient(new(1), _userStore.CurrentUser))
                {
                    _moveUser.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            IsLoading = false;
        }
        private ICommand EditCommand() => NavigateIncEditCardCommand = new NavigateIncEditCardCommand(this, _parameterNavigationService);
        private ICommand DeleteCommand() => DeleteCardCommand = new DeleteCard(_currentMoveUser, _contextFactory, _navigationService);
    }
}