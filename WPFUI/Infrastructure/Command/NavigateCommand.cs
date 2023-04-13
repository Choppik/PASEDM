using PASEDM.Infrastructure.Command.Base;
using PASEDM.Services;

namespace PASEDM.Infrastructure.Command
{
    public class NavigateCommand : BaseCommand
    {
        private readonly INavigationService _navigationStore;

        public NavigateCommand(INavigationService navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.Navigate();
        }
    }
}
