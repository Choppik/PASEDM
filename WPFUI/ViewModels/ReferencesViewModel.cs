using PASEDM.Store;
using PASEDM.ViewModels.Base;

namespace PASEDM.ViewModels
{
    public class ReferencesViewModel : BaseViewModels
    {
        private readonly UserStore _user;
        public ReferencesViewModel(UserStore userStore)
        {
            _user = userStore;
        }
    }
}