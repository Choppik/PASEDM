using PASEDM.Models;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMCreator.InterfaceCreator
{
    public interface ICardCreator
    {
        Task CreateCard(Card card);
    }
}