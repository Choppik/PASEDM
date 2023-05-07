using PASEDM.Data.DTOs;
using PASEDM.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PASEDM.Models;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using Microsoft.EntityFrameworkCore;

namespace PASEDM.Services.PASEDMProviders
{
    public class DatabaseRecipientProvider : IRecipientProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseRecipientProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<Recipient>> GetAllRecipient(User user)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<RecipientDTO> recipientDTOs = await context.Recipients
                    .Where(p => p.UserID == user.Id)
                    .Include(u => u.Card)
                    .Include(u => u.Card).ThenInclude(u => u.Document)
                    .Include(u => u.Card).ThenInclude(u => u.DocumentTypes)
                    .Include(u => u.Card).ThenInclude(u => u.Task).ThenInclude(u => u.TaskStages)
                    .Include(u => u.Card).ThenInclude(u => u.Case)
                    .Include(u => u.Card).ThenInclude(u => u.Employee)
                    .Include(u => u.Card).ThenInclude(u => u.User)
                    .ToListAsync();

                return recipientDTOs.Select(u => ToRecipient(u));
            }
        }
        private static Recipient ToRecipient(RecipientDTO dto)
        {
            return new Recipient(
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
                dto.Card.User.UserName
                );
        }
        public async Task<Recipient> GetRecipient(Recipient recipient)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                RecipientDTO recipientDTO = await context.Recipients
                    .Where(u => u.CardID == recipient.CardID)
                    .FirstOrDefaultAsync();

                if (recipientDTO == null)
                {
                    return null;
                }

                return ToDefiniteRecipient(recipientDTO);
            }
        }
        private static Recipient ToDefiniteRecipient(RecipientDTO dto)
        {
            return new Recipient(dto.ID, dto.UserID, dto.CardID);
        }
    }
}