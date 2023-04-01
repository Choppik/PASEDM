using PASEDM.Infrastructure.Command;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class UserGreatViewModel : BaseViewModels
    {
        public ICommand NavigateEntryUserCommand { get; }
        public UserGreatViewModel (NavigationStore navigationStore)
        {
            NavigateEntryUserCommand = new NavigateCommand<UserEntryViewModel>(navigationStore, () => new UserEntryViewModel(navigationStore));
        }
    }
}
