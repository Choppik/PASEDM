using PASEDM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders.InterfaceProviders
{
    public interface IMoveCardProvider
    {
        Task<IEnumerable<MoveCard>> GetAllMoveCardUniq(MoveCard moveCard);
        Task DeleteMoveCard(MoveCard moveUser);
        int GetCountViewedMoveCard(User user);
        Task<IEnumerable<MoveCard>> GetAllMoveCard();
    }
}