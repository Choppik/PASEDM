using PASEDM.Infrastructure.Command.Base;
using PASEDM.Services;
using PASEDM.ViewModels;

namespace PASEDM.Infrastructure.Command
{
    public class NavigateEditCardCommand : BaseCommand
    {
        private readonly ParameterNavigationService<OutgoingViewModel, CreateCardViewModel> _navigationService;
        private OutgoingViewModel _outgoingViewModel;

        public NavigateEditCardCommand(OutgoingViewModel viewModel, 
            ParameterNavigationService<OutgoingViewModel, CreateCardViewModel> navigationService)
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