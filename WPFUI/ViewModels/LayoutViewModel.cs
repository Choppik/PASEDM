using PASEDM.ViewModels.Base;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class LayoutViewModel : BaseViewModels
    {
        public ICommand NavigateIncomingCommand { get; }
        public ICommand NavigateOutgoingCommand { get; }
        public ICommand NavigateNotificationCommand { get; }
        public LayoutViewModel(
            NavigationBarViewModel navigationBarViewModel, 
            BaseViewModels contentViewModels)
        {
            NavigationBarViewModel = navigationBarViewModel;
            ContentViewModels = contentViewModels;

            NavigateIncomingCommand = navigationBarViewModel.NavigateIncomingCommand;
            NavigateOutgoingCommand = navigationBarViewModel.NavigateOutgoingCommand;
            NavigateNotificationCommand = navigationBarViewModel.NavigateNotificationCommand;
        }

        public NavigationBarViewModel NavigationBarViewModel { get; }
        public BaseViewModels ContentViewModels { get; }
        public override void Dispose()
        {
            NavigationBarViewModel.Dispose();
            ContentViewModels.Dispose();
            base.Dispose();
        }
    }
}