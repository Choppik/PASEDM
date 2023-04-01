using PASEDM.Infrastructure.Command.Base;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System;

namespace PASEDM.Infrastructure.Command
{
    public class NavigateCommand<TViewModel> : BaseCommand
        where TViewModel : BaseViewModels
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
