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
    public class DatabaseDivisionProvider : IDivisionProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseDivisionProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<Division>> GetAllDivisions()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<DivisionDTO> divisionDTO = await context.Divisions.ToListAsync();

                return divisionDTO.Select(u => ToDivisions(u));
            }
        }
        private static Division ToDivisions(DivisionDTO dto)
        {
            return new Division(dto.ID, dto.NumberDivision, dto.Division);
        }
    }
}