using PASEDM.Infrastructure.Command.Base;
using PASEDM.Services;

namespace PASEDM.Infrastructure.Command
{
    public class NavigateCommand : BaseCommand
    {
        private readonly INavigationService _navigationService;

        public NavigateCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}