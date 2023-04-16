using PASEDM.Store;
using PASEDM.ViewModels;
using PASEDM.ViewModels.Base;
using System;

namespace PASEDM.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService 
        where TViewModel : BaseViewModels
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly Func<NavigationBarViewModel> _createNavigationBarViewModel;

        public LayoutNavigationService(
            NavigationStore navigationStore, 
            Func<TViewModel> createViewModel, 
            Func<NavigationBarViewModel> createNavigationBarViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createNavigationBarViewModel = createNavigationBarViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new LayoutViewModel(_createNavigationBarViewModel(), _createViewModel());
        }
    }
}