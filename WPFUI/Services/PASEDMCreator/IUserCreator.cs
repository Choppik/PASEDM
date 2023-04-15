using PASEDM.Models;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMCreator
{
    public interface IUserCreator
    {
        Task CreateUser(User user);
    }
}