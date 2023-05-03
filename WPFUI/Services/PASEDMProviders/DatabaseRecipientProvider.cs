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
        public async Task<IEnumerable<Recipient>> GetAllRecipient()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<RecipientDTO> recipientDTOs = await context.Recipients.ToListAsync();

                return recipientDTOs.Select(u => ToRecipient(u));
            }
        }
        private static Recipient ToRecipient(RecipientDTO dto)
        {
            return new Recipient(dto.ID, dto.DateOfReceipt, dto.TaskID, dto.UserID);
        }
        public async Task<Recipient> GetRecipient(Recipient recipient)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                RecipientDTO recipientDTO = await context.Recipients
                    .Where(u => u.UserID == recipient.UserID)
                    .Where(u => u.DateOfReceipt == recipient.DateOfReceipt)
                    .FirstOrDefaultAsync();

                if (recipientDTO == null)
                {
                    return null;
                }

                return ToRecipient(recipientDTO);
            }
        }
    }
}