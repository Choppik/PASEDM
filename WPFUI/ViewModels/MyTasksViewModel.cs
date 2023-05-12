using PASEDM.Store;
using PASEDM.ViewModels.Base;

namespace PASEDM.ViewModels
{
    public class MyTasksViewModel : BaseViewModels
    {
        private readonly UserStore _user;
        public MyTasksViewModel(UserStore userStore)
        {
            _user = userStore;
        }
    }
}