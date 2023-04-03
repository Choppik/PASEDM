using PASEDM.ViewModels.Base;

namespace PASEDM.Services
{
    public interface INavigationService<TViewModel>
        where TViewModel : BaseViewModels
    {
        void Navigate();
    }
}