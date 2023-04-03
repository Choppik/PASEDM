using PASEDM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASEDM.ViewModels
{
    public class LayoutViewModel : BaseViewModels
    {
        public LayoutViewModel(NavigationBarViewModel navigationBarViewModel, BaseViewModels contentViewModels)
        {
            NavigationBarViewModel = navigationBarViewModel;
            ContentViewModels = contentViewModels;
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
