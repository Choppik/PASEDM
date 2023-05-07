using PASEDM.Infrastructure.Command;
using PASEDM.Models;
using PASEDM.Services;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using PASEDM.Data;
using PASEDM.Store;

namespace PASEDM.ViewModels
{
    class OutgoingViewModel : BaseViewModels
    {
        private PASEDMDbContextFactory _contextFactory;
        private readonly UserStore _userStore;

        private ObservableCollection<Sender> _senders;
        private ISenderProvider _senderProvider;
        private Sender _currentSender;
        public IEnumerable<Sender> Senders => _senders;
        public Sender CurrentSender
        {
            get
            {
                return _currentSender;
            }
            set
            {
                _currentSender = value;
                OnPropertyChanged(nameof(CurrentSender));
            }
        }
        public ICommand NavigateCreateCardCommand { get; }
        public OutgoingViewModel(INavigationService navigationService, PASEDMDbContextFactory deferredContextFactory, UserStore userStore)
        {
            _contextFactory = deferredContextFactory;
            _userStore = userStore;

            GetSenders();

            NavigateCreateCardCommand = new NavigateCommand(navigationService);
        }
        private async void GetSenders()
        {
            try
            {
                _senderProvider = new DatabaseSenderProvider(_contextFactory);
                _senders = new ObservableCollection<Sender>();
                _currentSender = new Sender(_senderProvider);

                foreach (var item in await _currentSender.GetAllSender(_userStore.CurrentUser))
                {
                    _senders.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}