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

            using (var db = new PASEDMContext())
            {
                var dsds = db.Users;
                _userSession = new UserSession("User1", "1");
                dsds.Add(_userSession.CurrentUser);
                db.SaveChanges();
            }

            PageUserEntry pageUserEntry = new();
            MainFrame.Navigate(pageUserEntry);

        }
    }
}
