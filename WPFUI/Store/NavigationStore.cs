﻿using PASEDM.ViewModels.Base;
using System;

namespace PASEDM.Store
{
    public class NavigationStore
    {
        public event Action CurrentViewModelChange;

        private BaseViewModels? _currentViewModel;
        public BaseViewModels CurrentViewModel
        { 
            get => _currentViewModel; 
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChange?.Invoke();
        }
    }
}