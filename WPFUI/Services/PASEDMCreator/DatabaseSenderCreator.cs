using PASEDM.Data.DTOs;
using PASEDM.Data;
using PASEDM.Models;
using System.Threading.Tasks;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;

namespace PASEDM.Services.PASEDMCreator
{
    public class DatabaseSenderCreator : ISenderCreator
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseSenderCreator(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task AddSender(Recipient recipient)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    SenderDTO senderDTO = ToSenderDTO(recipient);
                    context.Senders.Add(senderDTO);
                }
                finally
                {
                    await context.SaveChangesAsync();
                }
            }
        }

        private static SenderDTO ToSenderDTO(Recipient recipient)
        {
            return new SenderDTO()
            {
                RecipientID = recipient.Id
            };
        }
    }
}