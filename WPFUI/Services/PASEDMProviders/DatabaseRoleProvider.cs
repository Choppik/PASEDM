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
    public class DatabaseRoleProvider : IRoleProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseRoleProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<Role>> GetAllRole()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<RoleDTO> roleDTOs = await context.Role.ToListAsync();

                return roleDTOs.Select(u => ToRoles(u));
            }
        }

        private static Role ToRoles(RoleDTO dto)
        {
            return new Role(dto.ID, dto.NameRole, dto.SignificanceRole);
        }
    }
}