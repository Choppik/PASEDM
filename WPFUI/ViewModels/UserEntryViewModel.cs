using PASEDM.Infrastructure.Command;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class UserEntryViewModel : BaseViewModels
    {
        public string Name => "123";
        public ICommand NavigateGreatUserCommand { get; }
        public UserEntryViewModel (NavigationStore navigationStore)
        {
            NavigateGreatUserCommand = new NavigateCommand<UserGreatViewModel>(navigationStore, () => new UserGreatViewModel(navigationStore));
        }
    }
}
