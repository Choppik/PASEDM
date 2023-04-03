using PASEDM.Infrastructure.Command.Base;
using PASEDM.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
