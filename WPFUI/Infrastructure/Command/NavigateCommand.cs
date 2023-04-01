using PASEDM.Infrastructure.Command.Base;
using PASEDM.ViewModels.Base;
using PASEDM.Services;

namespace PASEDM.Infrastructure.Command
{
    public class NavigateCommand<TViewModel> : BaseCommand
        where TViewModel : BaseViewModels
    {
        private readonly NavigationService<TViewModel> _navigationStore;

        public NavigateCommand(NavigationService<TViewModel> navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.Navigate();
        }
    }
}
