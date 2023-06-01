using MaterialDesignThemes.Wpf;
using PASEDM.Data;
using PASEDM.Models;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace PASEDM.ViewModels
{
    public class JournalViewModel : BaseViewModels
    {
        private PASEDMDbContextFactory _contextFactory;
        private readonly UserStore _userStore;

        private bool _isLoading;
        private ObservableCollection<MoveCard> _moveCard;
        private ObservableCollection<string> _moveCardStrList;
        private IMoveCardProvider _cardProvider;
        private MoveCard _currentMoveCard;
        private IMoveCardProvider _moveCardProvider;
        private string _moveCardStr;

        public JournalViewModel(PASEDMDbContextFactory contextFactory, UserStore userStore)
        {
            _contextFactory = contextFactory;
            _userStore = userStore;

            GetMoveCard();
        }
        public IEnumerable<string> MoveCardStrList => _moveCardStrList;
        public MoveCard CurrentMoveCard
        {
            get
            {
                return _currentMoveCard;
            }
            set
            {
                _currentMoveCard = value;
                OnPropertyChanged(nameof(CurrentMoveCard));
            }
        }
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        private async void GetMoveCard()
        {
            try
            {
                IsLoading = true;
                _moveCardProvider = new DatabaseMoveCardProvider(_contextFactory);
                _moveCardStrList = new ObservableCollection<string>();
                _currentMoveCard = new MoveCard(_moveCardProvider);

                foreach (var item in await _currentMoveCard.GetAllMoveUser(new(1)))
                {
                    if (item != null)
                    {

                        _moveCardStr = $"Пользователь ({item.Sender}) отправил документ ({item.Document.NameDoc}) с грифом секретности ({item.SecrecyStamps.NameSecrecyStamp}) пользователю ({item.Recipient.UserName}). Дата: {item.DateOfFormation}";
                        _moveCardStrList.Add(_moveCardStr);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            IsLoading = false;
        }
    }
}