using PASEDM.Data;
using PASEDM.Infrastructure.Command;
using PASEDM.Models;
using PASEDM.Services;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System;
using System.Windows;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class NotificationsViewModel : BaseViewModels
    {
        private PASEDMDbContextFactory _contextFactory;
        private INavigationService _navigationService;
        private readonly UserStore _userStore;

        private bool _isVisible;
        private int _moveCardCount;
        private string _moveCardStr;
        private ICommand _navigateIncCommand;
        private IMoveCardProvider _moveCardProvider;
        private MoveCard _currentMoveUser;

        public string MoveCardStr
        {
            get
            {
                return _moveCardStr;
            }
            set
            {
                _moveCardStr = value;
                OnPropertyChanged(nameof(MoveCardStr));
            }
        }
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }
        public ICommand NavigateIncCommand
        {
            get => _navigateIncCommand;
            set
            {
                _navigateIncCommand = value;
                OnPropertyChanged(nameof(NavigateIncCommand));
            }
        }

        public NotificationsViewModel(PASEDMDbContextFactory contextFactory, INavigationService navigationService, UserStore userStore)
        {
            _contextFactory = contextFactory;
            _userStore = userStore;
            _navigationService = navigationService;
            GetMoveUser();
            if (_moveCardCount == 0)
            {
                IsVisible = true;
            }

            NavigateIncCommand = new NavigateCommand(navigationService);
        }
        private void GetMoveUser()
        {
            try
            {
                _moveCardProvider = new DatabaseMoveCardProvider(_contextFactory);
                _currentMoveUser = new MoveCard(_moveCardProvider);
                _moveCardCount = _currentMoveUser.GetCountViewedMoveCard(_userStore.CurrentUser);
                _moveCardStr = $"У вас {_moveCardCount} новых входящих документов.";
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}