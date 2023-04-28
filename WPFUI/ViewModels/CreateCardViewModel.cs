using PASEDM.Infrastructure.Command;
using PASEDM.Models;
using PASEDM.Services;
using PASEDM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class CreateCardViewModel : BaseViewModels
    {
        private readonly List<string> _listSecrecyStamp = new() { "Секретно", "Чрезвычайно секретно", "Не секретно" };

        private string _nameCard;
        private string _numberCard;
        private DateTime _dateOfFormation;
        private string _secrecyStamp;
        private string _summary;
        private string _condition;
        private string _сomment;
        private string _filePath;
        private string _documentRegistrationNumber;
        private DateTime _FateOfFormationDocument;
        public IEnumerable<string> ListSecrecyStamp => _listSecrecyStamp;
        public string NameCard
        {
            get
            {
                return _nameCard;
            }
            set
            {
                _nameCard = value;
                OnPropertyChanged(nameof(NameCard));
            }
        }
        public string NumberCard
        {
            get
            {
                return _numberCard;
            }
            set
            {
                _numberCard = value;
                OnPropertyChanged(nameof(NumberCard));
            }
        }
        public DateTime DateOfFormation
        {
            get
            {
                return _dateOfFormation;
            }
            set
            {
                _dateOfFormation = value;
                OnPropertyChanged(nameof(DateOfFormation));
            }
        }
        public string SecrecyStamp
        {
            get
            {
                return _secrecyStamp;
            }
            set
            {
                _secrecyStamp = value;
                OnPropertyChanged(nameof(SecrecyStamp));
            }
        }

        public ICommand NavigateRefundCommand { get; }

        public CreateCardViewModel(INavigationService navigationService)
        {
            NavigateRefundCommand = new NavigateCommand(navigationService);
        }
    }
}