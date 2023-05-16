using PASEDM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders.InterfaceProviders
{
    public interface ICardProvider
    {
        Task<Card> GetCard(Card card);
        Task<IEnumerable<Card>> GetAllTaskExecutor(User user);
    }
}