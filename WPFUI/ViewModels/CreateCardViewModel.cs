using PASEDM.Infrastructure.Command;
using PASEDM.Services;
using PASEDM.ViewModels.Base;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class CreateCardViewModel : BaseViewModels
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
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

        public ICommand NavigateRefundCommand { get; }

        public CreateCardViewModel(INavigationService navigationService)
        {
            NavigateRefundCommand = new NavigateCommand(navigationService);
        }
    }
}