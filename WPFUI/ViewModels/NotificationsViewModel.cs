﻿using PASEDM.Infrastructure.Command;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;
using PASEDM.Services;

namespace PASEDM.ViewModels
{

    /// <summary>
    /// Пока не используется полноценно
    /// </summary>
    public class NotificationsViewModel : BaseViewModels
    {
        private readonly UserStore _user;
        public string? Name => _user.CurrentUser.UserName;
        public ICommand NavigateHomeCommand { get; }
        public NotificationsViewModel(UserStore userStore, INavigationService homeNavigationService)
        {
            _user = userStore;

            NavigateHomeCommand = new NavigateCommand(homeNavigationService);

            _user.CurrentUserChanged += OnCurrentUserChanged;
        }

        private void OnCurrentUserChanged()
        {
            OnPropertyChanged(nameof(Name));
        }
        public override void Dispose() 
        {
            _user.CurrentUserChanged -= OnCurrentUserChanged;
            base.Dispose();
        }
    }
}