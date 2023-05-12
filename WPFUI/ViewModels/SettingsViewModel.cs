using PASEDM.Store;
using PASEDM.ViewModels.Base;

namespace PASEDM.ViewModels
{
    public class SettingsViewModel : BaseViewModels
    {
        private readonly UserStore _user;
        public SettingsViewModel(UserStore userStore)
        {
            _user = userStore;
        }
    }
}