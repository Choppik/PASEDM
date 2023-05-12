using PASEDM.Store;
using PASEDM.ViewModels.Base;

namespace PASEDM.ViewModels
{
    public class JournalViewModel : BaseViewModels
    {
        private readonly UserStore _user;
        public JournalViewModel(UserStore userStore)
        {
            _user = userStore;
        }
    }
}