using PASEDM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders.InterfaceProviders
{
    public interface IMoveDocumentProvider
    {
        Task<IEnumerable<MoveDocument>> GetAllMoveDocument(User user);
        Task DeleteMoveDocument(MoveDocument moveDocument);
    }
}
