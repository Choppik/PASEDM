using PASEDM.Models;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMCreator.InterfaceCreator
{
    public interface IMoveCardCreator
    {
        Task AddMoveCard(MoveCard moveUser);
    }
}