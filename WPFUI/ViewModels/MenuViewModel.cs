using PASEDM.Infrastructure.Command;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class MenuViewModel : BaseViewModels
    {
        public ICommand NavigateMainMenuCommand { get; }
        public MenuViewModel(NavigationStore navigationStore)
        {
            NavigateMainMenuCommand = new NavigateCommand<MenuViewModel>(navigationStore, () => new MenuViewModel(navigationStore));
        }
    }
}
