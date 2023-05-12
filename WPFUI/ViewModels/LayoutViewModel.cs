using PASEDM.Models;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows;
using System;
using System.Windows.Input;
using PASEDM.Data;

namespace PASEDM.ViewModels
{
    public class LayoutViewModel : BaseViewModels
    {
        private IRoleProvider _roleProvider;

        private readonly PASEDMDbContextFactory _deferredContextFactory;

        private readonly UserStore _userStore;
        private int? _roleID => _userStore.CurrentUser.RoleID;
        private int _roleSign;

        private Role role;
        private bool _isAdmin;
        public bool IsAdmin
        {
            get
            {
                return _isAdmin;
            }
            set
            {
                _isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }
        public ICommand NavigateIncomingCommand { get; }
        public ICommand NavigateOutgoingCommand { get; }
        public ICommand NavigateNotificationCommand { get; }
        public ICommand NavigateJournalCommand { get; }
        public ICommand NavigateMeDocumemtCommand { get; }
        public ICommand NavigateMeTasksCommand { get; }
        public ICommand NavigateReferencesCommand { get; }
        public ICommand NavigateSettingsCommand { get; }
        public LayoutViewModel(
            UserStore userStore,
            PASEDMDbContextFactory deferredContextFactory,
            NavigationBarViewModel navigationBarViewModel, 
            BaseViewModels contentViewModels)
        {
            _userStore = userStore;
            _deferredContextFactory = deferredContextFactory;

            GetRole();

            NavigationBarViewModel = navigationBarViewModel;
            ContentViewModels = contentViewModels;

            NavigateIncomingCommand = navigationBarViewModel.NavigateIncomingCommand;
            NavigateOutgoingCommand = navigationBarViewModel.NavigateOutgoingCommand;
            NavigateNotificationCommand = navigationBarViewModel.NavigateNotificationCommand;
            NavigateJournalCommand = navigationBarViewModel.NavigateJournalCommand;
            NavigateMeDocumemtCommand = navigationBarViewModel.NavigateMeDocumemtCommand;
            NavigateMeTasksCommand = navigationBarViewModel.NavigateMeTasksCommand;
            NavigateReferencesCommand = navigationBarViewModel.NavigateReferencesCommand;
            NavigateSettingsCommand = navigationBarViewModel.NavigateSettingsCommand;
        }

        public NavigationBarViewModel NavigationBarViewModel { get; }
        public BaseViewModels ContentViewModels { get; }
        public override void Dispose()
        {
            NavigationBarViewModel.Dispose();
            ContentViewModels.Dispose();
            base.Dispose();
        }
        private async void GetRole()
        {
            try
            {
                _roleProvider = new DatabaseRoleProvider(_deferredContextFactory);
                role = new Role(_roleProvider);

                foreach (var item in await role.GetAllRole())
                {
                    if (item.Id == _roleID) _roleSign = item.SignificanceRole;
                }

                if (_roleSign == 0) IsAdmin = false; else IsAdmin = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}