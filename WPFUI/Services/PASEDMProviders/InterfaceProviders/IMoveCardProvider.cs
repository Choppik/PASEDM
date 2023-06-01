using PASEDM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders.InterfaceProviders
{
    public interface IMoveCardProvider
    {
        Task<IEnumerable<MoveCard>> GetAllMoveCard(MoveCard moveCard, User user);
        Task DeleteMoveCard(MoveCard moveUser);
        int GetCountViewedMoveCard(User user);
        Task<IEnumerable<MoveCard>> GetAllMoveCard(MoveCard moveCard);
    }
}