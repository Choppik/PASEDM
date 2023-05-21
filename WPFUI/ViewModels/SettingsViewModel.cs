using PASEDM.Data;
using PASEDM.Store;
using PASEDM.ViewModels.Base;

namespace PASEDM.ViewModels
{
    public class SettingsViewModel : BaseViewModels
    {
        private readonly UserStore _user;
        private PASEDMDbContextFactory _contextFactory;

        private string _password;
        private string _newPassword;
        private string _replayPassword;
        public string Password
        {
            get
            {
                return _password;
            }
            set //=> Set(ref _password, value);
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string NewPassword
        {
            get
            {
                return _newPassword;
            }
            set
            {
                _newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
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
        public SettingsViewModel(UserStore userStore)
        {
            _user = userStore;
        }
    }
}