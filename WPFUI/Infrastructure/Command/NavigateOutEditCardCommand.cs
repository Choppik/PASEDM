using PASEDM.Infrastructure.Command.Base;
using PASEDM.Services;
using PASEDM.ViewModels;

namespace PASEDM.Infrastructure.Command
{
    public class NavigateOutEditCardCommand : BaseCommand
    {
        private readonly IParamNavigationService<OutgoingViewModel> _navigationService;
        private OutgoingViewModel _outgoingViewModel;

        public NavigateOutEditCardCommand(OutgoingViewModel viewModel,
            IParamNavigationService<OutgoingViewModel> navigationService)
        {
            _outgoingViewModel = viewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate(_outgoingViewModel);
        }
    }
}