using PASEDM.Services.PASEDMConflictValidator;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class User
    {
        private readonly IUserCreator _userCreator;
        private readonly IUserProvider _userProviders;
        private readonly IUserConflictValidator _userConflictValidator;
        public int Id { get; }
        public string UserName { get; set; }
        public string Password { get; }
        public string Salt { get; }
        public int RecordConfirmation { get; }
        public DateTime DateOfCreation { get; }
        public Role Role { get; }
        public Employee Employee { get; }

        public User() { }
        public User(string userName)
            :this(default, userName, "", "", default, default, default, default)
        { }
        public User (int id, string userName) 
            : this(id, userName, "", "", default, default, default, default)
        { }
        public User(int id, string userName, int recordConfirmation, Role role, Employee employee)
            : this(id, userName, "", "", recordConfirmation, default, role, employee)
        { }

        public User(int id, string userName, string password, string salt, int recordConfirmation) 
            : this(id, userName, password, salt, recordConfirmation, default, default, default)
        { }
        public User(int id, string userName, DateTime dateOfCreation, Role role, Employee employee)
            : this(id, userName, "", "", default, dateOfCreation, role, employee)
        { }

        public User(string userName, string password, string salt, int recordConfirmation, DateTime dateOfCreation, Role role, Employee employee)
            :this(default, userName, password, salt, recordConfirmation, dateOfCreation, role, employee)
        { }
        public User(int id, string userName, string password, string salt, int recordConfirmation, DateTime dateOfCreation, Role role, Employee employee) 
        {
            Id = id;
            UserName = userName;
            Password = password;
            Salt = salt;
            RecordConfirmation = recordConfirmation;
            DateOfCreation = dateOfCreation;
            Role = role;
            Employee = employee;
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
        public async Task ConfirmationUser(User user)
        {
            await _userProviders.ConfirmationUser(user);
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userProviders.GetAllUser();
        }
        public async Task<IEnumerable<User>> GetUserRecordConfirmation()
        {
            return await _userProviders.GetUserRecordConfirmation();
        }
        public async Task<bool> GetUserBool(User user)
        {
            return await _userProviders.GetUserBool(user);
        }
        public async Task<User> GetUser(User user)
        {
            return await _userProviders.GetUser(user);
        }
        public override string ToString()
        {
            return $"{UserName}";
        }
    }
}