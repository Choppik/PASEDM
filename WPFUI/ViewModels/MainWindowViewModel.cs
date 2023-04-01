using PASEDM.Infrastructure.Command;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class MainWindowViewModel : BaseViewModels
    {
        private readonly NavigationStore _navigationStore;
        public BaseViewModels CurrentViewModel => _navigationStore.CurrentViewModel;

        #region Заголовок окна
        private string _title = "PASEDM";

        public string Title { get => _title; set => Set(ref _title, value); }
        #endregion

        #region Команды
        public ICommand GoUserGreatCommand { get; }
        private bool CanGoUserGreatCommand(object parameter) => true;
        private void OnGoUserGreatCommand(object parameter)
        {
            /*Application.Current.MainWindow += Navigate(new PageUserGreate());
            MainFrame.Navigate(pageUserEntry);
            PageUserEntry pageUserEntry = new();
            MainFrame.Navigate(pageUserEntry);
            NavigationService.Navigate(new Uri("/View/Pages/PageUserGreate.xaml", UriKind.RelativeOrAbsolute));*/
        }

        #endregion
        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChange += OnCurrentViewModelChange;

            //GoUserGreatCommand = new LambdaCommand(OnGoUserGreatCommand, CanGoUserGreatCommand);
        }

        private void OnCurrentViewModelChange()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
