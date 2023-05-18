using PASEDM.Infrastructure.Command.Base;
using PASEDM.Services;
using PASEDM.ViewModels;

namespace PASEDM.Infrastructure.Command
{
    public class NavigateEditCardCommand : BaseCommand
    {
        private readonly IParamNavigationService<OutgoingViewModel> _navigationService;
        private OutgoingViewModel _outgoingViewModel;

        public NavigateEditCardCommand(OutgoingViewModel viewModel,
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