namespace PASEDM.Models
{
    public class User
    {
        public string UserName { get; }
        public string Password { get; }
        public int? Employee { get; }

        public User (string userName)
        {
            UserName = userName;
        }

        public User(string userName, string password) : this(userName)
        {
            Password = password;
        }
        public User(string userName, string password, int? employee) : this(userName, password)
        {
            Employee = employee;
        }
    }
}