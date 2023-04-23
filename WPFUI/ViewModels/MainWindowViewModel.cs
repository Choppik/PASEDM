using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System;

namespace PASEDM.ViewModels
{
    public class MainWindowViewModel : BaseViewModels
    {
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        public BaseViewModels? CurrentViewModel => _navigationStore.CurrentViewModel;
        public BaseViewModels? CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public bool IsOpen => _modalNavigationStore.IsOpen;

        #region Заголовок окна
        private string _title = "PASEDM";

        public string Title { get => _title; set => Set(ref _title, value); }
        #endregion

        public MainWindowViewModel(NavigationStore navigationStore, ModalNavigationStore modalNavigationStore)
        {
            _navigationStore = navigationStore;
            _modalNavigationStore = modalNavigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChange;
            _modalNavigationStore.CurrentViewModelChanged += OnCurrentModalViewModelChange;
        }

        private void OnCurrentModalViewModelChange()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsOpen));
        }

        private void OnCurrentViewModelChange()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}