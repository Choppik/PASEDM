using PASEDM.Components;
using PASEDM.ViewModels.Base;

namespace PASEDM.ViewModels
{
    public class LayoutViewModel : BaseViewModels
    {
        public LayoutViewModel(NavigationBarViewModel navigationBarViewModel, BaseViewModels contentViewModels, HamburgerMenu hamburgerMenu)
        {
            NavigationBarViewModel = navigationBarViewModel;
            ContentViewModels = contentViewModels;
            //HamburgerMenu = hamburgerMenu;
        }

        public NavigationBarViewModel NavigationBarViewModel { get; }
        //public HamburgerMenu HamburgerMenu { get; }
        public BaseViewModels ContentViewModels { get; }
        public override void Dispose()
        {
            NavigationBarViewModel.Dispose();
            ContentViewModels.Dispose();
            base.Dispose();
        }
    }
}