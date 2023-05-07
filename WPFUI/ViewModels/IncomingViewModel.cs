using PASEDM.Data;
using PASEDM.Infrastructure.Command;
using PASEDM.Models;
using PASEDM.Services;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class IncomingViewModel : BaseViewModels
    {
        private PASEDMDbContextFactory _contextFactory;
        private readonly UserStore _userStore;

        private ObservableCollection<Recipient> _recipients;
        private IRecipientProvider _recipientProvider;
        private Recipient _currentRecipient;
        public IEnumerable<Recipient> Recipients => _recipients;
        public Recipient CurrentRecipient
        {
            get
            {
                return _currentRecipient;
            }
            set
            {
                _currentRecipient = value;
                OnPropertyChanged(nameof(CurrentRecipient));
            }
        }
        public ICommand NavigateCreateCardCommand { get; }
        public IncomingViewModel(INavigationService navigationService, PASEDMDbContextFactory deferredContextFactory, UserStore userStore)
        {
            _contextFactory = deferredContextFactory;
            _userStore = userStore;
            GetRecipients();

            NavigateCreateCardCommand = new NavigateCommand(navigationService);
        }
        private async void GetRecipients()
        {
            try
            {
                _recipientProvider = new DatabaseRecipientProvider(_contextFactory);
                _recipients = new ObservableCollection<Recipient>();
                _currentRecipient = new Recipient(_recipientProvider);

                foreach (var item in await _currentRecipient.GetAllRecipient(_userStore.CurrentUser))
                {
                    _recipients.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}