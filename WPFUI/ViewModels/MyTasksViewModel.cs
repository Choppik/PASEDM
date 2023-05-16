using PASEDM.Data;
using PASEDM.Models;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace PASEDM.ViewModels
{
    public class MyTasksViewModel : BaseViewModels
    {
        private PASEDMDbContextFactory _contextFactory;
        private readonly UserStore _userStore;

        private ObservableCollection<Card> _card;
        private ICardProvider _cardProvider;
        private Card _currentCard;

        public MyTasksViewModel(PASEDMDbContextFactory contextFactory, UserStore userStore)
        {
            _contextFactory = contextFactory;
            _userStore = userStore;
            GetMyTask();
        }

        public IEnumerable<Card> Card => _card;
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
        private async void GetMyTask()
        {
            try
            {
                _cardProvider = new DatabaseCardProvider(_contextFactory);
                _card = new ObservableCollection<Card>();
                _currentCard = new Card(_cardProvider);

                foreach (var item in await _currentCard.GetAllTaskExecutor(_userStore.CurrentUser))
                {
                    _card.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}