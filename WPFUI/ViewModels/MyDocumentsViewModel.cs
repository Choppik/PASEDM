using PASEDM.Store;
using PASEDM.ViewModels.Base;

namespace PASEDM.ViewModels
{
    public class MyDocumentsViewModel : BaseViewModels
    {
        private readonly UserStore _user;
        public MyDocumentsViewModel(UserStore userStore)
        {
            _user = userStore;
        }
    }
}