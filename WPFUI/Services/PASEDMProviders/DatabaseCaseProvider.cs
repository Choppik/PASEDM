using Microsoft.EntityFrameworkCore;
using PASEDM.Data;
using PASEDM.Data.DTOs;
using PASEDM.Models;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders
{
    public class DatabaseCaseProvider : ICasesProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseCaseProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<Case>> GetAllCase()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<CaseDTO> caseDTOs = await context.Cases.ToListAsync();

                return caseDTOs.Select(u => ToCase(u));
            }
        }
        private static Case ToCase(CaseDTO dto)
        {
            return new Case(dto.ID, dto.NumberCase, dto.Desription);
        }
    }
}