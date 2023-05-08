using PASEDM.Data.DTOs;
using PASEDM.Data;
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
        public async Task<Recipient> GetRecipient(Recipient recipient)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                RecipientDTO recipientDTO = await context.Recipients
                    .Where(u => u.UserID == recipient.UserID)
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
            return new Recipient(dto.ID, dto.UserID);
        }
    }
}