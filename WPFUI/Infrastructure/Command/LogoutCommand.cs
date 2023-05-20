using PASEDM.Infrastructure.Command.Base;
using PASEDM.Services;
using PASEDM.Store;

namespace PASEDM.Infrastructure.Command
{
    public class LogoutCommand : BaseCommand
    {
        private readonly UserStore _userStore;
        private readonly INavigationService _navigationService;

        public LogoutCommand(UserStore userStore, INavigationService navigationService)
        {
            _userStore = userStore;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
            _userStore.Logout();
        }
    }
}