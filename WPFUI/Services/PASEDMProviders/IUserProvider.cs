﻿using PASEDM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders
{
    public interface IUserProvider
    {
        Task<IEnumerable<User>> GetAllUser();
        Task<IEnumerable<User>> GetUser();
    }
}