using PASEDM.Infrastructure.Command.Base;
using PASEDM.Services;
using PASEDM.ViewModels;

namespace PASEDM.Infrastructure.Command
{
    public class NavigateViewingCardCommand : BaseCommand
    {
        private readonly IParamNavigationService<IncomingViewModel> _navigationService;
        private readonly IncomingViewModel _incomingViewModel;

        public NavigateViewingCardCommand(IncomingViewModel viewModel,
            IParamNavigationService<IncomingViewModel> navigationService)
        {
            _incomingViewModel = viewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate(_incomingViewModel);
        }
    }
}