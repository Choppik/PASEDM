using PASEDM.Infrastructure.Command.Base;
using PASEDM.Store;

namespace PASEDM.Infrastructure.Command
{
    public class LogoutCommand : BaseCommand
    {
        private readonly UserStore _userStore;

        public LogoutCommand(UserStore userStore)
        {
            _userStore = userStore;
        }

        public override void Execute(object? parameter)
        {
            _userStore.Logout();
        }
    }
}