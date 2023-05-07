using PASEDM.Data.DTOs;
using PASEDM.Data;
using PASEDM.Models;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PASEDM.Services.PASEDMProviders
{
    public class DatabaseSecrecyStampsProvider : ISecrecyStampsProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseSecrecyStampsProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<SecrecyStamps>> GetAllSecrecyStamps()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<SecrecyStampDTO> secrecyStampsDTOs = await context.SecrecyStamps.ToListAsync();

                return secrecyStampsDTOs.Select(u => ToSecrecyStamps(u));
            }
        }
        private static SecrecyStamps ToSecrecyStamps(SecrecyStampDTO dto)
        {
            return new SecrecyStamps(dto.ID, dto.SecrecyStamp, dto.SecrecyStampValue);
        }
    }
}
