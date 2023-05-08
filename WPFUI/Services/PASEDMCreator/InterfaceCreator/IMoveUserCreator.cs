using PASEDM.Models;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMCreator.InterfaceCreator
{
    public interface IMoveUserCreator
    {
        Task AddMoveUser(MoveUser moveUser);
    }
}