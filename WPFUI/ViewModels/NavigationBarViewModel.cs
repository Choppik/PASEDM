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
        public NavigationBarViewModel(NavigationService<UserEntryViewModel> navigationService) 
        {
            NavigateExitOfAccount = new NavigateCommand<UserEntryViewModel>(navigationService);
        }

    }
}
