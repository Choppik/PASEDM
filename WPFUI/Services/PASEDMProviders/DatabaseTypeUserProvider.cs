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
    public class DatabaseTypeUserProvider : ITypeUserProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseTypeUserProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<TypeUser>> GetAllTypeUsers()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<TypeUserDTO> typeUserDTOs = await context.TypeUsers.ToListAsync();

                return typeUserDTOs.Select(u => ToTypeUser(u));
            }
        }
        private static TypeUser ToTypeUser(TypeUserDTO dto)
        {
            return new TypeUser(dto.ID, dto.TypeUser, dto.TypeUserValue);
        }
    }
}