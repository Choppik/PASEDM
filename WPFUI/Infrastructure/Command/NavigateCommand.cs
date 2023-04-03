using PASEDM.Infrastructure.Command.Base;
using PASEDM.ViewModels.Base;
using PASEDM.Services;

namespace PASEDM.Infrastructure.Command
{
    public class NavigateCommand<TViewModel> : BaseCommand
        where TViewModel : BaseViewModels
    {
        private readonly INavigationService<TViewModel> _navigationStore;

        public NavigateCommand(INavigationService<TViewModel> navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.Navigate();
        }
    }
}
