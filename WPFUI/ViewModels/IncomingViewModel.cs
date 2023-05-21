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
        private INavigationService _navigationService;
        private readonly UserStore _userStore;

        private bool _isLoading;
        private bool _isPrivilege;
        private bool _isActive;
        private ObservableCollection<MoveCard> _moveCard;
        private ICommand _navigateIncEditCardCommand;
        private ICommand _deleteCardCommand;
        private IMoveCardProvider _moveCardProvider;
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
        }
        private ICommand EditCommand() => NavigateIncEditCardCommand = new NavigateIncEditCardCommand(this, _parameterNavigationService);
        private ICommand DeleteCommand() => DeleteCardCommand = new DeleteCardCommand(_currentMoveUser, _contextFactory, _navigationService);
        private async void GetMoveUser()
        {
            try
            {
                IsLoading = true;
                _moveCardProvider = new DatabaseMoveCardProvider(_contextFactory);
                _moveCard = new ObservableCollection<MoveCard>();
                _currentMoveUser = new MoveCard(_moveCardProvider);

                foreach (var item in await _currentMoveUser.GetAllMoveUserRecipient(new(2), _userStore.CurrentUser))
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
        private void GetAccessRights()
        {
            IsPrivilege = true;
            if(_currentMoveUser.Id != null)
            {
                if(_userStore.CurrentUser.Employee.AccessRights.AccessRightsValue < _currentMoveUser.Document.SecrecyStamp.SecrecyStampValue)
                {
                    IsPrivilege = false;
                    MessageBox.Show("Недостаточно прав доступа", "Права доступа", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}