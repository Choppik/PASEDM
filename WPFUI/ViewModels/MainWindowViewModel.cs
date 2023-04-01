using PASEDM.Data;
using PASEDM.Models;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class MainWindowViewModel : BaseViewModels
    {
        private readonly NavigationStore _navigationStore;
        public BaseViewModels CurrentViewModel => _navigationStore.CurrentViewModel;

        private UserSession _session;

        private Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!$%^&*-]).{8,}$");

        private string _login;
        private string _password;

        #region Заголовок окна
        private string _title = "PASEDM";

        public string Title { get => _title; set => Set(ref _title, value); }
        #endregion

        #region Команды
        public ICommand GoUserGreatCommand { get; }
        private bool CanGoUserGreatCommand(object parameter) => true;
        /*private void OnGoUserGreatCommand(object parameter)
        {

            if (TextBoxLogNew.Text != "" && TextBoxLogNew.Text.Length <= 50 &&
                PasswordBoxNew.Password != "" && PasswordBoxNew.Password == PasswordBoxRepeat.Password &&
            PasswordBoxRepeat.Password.Length <= 100 &&
                TextBoxLogNew.Text != PasswordBoxRepeat.Password && regex.IsMatch(PasswordBoxRepeat.Password) &&
                !TextBoxLogNew.Text.Contains(" ") && !PasswordBoxRepeat.Password.Contains(" "))
            {
                _login = TextBoxLogNew.Text;
                _password = PasswordBoxRepeat.Password;

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
        }*/

        #endregion
        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChange += OnCurrentViewModelChange;

            //GoUserGreatCommand = new LambdaCommand(OnGoUserGreatCommand, CanGoUserGreatCommand);
        }

        private void OnCurrentViewModelChange()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
