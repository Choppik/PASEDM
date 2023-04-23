using PASEDM.Infrastructure.Command;
using PASEDM.Services;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    class OutgoingViewModel : BaseViewModels
    {
        public ICommand NavigateCreateCardCommand { get; }
        public OutgoingViewModel(INavigationService navigationService)
        {
            NavigateCreateCardCommand = new NavigateCommand(navigationService);
        }
    }
}