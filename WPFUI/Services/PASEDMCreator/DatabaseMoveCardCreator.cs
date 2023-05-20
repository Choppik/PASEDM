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

        public async Task AddMoveCard(MoveCard moveUser)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    MoveCardDTO moveCardDTO = ToMoveCardDTO(moveUser);
                    context.MoveCards.Add(moveCardDTO);
                }
                finally
                {
                    await context.SaveChangesAsync();
                }
            }
        }

        private static MoveCardDTO ToMoveCardDTO(MoveCard moveUser)
        {
            return new MoveCardDTO()
            {
                TypeUserID = moveUser.TypeUserID,
                Viewed = moveUser.Viewed,
                CardID = moveUser.CardID
            };
        }
    }
}