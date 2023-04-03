using PASEDM.Infrastructure.Command;
using PASEDM.Services;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class UserGreatViewModel : BaseViewModels
    {
        public ICommand NavigateEntryUserCommand { get; }
        public UserGreatViewModel (INavigationService<UserEntryViewModel> entryInAccountNavigationService)
        {
            NavigateEntryUserCommand = new NavigateCommand<UserEntryViewModel>(entryInAccountNavigationService);
        }
    }
}
