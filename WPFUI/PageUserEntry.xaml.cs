﻿using Engine.Models;
using Engine.ViewModels;
using Engine.ViewModels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WPFUI
{
    /// <summary>
    /// Логика взаимодействия для PageUserEntry.xaml
    /// </summary>
    public partial class PageUserEntry : Page
    {
        private string _login;
        private string _password;
        public PageUserEntry()
        {
            InitializeComponent();
        }

        private void ButtonCreatAnAccount_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/PageUserGreate.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ButtonEntryAccount_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogEntry.Text != null && PasswordBoxEntry.Password != null)
            {
                _login = TextBoxLogEntry.Text;
                _password = PasswordBoxEntry.Password;

                using var db = new PASEDMContext();
                var dbTable = db.Users;
                bool unic = true;
                List<User> users = dbTable.ToList();
                if(users.Count != 0)
                {
                    foreach (var user in users)
                    {
                        if (user.Login == _login && user.Password == _password)
                        {
                            unic = true;
                            break;
                        }
                        else
                        {
                            unic = false;
                        }
                    }
                    if (unic == false)
                    {
                        MessageBox.Show("Неверно введено имя пользователя или пароль.");
                    }
                    else
                    {
                        NavigationService.GetNavigationService(this).Navigate(new Uri("/PageMainMenu.xaml", UriKind.RelativeOrAbsolute));
                    }
                }
                else
                {
                    MessageBox.Show("Неверно введено имя пользователя или пароль.");
                }
            }
        }
    }
}
