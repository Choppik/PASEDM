using PASEDM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders.InterfaceProviders
{
    public interface IMoveUserProvider
    {
        Task<IEnumerable<MoveUser>> GetAllMoveUserSender(MoveUser moveUser, User user);
        Task<IEnumerable<MoveUser>> GetAllMoveUserRecipient(MoveUser moveUser, User user);
        Task DeleteMoveUser(MoveUser moveUser);
    }
}