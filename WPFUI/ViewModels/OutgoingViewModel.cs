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
    class OutgoingViewModel : BaseViewModels
    {
        private PASEDMDbContextFactory _contextFactory;
        private readonly UserStore _userStore;

        private ObservableCollection<MoveUser> _moveUser;
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
            }
        }
        public ICommand NavigateCreateCardCommand { get; }
        public OutgoingViewModel(INavigationService navigationService, PASEDMDbContextFactory deferredContextFactory, UserStore userStore)
        {
            _contextFactory = deferredContextFactory;
            _userStore = userStore;

            GetMoveUser();

            NavigateCreateCardCommand = new NavigateCommand(navigationService);
        }
        private async void GetMoveUser()
        {
            try
            {
                _moveUserProvider = new DatabaseMoveUserProvider(_contextFactory);
                _moveUser = new ObservableCollection<MoveUser>();
                _currentMoveUser = new MoveUser(_moveUserProvider);

                foreach (var item in await _currentMoveUser.GetAllMoveUserSender(new(2), _userStore.CurrentUser))
                {
                    _moveUser.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}