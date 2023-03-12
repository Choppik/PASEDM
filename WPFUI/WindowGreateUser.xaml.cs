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
using System.Windows.Shapes;
using Engine.ViewModels;

namespace WPFUI
{
    /// <summary>
    /// Логика взаимодействия для WindowGreateUser.xaml
    /// </summary>
    public partial class WindowGreateUser : Window
    {
        private UserSession _userSession;
        public WindowGreateUser()
        {
            InitializeComponent();

            _userSession = new UserSession();
        }

        private void ButtonEntryAnAccount_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            Close();
        }
    }
}
