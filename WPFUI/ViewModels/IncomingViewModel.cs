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
using System.Windows.Navigation;

namespace PASEDM.ViewModels
{
    public class IncomingViewModel : BaseViewModels
    {
        private PASEDMDbContextFactory _contextFactory;
        private readonly UserStore _userStore;

        private ObservableCollection<Card> _cards;
        private ICardProvider _cardProvider;
        private Card _currentCard;
        public IEnumerable<Card> Cards => _cards;
        public Card CurrentCard
        {
            get
            {
                return _currentCard;
            }
            set
            {
                _currentCard = value;
                OnPropertyChanged(nameof(CurrentCard));
            }
        }
        public ICommand NavigateCreateCardCommand { get; }
        public IncomingViewModel(INavigationService navigationService, PASEDMDbContextFactory deferredContextFactory, UserStore userStore)
        {
            _contextFactory = deferredContextFactory;
            _userStore = userStore;
            GetExecutors();

            NavigateCreateCardCommand = new NavigateCommand(navigationService);
        }
        private async void GetExecutors()
        {
            try
            {
                _cardProvider = new DatabaseCardProvider(_contextFactory);
                _cards = new ObservableCollection<Card>();
                _currentCard = new Card(_cardProvider);

                foreach (var item in await _currentCard.GetAllCardForRecipient(_userStore.CurrentUser))
                {
                    _cards.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}