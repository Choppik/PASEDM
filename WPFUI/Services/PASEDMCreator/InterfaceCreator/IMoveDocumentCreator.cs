using PASEDM.Models;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMCreator.InterfaceCreator
{
    public interface IMoveDocumentCreator
    {
        Task AddMoveDocument(MoveDocument moveDocument);
    }
}