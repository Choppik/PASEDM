using PASEDM.Services.PASEDMConflictValidator;
using PASEDM.Services.PASEDMCreator;
using PASEDM.Services.PASEDMProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    internal class MoveUser
    {
        private readonly IUserCreator _userCreator;
        private readonly IUserProvider _userProviders;
        private readonly IUserConflictValidator _userConflictValidator;

        public MoveUser(IUserCreator userCreator, IUserProvider userProviders, IUserConflictValidator userConflictValidator)
        {
            _userCreator = userCreator;
            _userProviders = userProviders;
            _userConflictValidator = userConflictValidator;
        }

        /// <summary>
        /// Не забыть условие поменять
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="UserConflictException"></exception>
        public async Task AddUser(User user)
        {
            /*if (user.UserName == "123")
            {
                throw new UserConflictException(user, user);
            }

            User conflictingReservation = await _userConflictValidator.GetConflictingUser(user);

            if (conflictingReservation != null)
            {
                throw new UserConflictException(conflictingReservation, user);
            }*/

            await _userCreator.CreateUser(user);
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userProviders.GetAllUser();
        }
        public async Task<IEnumerable<User>> GetAllNameUsers()
        {
            return await _userProviders.GetUser();
        }
    }
}