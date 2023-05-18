namespace PASEDM.Services
{
    public interface IParamNavigationService<TParameter>
    {
        void Navigate(TParameter parameter);
    }
}