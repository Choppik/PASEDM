using Engine.ViewModels.Base;

namespace Engine.ViewModels
{
    public class MainWindowViewModel : BaseViewModels
    {
        private string _title = "PASEDM";

        public string Title { get => _title; set => Set(ref _title, value); }
    }
}
