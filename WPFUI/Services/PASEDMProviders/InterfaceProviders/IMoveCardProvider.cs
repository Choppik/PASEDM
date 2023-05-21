using PASEDM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders.InterfaceProviders
{
    public interface IMoveCardProvider
    {
        Task<IEnumerable<MoveCard>> GetAllMoveUserSender(MoveCard moveUser, User user);
        Task<IEnumerable<MoveCard>> GetAllMoveUserRecipient(MoveCard moveUser, User user);
        Task DeleteMoveCard(MoveCard moveUser);
        int GetCountViewedMoveCard(User user);
    }
}