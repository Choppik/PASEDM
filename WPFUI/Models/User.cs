using System.ComponentModel.DataAnnotations;

namespace PASEDM.Models
{
    public class User
    {
        private int _idUser;
        private string _login, _password;

        [Key]
        public int IdUser { get { return _idUser; } set { _idUser = value; } }
        public string Login { get { return _login; } set { _login = value; } }
        public string Password { get { return _password; } set { _password = value; } }

        public User() { }
        public User(string login, string password) 
        {
            _login = login;
            _password = password;
        }
    }
}
