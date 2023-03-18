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
    /// Логика взаимодействия для PageUserGreate.xaml
    /// </summary>
    public partial class PageUserGreate : Page
    {
        public PageUserGreate()
        {
            InitializeComponent();
        }

        private void TextBoxLogNew_LostFocus(object sender, RoutedEventArgs e)
        {
            App.Current.Resources["TextLogin"] = TextBoxLogNew.Text;
            App.Current.Resources["PageReg"] = false;
        }

        private void PasswordBoxRepeat_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxNew.Password == PasswordBoxRepeat.Password)
            {
                App.Current.Resources["TextPassword"] = PasswordBoxRepeat.Password;
                App.Current.Resources["PageReg"] = false;
            }
        }
    }
}
