using PASEDM.ViewModels.Base;
using System;

namespace PASEDM.Store
{
    public class ModalNavigationStore
    {
        public event Action? CurrentViewModelChanged;
        public bool IsOpen => CurrentViewModel != null;

        private BaseViewModels? _currentViewModel;
        public BaseViewModels? CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        public void Close()
        {
            CurrentViewModel = null;
        }
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
