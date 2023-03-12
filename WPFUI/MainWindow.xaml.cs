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

            _userSession = new UserSession();
        }

        private void ButtonCreatAnAccount_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            WindowGreateUser windowGreateUser = new WindowGreateUser();
            windowGreateUser.ShowDialog();
            Close();
        }
    }
}
