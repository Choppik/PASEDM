using System.Windows;
using Engine.ViewModels;
using Engine.ViewModels.Data;

namespace WPFUI
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
