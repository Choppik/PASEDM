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
    public class DatabaseTypeUserProvider : ITypeCardProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseTypeUserProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<TypeCard>> GetAllTypeUsers()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<TypeCardDTO> typeUserDTOs = await context.TypeCards.ToListAsync();

                return typeUserDTOs.Select(u => ToTypeUser(u));
            }
        }
        private static TypeCard ToTypeUser(TypeCardDTO dto)
        {
            return new TypeCard(dto.ID, dto.TypeCard, dto.TypeCardValue);
        }
    }
}