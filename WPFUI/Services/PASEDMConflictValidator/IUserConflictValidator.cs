using PASEDM.Models;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMConflictValidator
{
    public interface IUserConflictValidator
    {
        Task<User> GetConflictingUser(User user);
    }
}
