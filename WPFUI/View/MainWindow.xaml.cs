using System.Windows;

namespace PASEDM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PageUserEntry pageUserEntry = new();
            MainFrame.Navigate(pageUserEntry);
        }
    }
}
