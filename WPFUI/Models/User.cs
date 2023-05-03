using PASEDM.Services.PASEDMConflictValidator;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace PASEDM.Models
{
    public class User
    {
        private readonly IUserCreator _userCreator;
        private readonly IUserProvider _userProviders;
        private readonly IUserConflictValidator _userConflictValidator;
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Role { get; set; }
        public int? EmployeeID { get; set; }

        public User() { }
        public User(string userName)
        {
            UserName = userName;
        }
        public User (int id, string userName) : this(userName)
        {
            Id = id;
        }

        public User(int id, string userName, string password) : this(id, userName)
        {
            Password = password;
        }

        public User(string userName, string password, DateTime dateOfCreation, string role, int? employeeID)
        {
            UserName = userName;
            Password = password;
            DateOfCreation = dateOfCreation;
            Role = role;
            EmployeeID = employeeID;
        }
        public User(int id, string userName, string password, DateTime dateOfCreation, string role, int? employeeID) 
            : this(userName, password, dateOfCreation, role, employeeID)
        {
            Id = id;
        }

        public User(IUserCreator userCreator, IUserProvider userProviders, IUserConflictValidator userConflictValidator)
        {
            _userCreator = userCreator;
            _userProviders = userProviders;
            _userConflictValidator = userConflictValidator;
        }

        public User(IUserProvider userProviders)
        {
            _userProviders = userProviders;
        }

        public User(IUserCreator userCreator)
        {
            _userCreator = userCreator;
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
        public async Task<bool> GetUserBool(User user)
        {
            return await _userProviders.GetUserBool(user);
        }
        public async Task<User> GetUser(User user)
        {
            return await _userProviders.GetUser(user);
        }
    }
}