using PASEDM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders.InterfaceProviders
{
    public interface IRoleProvider
    {
        Task<IEnumerable<Role>> GetAllRole();
    }
}