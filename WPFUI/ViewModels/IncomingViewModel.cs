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
    public class IncomingViewModel : BaseViewModels
    {
        #region Переменные и свойства
        private PASEDMDbContextFactory _contextFactory;
        private IParamNavigationService<IncomingViewModel> _parameterNavigationService;
        private IParamNavigationService<IncomingViewModel> _parameterNavigationService2;
        private INavigationService _navigationService;
        private readonly UserStore _userStore;

        private bool _isLoading;
        private bool _isPrivilege;
        private bool _isActive;
        private ObservableCollection<MoveCard> _moveCard;
        private ICommand _navigateIncEditCardCommand;
        private ICommand _navigateViewingCardCommand;
        private ICommand _deleteCardCommand;
        private IMoveCardProvider _moveCardProvider;
        private MoveCard _currentMoveCard;
        public IEnumerable<MoveCard> MoveCards => _moveCard;
        public MoveCard CurrentMoveUser
        {
            get
            {
                return _currentMoveCard;
            }
            set
            {
                _currentMoveCard = value;
                OnPropertyChanged(nameof(CurrentMoveUser));
                EditCommand();
                ViewingCommand();
                DeleteCommand();
                GetAccessRights();
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
        public bool IsPrivilege
        {
            get => _isPrivilege;
            set
            {
                _isPrivilege = value;
                OnPropertyChanged(nameof(IsPrivilege));
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
        public ICommand NavigateIncEditCardCommand
        {
            get => _navigateIncEditCardCommand;
            set
            {
                _navigateIncEditCardCommand = value;
                OnPropertyChanged(nameof(NavigateIncEditCardCommand));
            }
        }
        public ICommand NavigateViewingCardCommand
        {
            get => _navigateViewingCardCommand;
            set
            {
                _navigateViewingCardCommand = value;
                OnPropertyChanged(nameof(NavigateViewingCardCommand));
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
            IParamNavigationService<IncomingViewModel> parameterNavigationService2,
            INavigationService navigationService, 
            PASEDMDbContextFactory deferredContextFactory, 
            UserStore userStore)
        {
            _navigationService = navigationService;
            _parameterNavigationService = parameterNavigationService;
            _parameterNavigationService2 = parameterNavigationService2;
            _contextFactory = deferredContextFactory;
            _userStore = userStore;

            GetMoveUser();
        }
        private ICommand EditCommand() => NavigateIncEditCardCommand = new NavigateIncEditCardCommand(this, _parameterNavigationService);
        private ICommand ViewingCommand() => NavigateViewingCardCommand = new NavigateViewingCardCommand(this, _parameterNavigationService2);
        private ICommand DeleteCommand() => DeleteCardCommand = new DeleteCardCommand(_currentMoveCard, _contextFactory, _navigationService);
        private async void GetMoveUser()
        {
            try
            {
                IsLoading = true;
                _moveCardProvider = new DatabaseMoveCardProvider(_contextFactory);
                _moveCard = new ObservableCollection<MoveCard>();
                _currentMoveCard = new MoveCard(_moveCardProvider);
                TypeCard typeCard = new (1, "отправитель", 0);

                foreach (var item in await _currentMoveCard.GetAllMoveCard())
                {
                    if (item.TypeCard.TypeCardValue == typeCard.TypeCardValue && item.User.UserName != _userStore.CurrentUser.UserName)
                        _moveCard.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            IsLoading = false;
        }
        private void GetAccessRights()
        {
            IsPrivilege = true;
            if(_currentMoveCard.Id != null)
            {
                if(_userStore.CurrentUser.Employee.AccessRights.AccessRightsValue < _currentMoveCard.Card.Documents.SecrecyStamp.SecrecyStampValue)
                {
                    IsPrivilege = false;
                    MessageBox.Show("Недостаточно прав доступа", "Права доступа", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}