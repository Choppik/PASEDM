using PASEDM.Infrastructure.Command;
using PASEDM.Services;
using PASEDM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class NavigationBarViewModel : BaseViewModels
    {
        public ICommand NavigateExitOfAccount { get; }
        public ICommand NavigateGreateUser { get; }
        public ICommand NavigateEntryUser { get; }
        public NavigationBarViewModel(INavigationService<MenuViewModel> navigationServiceMenu,
            INavigationService<UserGreatViewModel> navigationServiceNewUser,
            INavigationService<UserEntryViewModel> navigationServiceEntryUser) 
        {
            NavigateExitOfAccount = new NavigateCommand<MenuViewModel>(navigationServiceMenu);
            NavigateGreateUser = new NavigateCommand<UserGreatViewModel>(navigationServiceNewUser);
            NavigateEntryUser = new NavigateCommand<UserEntryViewModel>(navigationServiceEntryUser);
        }

    }
}
