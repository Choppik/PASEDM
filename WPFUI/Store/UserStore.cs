using PASEDM.Models;
using System;

namespace PASEDM.Store
{
    public class UserStore
    {
        private User _currentUser;

        public User CurrentUser { get => _currentUser; set 
            { 
                _currentUser = value;
                CurrentUserChanged?.Invoke();
            } }
        public event Action CurrentUserChanged;
        public bool IsLoggedIn => CurrentUser != null;

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
