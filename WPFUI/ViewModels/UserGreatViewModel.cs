using PASEDM.Data;
using PASEDM.Infrastructure.Command;
using PASEDM.Services;
using PASEDM.ViewModels.Base;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class UserGreatViewModel : BaseViewModels
    {
        private string _userName;
        private string _password;
        private string _replayPassword;
        private string _employeeName;
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
        public string EmployeeName
        {
            get
            {
                return _employeeName;
            }
            set
            {
                _employeeName = value;
                OnPropertyChanged(nameof(EmployeeName));
            }
        }

        public ICommand NavigateEntryUserCommand { get; }
        public ICommand CreateUserCommand { get; }

        public UserGreatViewModel (INavigationService entryInAccountNavigationService, PASEDMDbContextFactory deferredContextFactory)
        {
            NavigateEntryUserCommand = new NavigateCommand(entryInAccountNavigationService);

            CreateUserCommand = new CreateUserCommand(this, deferredContextFactory);
        }
    }
}