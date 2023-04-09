using PASEDM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders
{
    public interface IUserProvider
    {
        Task<IEnumerable<User>> GetAllUser();
    }
}
