using PASEDM.Data.DTOs;
using PASEDM.Data;
using System.Threading.Tasks;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Models;

namespace PASEDM.Services.PASEDMCreator
{
    public class DatabaseRecipientCreator : IRecipientCreator
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseRecipientCreator(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task AddRecipient(Recipient recipient)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    RecipientDTO recipientDTO = ToRecipientDTO(recipient);
                    context.Recipients.Add(recipientDTO);
                }
                finally
                {
                    await context.SaveChangesAsync();
                }
            }
        }

        private static RecipientDTO ToRecipientDTO(Recipient recipient)
        {
            return new RecipientDTO()
            {
                ID = recipient.Id,
                TaskID = recipient.TaskID,
                UserID = recipient.UserID
            };
        }
    }
}