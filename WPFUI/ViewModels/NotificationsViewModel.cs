using PASEDM.Infrastructure.Command;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;
using PASEDM.Services;

namespace PASEDM.ViewModels
{

    /// <summary>
    /// Пока не используется полноценно
    /// </summary>
    public class NotificationsViewModel : BaseViewModels
    {
        private readonly UserStore _user;
        public string? Name => _user.CurrentUser.UserName;
        public NotificationsViewModel(UserStore userStore)
        {
            _user = userStore;
        }
    }
}