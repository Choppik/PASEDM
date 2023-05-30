using PASEDM.Infrastructure.Command.Base;
using PASEDM.Services;
using PASEDM.ViewModels;

namespace PASEDM.Infrastructure.Command
{
    public class NavigateEditDocCommand : BaseCommand
    {
        private readonly IParamNavigationService<MyDocumentsViewModel> _navigationService;
        private readonly MyDocumentsViewModel _myDocumentsViewModel;

        public NavigateEditDocCommand(MyDocumentsViewModel viewModel,
            IParamNavigationService<MyDocumentsViewModel> navigationService)
        {
            _myDocumentsViewModel = viewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate(_myDocumentsViewModel);
        }
    }
}