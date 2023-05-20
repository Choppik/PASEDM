using PASEDM.Data.DTOs;
using PASEDM.Data;
using PASEDM.Models;
using System.Threading.Tasks;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;

namespace PASEDM.Services.PASEDMCreator
{
    public class DatabaseMoveCardCreator : IMoveCardCreator
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseMoveCardCreator(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task AddMoveCard(MoveCard moveCard)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    MoveCardDTO moveCardDTO = ToMoveCardDTO(moveCard);
                    context.MoveCards.Add(moveCardDTO);
                }
                finally
                {
                    await context.SaveChangesAsync();
                }
            }
        }

        private static MoveCardDTO ToMoveCardDTO(MoveCard moveCard)
        {
            return new MoveCardDTO()
            {
                TypeUserID = moveCard.TypeUserID,
                Viewed = moveCard.Viewed,
                CardID = moveCard.CardID
            };
        }
    }
}