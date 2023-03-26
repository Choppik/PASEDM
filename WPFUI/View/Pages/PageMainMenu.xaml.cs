using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PASEDM
{
    /// <summary>
    /// Логика взаимодействия для PageMainMenu.xaml
    /// </summary>
    public partial class PageMainMenu : Page
    {
        public PageMainMenu()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/View/Pages/PageUserEntry.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
