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
using Engine.Models;
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

            TransitionPage(new PageUserEntry(), "Авторизация", "Войти", false);

            _userSession = new UserSession("User1", "1");
        }

        private void ButtonCreatAnAccount_Click(object sender, RoutedEventArgs e)
        {
            TransitionPage(new PageUserGreate(), "Регистрация", "Создать", true);
        }
        private void ButtonEntryAnAccount_Click(object sender, RoutedEventArgs e)
        {
            TransitionPage(new PageUserEntry(), "Авторизация", "Войти", false);
        }
        private void TransitionPage(object page, string text, string nameButton, bool activ)
        {
            MyFrame.Content = page;
            ButtonEntryAnAccount.IsEnabled = activ;
            ButtonCreatAnAccount.IsEnabled = !activ;
            ButtonEntryOrGreateAccount.Content = nameButton;
            TextTitle.Text = text;

        }

        private void ButtonEntryOrGreateAccount_Click(object sender, RoutedEventArgs e)
        {

            if (_userSession.Check() == (string)App.Current.Resources["TextLogin"]
                && _userSession.Check2() == (string)App.Current.Resources["TextPassword"]
                && (bool)App.Current.Resources["PageReg"])
            {
                MainFrame.Content = new PageMainMenu();
                BorderMain.Visibility = Visibility.Collapsed;
            }
            else if (_userSession.Check() == (string)App.Current.Resources["TextLogin"]
                && _userSession.Check2() == (string)App.Current.Resources["TextPassword"]
                && !(bool)App.Current.Resources["PageReg"])
            {
                _userSession = new UserSession((string)App.Current.Resources["TextLogin"], (string)App.Current.Resources["TextPassword"]);
                MessageBox.Show("Пользователь создан. Попробуйте зайти в аккаунт через некоторое время.");
            } 
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль. Проверьте правильность введенных данных.");
            }
        }
    }
}
