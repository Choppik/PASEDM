using PASEDM.Data;
using PASEDM.Infrastructure.Command;
using PASEDM.Models;
using PASEDM.Services;
using PASEDM.Services.PASEDMProviders;
using PASEDM.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class UserCreateViewModel : BaseViewModels
    {
        private string _userName;
        private string _password;
        private string _replayPassword;
        private ObservableCollection<Employee> _staff;
        private Employee _employee;
        private IEmployeeProvider _employeeProvider;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ReplayPassword
        {
            get
            {
                return _replayPassword;
            }
            set
            {
                _replayPassword = value;
                OnPropertyChanged(nameof(ReplayPassword));
            }
        }
        public IEnumerable<Employee> Staff => _staff;
        public Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
                OnPropertyChanged(nameof(Employee));
            }
        }

        public ICommand NavigateEntryUserCommand { get; }
        public ICommand CreateUserCommand { get; }

        public UserCreateViewModel (INavigationService entryInAccountNavigationService, PASEDMDbContextFactory deferredContextFactory)
        {
            _employeeProvider = new DatabaseEmloyeeProvider(deferredContextFactory);
            _staff = new ObservableCollection<Employee>();

            foreach (var item in _employeeProvider.GetAllEmployee())
            {
                _staff.Add(item);
            }

            NavigateEntryUserCommand = new NavigateCommand(entryInAccountNavigationService);

            CreateUserCommand = new CreateUserCommand(this, deferredContextFactory);
        }
    }
}