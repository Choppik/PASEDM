using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System;

namespace PASEDM.Services
{
    public class NavigationService<TViewModel>
        where TViewModel : BaseViewModels
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate() 
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
