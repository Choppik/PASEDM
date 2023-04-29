using PASEDM.Infrastructure.Command;
using PASEDM.Models;
using PASEDM.Services;
using PASEDM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private Tasks _currentTask;
        private Case _currentCase;
        private string _summary;
        private string _conditionDoc;
        private string _conditionTask;
        private string _сomment;
        private ObservableCollection<Tasks> _tasks;
        private ObservableCollection<Case> _cases;
        private string _filePath;
        private string _docName;
        private string _docRegistrationNumber;
        private DateTime _dateOfFormationDocument = DateTime.Now;
        public IEnumerable<string> ListSecrecyStamp => _listSecrecyStamp;
        public IEnumerable<string> ListDocStages => _listDocStages;
        public IEnumerable<string> ListTaskStages => _listTaskStages;
        public IEnumerable<Tasks> Tasks => _tasks;
        public IEnumerable<Case> Case => _cases;
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
        public DateTime DateOfFormation => DateTime.Now;
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
        public string Comment
        {
            get
            {
                return _сomment;
            }
            set
            {
                _сomment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }
        public string Document
        {
            get
            {
                return _docName;
            }
            set
            {
                _docName = value;
                OnPropertyChanged(nameof(Document));
            }
        }
        public string RegistrationNumber
        {
            get
            {
                return _docRegistrationNumber;
            }
            set
            {
                _docRegistrationNumber = value;
                OnPropertyChanged(nameof(RegistrationNumber));
            }
        }
        public DateTime DateOfFormationDocument
        {
            get
            {
                return _dateOfFormationDocument;
            }
            set
            {
                _dateOfFormationDocument = value;
                OnPropertyChanged(nameof(DateOfFormationDocument));
            }
        }
        public string ConditionDoc
        {
            get
            {
                return _conditionDoc;
            }
            set
            {
                _conditionDoc = value;
                OnPropertyChanged(nameof(ConditionDoc));
            }
        }
        public string ConditionTask
        {
            get
            {
                return _conditionTask;
            }
            set
            {
                _conditionTask = value;
                OnPropertyChanged(nameof(ConditionTask));
            }
        }
        public string Summary
        {
            get
            {
                return _summary;
            }
            set
            {
                _summary = value;
                OnPropertyChanged(nameof(Summary));
            }
        }
        public Tasks CurrentTask
        {
            get
            {
                return _currentTask;
            }
            set
            {
                _currentTask = value;
                OnPropertyChanged(nameof(CurrentTask));
            }
        }
        public Case CurrentCase
        {
            get
            {
                return _currentCase;
            }
            set
            {
                _currentCase = value;
                OnPropertyChanged(nameof(CurrentCase));
            }
        }
        public ICommand NavigateRefundCommand { get; }

        public CreateCardViewModel(INavigationService navigationService)
        {
            NavigateRefundCommand = new NavigateCommand(navigationService);
        }
    }
}