using PASEDM.Models;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMCreator.InterfaceCreator
{
    public interface IUserCreator
    {
        Task CreateUser(User user);
    }
}