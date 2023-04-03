﻿using PASEDM.Infrastructure.Command;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;
using PASEDM.Services;
using PASEDM.Models;

namespace PASEDM.ViewModels
{
    public class MenuViewModel : BaseViewModels
    {
        private readonly UserStore _user;
        public string Name => _user.CurrentUser?.Login;
        public ICommand NavigateHomeCommand { get; }
        public MenuViewModel(UserStore userStore, INavigationService<UserEntryViewModel> homeNavigationService)
        {
            _user = userStore;

            NavigateHomeCommand = new NavigateCommand<UserEntryViewModel>(homeNavigationService);
        }
    }
}
