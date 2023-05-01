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
    public class DatabaseDeadlinesProvider : IDeadlinesProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseDeadlinesProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<Deadlines>> GetAllDeadlines()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<TermDTO> termDTOs = await context.Deadlines.ToListAsync();

                return termDTOs.Select(u => ToDeadlines(u));
            }
        }
        private static Deadlines ToDeadlines(TermDTO dto)
        {
            return new Deadlines(dto.ID, dto.NameTerm, dto.Term);
        }
    }
}