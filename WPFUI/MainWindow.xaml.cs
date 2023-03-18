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
using Engine.ViewModels;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserSession _userSession;
        public MainWindow()
        {
            InitializeComponent();

            MyFrame.Content = new PageUserEntry();
            ButtonEntryAnAccount.IsEnabled = false;

            _userSession = new UserSession();
        }

        private void ButtonCreatAnAccount_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new PageUserGreate();
            ButtonEntryAnAccount.IsEnabled = true;
            ButtonCreatAnAccount.IsEnabled = false;
            TextTitle.Text = "Регистрация";
        }

        private void ButtonEntryAnAccount_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new PageUserEntry();
            ButtonEntryAnAccount.IsEnabled = false;
            ButtonCreatAnAccount.IsEnabled = true;
            TextTitle.Text = "Авторизация";
        }
    }
}
