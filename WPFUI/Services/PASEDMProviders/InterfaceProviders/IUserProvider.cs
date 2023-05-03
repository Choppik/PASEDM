using PASEDM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders.InterfaceProviders
{
    public interface IUserProvider
    {
        Task<IEnumerable<User>> GetAllUser();
        Task<bool> GetUserBool(User user);
        Task<User> GetUser(User user);
    }
}