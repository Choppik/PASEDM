﻿using PASEDM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders.InterfaceProviders
{
    public interface IRecipientProvider
    {
        Task<IEnumerable<Recipient>> GetAllRecipient(User user);
        Task<Recipient> GetRecipient(Recipient recipient);
    }
}