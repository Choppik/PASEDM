using PASEDM.Store;
using PASEDM.ViewModels.Base;

namespace PASEDM.ViewModels
{
    public class MainWindowViewModel : BaseViewModels
    {
        private readonly NavigationStore _navigationStore;
        public BaseViewModels CurrentViewModel => _navigationStore.CurrentViewModel;

        #region Заголовок окна
        private string _title = "PASEDM";

        public string Title { get => _title; set => Set(ref _title, value); }
        #endregion

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChange += OnCurrentViewModelChange;
        }

        private void OnCurrentViewModelChange()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}