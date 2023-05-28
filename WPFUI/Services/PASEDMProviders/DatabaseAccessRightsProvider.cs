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
    public class DatabaseAccessRightsProvider : IAccessRightsProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseAccessRightsProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<AccessRights>> GetAllAccessRights()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<AccessRightsDTO> accessRightsDTO = await context.AccessRights.ToListAsync();

                return accessRightsDTO.Select(u => ToAccessRights(u));
            }
        }
        private static AccessRights ToAccessRights(AccessRightsDTO dto)
        {
            return new AccessRights(dto.ID, dto.AccessRights, dto.AccessRightsValue);
        }
    }
}