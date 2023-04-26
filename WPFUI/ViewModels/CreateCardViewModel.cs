using PASEDM.Infrastructure.Command;
using PASEDM.Services;
using PASEDM.ViewModels.Base;
using System;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class CreateCardViewModel : BaseViewModels
    {
        private string _nameCard;
        private string _numberCard;
        private DateTime _dateOfFormation;
        private string _secrecyStamp;
        private string _summary;
        private string _condition;
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

        public ICommand NavigateRefundCommand { get; }

        public CreateCardViewModel(INavigationService navigationService)
        {
            NavigateRefundCommand = new NavigateCommand(navigationService);
        }
    }
}