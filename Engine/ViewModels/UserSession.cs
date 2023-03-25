using Engine.Models;

namespace Engine.ViewModels
{
    public class UserSession
    {
        public User CurrentUser { get; set; }
        public UserSession() { }
        public UserSession(string login, string password)
        {
            CurrentUser = new User(login, password);
        }
    }
}
