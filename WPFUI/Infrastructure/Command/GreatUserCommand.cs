using PASEDM.Data;
using PASEDM.Infrastructure.Command.Base;
using PASEDM.Models;
using PASEDM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace PASEDM.Infrastructure.Command
{
    public class GreatUserCommand : BaseCommand
    {
        private UserSession _session;

        private Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!$%^&*-]).{8,}$");

        private string _login;
        private string _password;
        public override void Execute(object? parameter)
        {
            if (/*TextBoxLogNew.Text != "" && TextBoxLogNew.Text.Length <= 50 &&
                PasswordBoxNew.Password != "" && PasswordBoxNew.Password == PasswordBoxRepeat.Password &&
            PasswordBoxRepeat.Password.Length <= 100 &&
                TextBoxLogNew.Text != PasswordBoxRepeat.Password && regex.IsMatch(PasswordBoxRepeat.Password) &&
                !TextBoxLogNew.Text.Contains(" ") && !PasswordBoxRepeat.Password.Contains(" ")*/1==1)
            {
                /*_login = TextBoxLogNew.Text;
                _password = PasswordBoxRepeat.Password;*/
                _login = "1";
                _password = "1";

                using var db = new PASEDMContext();
                var dbTable = db.Users;
                List<User> users = dbTable.ToList();
                bool unic = true;

                foreach (var user in users)
                {
                    if (user.Login == _login)
                    {
                        unic = false;
                        break;
                    }
                    else
                    {
                        unic = true;
                    }
                }
                if (unic == true)
                {
                    _session = new UserSession(_login, _password);
                    dbTable.Add(_session.CurrentUser);

                    db.SaveChanges();

                    MessageBox.Show("Пользователь создан. Пробуйте войти в аккаунт.");
                }
                else
                {
                    MessageBox.Show("Данное имя не уникально.");
                }
            }
            else
            {
                MessageBox.Show($"Что-то введено неверно. Пароль должен соответствовать следующему формату: только латинские символы," +
                    $" длина пароля не менее 8 символов," +
                    $" минимум один символ в верхнем регистре и один в нижнем, минимум один специальный символ (!$%^&*-) и минимум одна цифра");
            }
        }
    }
}
