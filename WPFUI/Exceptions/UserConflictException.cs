using PASEDM.Models;
using System;

namespace PASEDM.Exceptions
{
    public class UserConflictException : Exception
    {
        public User ExistingUser { get; }
        public User IncomingUser { get; }
        public UserConflictException(string? message, User existingUser, User incomingUser) : base(message)
        {
            ExistingUser = existingUser;
            IncomingUser = incomingUser;
        }

        public UserConflictException(string? message, Exception? innerException, User existingUser, User incomingUser) : base(message, innerException)
        {
            ExistingUser = existingUser;
            IncomingUser = incomingUser;
        }

        public UserConflictException(User existingUser, User incomingUser)
        {
            ExistingUser = existingUser;
            IncomingUser = incomingUser;
        }
    }
}