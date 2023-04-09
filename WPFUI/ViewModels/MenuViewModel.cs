using PASEDM.Infrastructure.Command;
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
        public string Name => _user.CurrentUser?.UserName;
        public ICommand NavigateHomeCommand { get; }
        public MenuViewModel(UserStore userStore, INavigationService homeNavigationService)
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
