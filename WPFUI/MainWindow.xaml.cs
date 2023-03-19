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

            PageUserEntry pageUserEntry = new PageUserEntry();
            MainFrame.Navigate(pageUserEntry);
            //NavigationService.GetNavigationService(this).Navigate(new Uri("/PageUserEntry.xaml", UriKind.RelativeOrAbsolute));
            //TransitionPage(new PageUserEntry(), "Авторизация", "Войти", false);

            _userSession = new UserSession("User1", "1");
        }
    }
}
