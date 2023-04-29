using PASEDM.Infrastructure.Command;
using PASEDM.Services;
using PASEDM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class CreateCardViewModel : BaseViewModels
    {
        private readonly List<string> _listSecrecyStamp = new() 
        { 
            "Не секретно",
            "Секретно", 
            "Совершенно секретно",
            "Особая важность"
        };
        private readonly List<string> _listTaskStages = new () 
        { 
            "Стадия анализа задачи", 
            "Стадия поиска решения задачи", 
            "Стадия выполнения задачи", 
            "Стадия проверки выполненной задачи",
            "Задача выполнена"
        };
        private readonly List<string> _listDocStages = new()
        {
            "Поставлен на контроль",
            "Проверка своевременности доведения до исполнителей",
            "Проверка и регулирование хода исполнения",
            "Учет и обобщение результатов контроля исполнения",
            "Снят с контроля",
            "Не нуждается в контроле исполнения"
        };

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