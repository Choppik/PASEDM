using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System;

namespace PASEDM.Services
{

    /// <summary>
    /// Не используется, но может пригодиться
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    public class ParameterNavigationService<TParameter, TViewModel>
        where TViewModel : BaseViewModels
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TParameter, TViewModel> _createViewModel;

        public ParameterNavigationService(NavigationStore navigationStore, Func<TParameter, TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate(TParameter parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel(parameter);
        }
    }
}