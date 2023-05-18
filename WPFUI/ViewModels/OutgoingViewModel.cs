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
using System.ComponentModel;
using System.Collections;
using System.Linq;

namespace PASEDM.ViewModels
{
    public class OutgoingViewModel : BaseViewModels
    {
        #region Переменные и свойства
        private readonly UserStore _userStore;
        private PASEDMDbContextFactory _contextFactory;
        private IParamNavigationService<OutgoingViewModel> _parameterNavigationService;
        private INavigationService _navigationService;

        private bool _isLoading;
        private ICommand _navigateEditCardCommand;
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
                EditCommand();
                OnPropertyChanged(nameof(CurrentMoveUser));
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

        public ICommand NavigateCreateCardCommand { get; }
        public ICommand NavigateEditCardCommand
        {
            get => _navigateEditCardCommand;
            set
            {
                _navigateEditCardCommand = value;
                OnPropertyChanged(nameof(NavigateEditCardCommand));
            }
        }
        #endregion


        public OutgoingViewModel(
            IParamNavigationService<OutgoingViewModel> parameterNavigationService,
            INavigationService navigationService, 
            PASEDMDbContextFactory deferredContextFactory, 
            UserStore userStore)
        {
            _parameterNavigationService = parameterNavigationService;
            _contextFactory = deferredContextFactory;
            _userStore = userStore;
            _navigationService = navigationService;

            GetMoveUser();

            NavigateCreateCardCommand = new NavigateCommand(navigationService);
            EditCommand();
        }
        private async void GetMoveUser()
        {
            try
            {
                IsLoading = true;
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
            IsLoading = false;
        }
        private ICommand EditCommand() => NavigateEditCardCommand = new NavigateEditCardCommand(this, _parameterNavigationService);
    }
}