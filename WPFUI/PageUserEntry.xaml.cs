using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFUI
{
    /// <summary>
    /// Логика взаимодействия для PageUserEntry.xaml
    /// </summary>
    public partial class PageUserEntry : Page
    {
        public PageUserEntry()
        {
            InitializeComponent();
        }

        private void TextBoxLogEntry_LostFocus(object sender, RoutedEventArgs e)
        {
            App.Current.Resources["TextLogin"] = TextBoxLogEntry.Text;
        }

        private void PasswordBoxEntry_LostFocus(object sender, RoutedEventArgs e)
        {
            App.Current.Resources["TextPassword"] = PasswordBoxEntry.Password;
        }

        private void ButtonCreatAnAccount_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/PageUserGreate.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ButtonEntryAccount_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/PageMainMenu.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
