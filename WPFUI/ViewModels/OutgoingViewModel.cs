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

namespace PASEDM.ViewModels
{
    class OutgoingViewModel : BaseViewModels
    {
        private PASEDMDbContextFactory _contextFactory;

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
        public OutgoingViewModel(INavigationService navigationService, PASEDMDbContextFactory deferredContextFactory)
        {
            _contextFactory = deferredContextFactory;

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

                foreach (var item in await _currentCard.GetAllCard())
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