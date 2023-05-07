using PASEDM.Data.DTOs;
using PASEDM.Data;
using PASEDM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using Microsoft.EntityFrameworkCore;

namespace PASEDM.Services.PASEDMProviders
{
    public class DatabaseSenderProvider : ISenderProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseSenderProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<Sender>> GetAllSender(User user)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<SenderDTO> senderDTOs = await context.Senders
                    .Include(u => u.Recipient).ThenInclude(u => u.Card)
                    .Where(p => p.Recipient.Card.UserID == user.Id)
                    .Include(u => u.Recipient).ThenInclude(u => u.Card)
                    .Include(u => u.Recipient).ThenInclude(u => u.Card).ThenInclude(u => u.Document)
                    .Include(u => u.Recipient).ThenInclude(u => u.Card).ThenInclude(u => u.DocumentTypes)
                    .Include(u => u.Recipient).ThenInclude(u => u.Card).ThenInclude(u => u.Task).ThenInclude(u => u.TaskStages)
                    .Include(u => u.Recipient).ThenInclude(u => u.Card).ThenInclude(u => u.Case)
                    .Include(u => u.Recipient).ThenInclude(u => u.Card).ThenInclude(u => u.Employee)
                    .Include(u => u.Recipient).ThenInclude(u => u.User)
                    .ToListAsync();

                return senderDTOs.Select(u => ToSender(u));
            }
        }
        private static Sender ToSender(SenderDTO dto)
        {
            return new Sender(
                dto.Recipient.Card.NumberCard,
                dto.Recipient.Card.NameCard,
                dto.Recipient.Card.Document.NameDoc,
                dto.Recipient.Card.DocumentTypes.Name,
                dto.Recipient.Card.Task.NameTask,
                dto.Recipient.Card.Task.Contents,
                dto.Recipient.Card.Task.TaskStages.TaskStages,
                dto.Recipient.Card.Case.NumberCase,
                dto.Recipient.Card.Case.Desription,
                dto.Recipient.Card.Employee.FullName,
                dto.Recipient.Card.DateOfFormation,
                dto.Recipient.Card.Comment,
                dto.Recipient.User.UserName
                );
        }
    }
}
