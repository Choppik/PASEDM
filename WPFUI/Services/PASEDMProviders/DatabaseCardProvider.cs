using PASEDM.Data.DTOs;
using PASEDM.Data;
using System.Linq;
using System.Threading.Tasks;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.Models;
using Microsoft.EntityFrameworkCore;

namespace PASEDM.Services.PASEDMProviders
{
    public class DatabaseCardProvider : ICardProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseCardProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<Card> GetCard(Card card)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                CardDTO cardDTO = await context.Cards
                    .Where(u => u.NameCard == card.NameCard)
                    .FirstOrDefaultAsync();

                if (cardDTO == null)
                {
                    return null;
                }

                return ToDefiniteCard(cardDTO);
            }
        }
        private static Card ToDefiniteCard(CardDTO dto)
        {
            return new Card(dto.ID, dto.NameCard);
        }
    }
}