using PASEDM.Data.DTOs;
using PASEDM.Data;
using PASEDM.Models;
using System.Linq;
using System.Threading.Tasks;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PASEDM.Services.PASEDMProviders
{
    public class DatabaseMoveUserProvider : IMoveUserProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseMoveUserProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<MoveUser>> GetAllMoveUserSender(MoveUser moveUser, User user)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<MoveUserDTO> moveUserDTO = await context.MoveUsers
                    .Where(p => p.TypeUserID == moveUser.TypeUserID && p.Card.UserID == user.Id)
                    .Include(u => u.Card).ThenInclude(u => u.Document)
                    .Include(u => u.Card).ThenInclude(u => u.DocumentTypes)
                    .Include(u => u.Card).ThenInclude(u => u.Employee)
                    .Include(u => u.Card).ThenInclude(u => u.Task).ThenInclude(u => u.TaskStages)
                    .Include(u => u.Card).ThenInclude(u => u.Recipient).ThenInclude(u => u.User)
                    .Include(u => u.Card).ThenInclude(u => u.Case)
                    .Include(u => u.Card).ThenInclude(u => u.User)
                    .ToListAsync();

                if (moveUserDTO == null)
                {
                    return null;
                }

                return moveUserDTO.Select(u => ToMoveUser(u));
            }
        }
        public async Task<IEnumerable<MoveUser>> GetAllMoveUserRecipient(MoveUser moveUser, User user)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<MoveUserDTO> moveUserDTO = await context.MoveUsers
                    .Include(u => u.Card).ThenInclude(u => u.Recipient).ThenInclude(u => u.User)
                    .Where(p => p.TypeUserID == moveUser.TypeUserID && p.Card.Recipient.UserID == user.Id)
                    .Include(u => u.Card).ThenInclude(u => u.Document)
                    .Include(u => u.Card).ThenInclude(u => u.DocumentTypes)
                    .Include(u => u.Card).ThenInclude(u => u.Employee)
                    .Include(u => u.Card).ThenInclude(u => u.Task).ThenInclude(u => u.TaskStages)
                    .Include(u => u.Card).ThenInclude(u => u.Case)
                    .Include(u => u.Card).ThenInclude(u => u.User)
                    .ToListAsync();

                if (moveUserDTO == null)
                {
                    return null;
                }

                return moveUserDTO.Select(u => ToMoveUser(u));
            }
        }
        private static MoveUser ToMoveUser(MoveUserDTO dto)
        {
            return new MoveUser(
                dto.Card.NumberCard,
                dto.Card.NameCard,
                dto.Card.Document.NameDoc,
                dto.Card.DocumentTypes.Name,
                dto.Card.Task.NameTask,
                dto.Card.Task.Contents,
                dto.Card.Task.TaskStages.TaskStages,
                dto.Card.Case.NumberCase,
                dto.Card.Case.Desription,
                dto.Card.Employee.FullName,
                dto.Card.DateOfFormation,
                dto.Card.Comment,
                dto.Card.User.UserName,
                dto.Card.Recipient.User.UserName
                );
        }

    }
}
