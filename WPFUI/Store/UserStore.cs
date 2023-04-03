using PASEDM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
