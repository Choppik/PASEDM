﻿using PASEDM.Services.PASEDMConflictValidator;
using PASEDM.Services.PASEDMCreator;
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
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Role { get; set; }
        public int? EmployeeID { get; set; }

        public User() { }
        public User (string userName)
        {
            UserName = userName;
        }

        public User(string userName, string password) : this(userName)
        {
            Password = password;
        }

        public User(string userName, string password, DateTime dateOfCreation, string role, int? employeeID) : this(userName, password)
        {
            DateOfCreation = dateOfCreation;
            Role = role;
            EmployeeID = employeeID;
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