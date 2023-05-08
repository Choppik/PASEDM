using PASEDM.Data.DTOs;
using PASEDM.Data;
using PASEDM.Models;
using System.Threading.Tasks;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;

namespace PASEDM.Services.PASEDMCreator
{
    public class DatabaseMoveUserCreator : IMoveUserCreator
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseMoveUserCreator(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task AddMoveUser(MoveUser moveUser)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    MoveUserDTO moveUserDTO = ToMoveUserDTO(moveUser);
                    context.MoveUsers.Add(moveUserDTO);
                }
                finally
                {
                    await context.SaveChangesAsync();
                }
            }
        }

        private static MoveUserDTO ToMoveUserDTO(MoveUser moveUser)
        {
            return new MoveUserDTO()
            {
                TypeUserID = moveUser.TypeUserID,
                CardID = moveUser.CardID
            };
        }
    }
}