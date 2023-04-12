using PASEDM.Components.PasswordBehavior;
using PASEDM.Exceptions;
using PASEDM.Services.PASEDMConflictValidator;
using PASEDM.Services.PASEDMCreator;
using PASEDM.Services.PASEDMProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class User
    {
        private readonly  IUserCreator _userCreator;
        private readonly  IUserProvider _userProviders;
        private readonly  IUserConflictValidator _userConflictValidator;

        public string UserName { get; }
        public string Password { get; }

        public User (string userName)
        {
            UserName = userName;
        }

        public User(string userName, string password) 
        {
            UserName = userName;
            Password = password;
        }

        public User(IUserCreator userCreator, IUserProvider userProviders, IUserConflictValidator userConflictValidator)
        {
            _userCreator = userCreator;
            _userProviders = userProviders;
            _userConflictValidator = userConflictValidator;
        }

        public async Task AddUser(User user)
        {
            if (user.UserName == "123")
            {
                throw new UserConflictException(user, user);
            }

            User conflictingReservation = await _userConflictValidator.GetConflictingUser(user);

            if (conflictingReservation != null)
            {
                throw new UserConflictException(conflictingReservation, user);
            }

            await _userCreator.CreateUser(user);
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userProviders.GetAllUser();
        }
    }
}
