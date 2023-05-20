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
    public class AccountConfirmationViewModel : BaseViewModels
    {
        private PASEDMDbContextFactory _contextFactory;
        private INavigationService _navigationService;
        private IUserProvider _userProvider;

        private bool _isActive;
        private bool _isLoading;
        private ObservableCollection<User> _users;
        private ICommand _navigateConfirmCommand;
        private User _currentUser;

        public IEnumerable<User> Users => _users;
        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
                IsActive = true;
                ConfirmCommand();
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
        public ICommand ConfirmUserCommand
        {
            get => _navigateConfirmCommand;
            set
            {
                _navigateConfirmCommand = value;
                OnPropertyChanged(nameof(ConfirmUserCommand));
            }
        }
        public AccountConfirmationViewModel(PASEDMDbContextFactory contextFactory, INavigationService navigationService)
        {
            _contextFactory = contextFactory;
            _navigationService = navigationService;

            GetUsers();
        }
        private ICommand ConfirmCommand() => ConfirmUserCommand = new ConfirmUserCommand(_currentUser, _contextFactory, _navigationService);
        private async void GetUsers()
        {
            try
            {
                IsLoading = true;
                _userProvider = new DatabaseUserProvider(_contextFactory);
                _users = new ObservableCollection<User>();
                _currentUser = new User(_userProvider);

                foreach (var item in await _currentUser.GetUserRecordConfirmation())
                {
                    _users.Add(item);
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