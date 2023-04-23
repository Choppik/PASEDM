using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System;

namespace PASEDM.Services
{
    public class ModalNavigationService<TViewModel> : INavigationService
        where TViewModel : BaseViewModels
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public ModalNavigationService(ModalNavigationStore modalNavigationStore, Func<TViewModel> createViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _modalNavigationStore.CurrentViewModel = _createViewModel();
        }
    }
}