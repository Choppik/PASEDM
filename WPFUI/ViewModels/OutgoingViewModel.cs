using PASEDM.Infrastructure.Command;
using PASEDM.Models;
using PASEDM.Services;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using PASEDM.Data;
using PASEDM.Store;

namespace PASEDM.ViewModels
{
    public class OutgoingViewModel : BaseViewModels
    {
        #region Переменные и свойства
        private readonly UserStore _userStore;
        private PASEDMDbContextFactory _contextFactory;
        private IParamNavigationService<OutgoingViewModel> _parameterNavigationService;
        private INavigationService _navigationService;
        private INavigationService _navigationServiceBack;

        private bool _isLoading;
        private bool _isActive;
        private ICommand _navigateOutEditCardCommand;
        private ICommand _deleteCardCommand;
        private ObservableCollection<MoveCard> _moveCard;
        private IMoveCardProvider _moveUserProvider;
        private MoveCard _currentMoveUser;
        public IEnumerable<MoveCard> MoveCards => _moveCard;
        public MoveCard CurrentMoveUser
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

        public ICommand NavigateCreateCardCommand { get; }
        public ICommand NavigateOutEditCardCommand
        {
            get => _navigateOutEditCardCommand;
            set
            {
                _navigateOutEditCardCommand = value;
                OnPropertyChanged(nameof(NavigateOutEditCardCommand));
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

        public OutgoingViewModel(
            IParamNavigationService<OutgoingViewModel> parameterNavigationService,
            INavigationService navigationService, 
            INavigationService navigationServiceBack, 
            PASEDMDbContextFactory deferredContextFactory, 
            UserStore userStore)
        {
            _parameterNavigationService = parameterNavigationService;
            _contextFactory = deferredContextFactory;
            _userStore = userStore;
            _navigationService = navigationService;
            _navigationServiceBack = navigationServiceBack;

            GetMoveUser();

            NavigateCreateCardCommand = new NavigateCommand(navigationService);
        }
        private async void GetMoveUser()
        {
            try
            {
                IsLoading = true;
                _moveUserProvider = new DatabaseMoveCardProvider(_contextFactory);
                _moveCard = new ObservableCollection<MoveCard>();
                _currentMoveUser = new MoveCard(_moveUserProvider);

                foreach (var item in await _currentMoveUser.GetAllMoveUserSender(new(2), _userStore.CurrentUser))
                {
                    _moveCard.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            IsLoading = false;
        }
        private ICommand EditCommand() => NavigateOutEditCardCommand = new NavigateOutEditCardCommand(this, _parameterNavigationService);
        private ICommand DeleteCommand() => DeleteCardCommand = new DeleteCardCommand(_currentMoveUser, _contextFactory, _navigationServiceBack);
    }
}