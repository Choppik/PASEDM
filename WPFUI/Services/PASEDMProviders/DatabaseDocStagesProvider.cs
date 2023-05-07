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
    public class DatabaseDocStagesProvider : IDocStagesProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseDocStagesProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<DocStages>> GetAllDocStages()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<DocStagesDTO> docStagesDTOs = await context.DocStages.ToListAsync();

                return docStagesDTOs.Select(u => ToDocStages(u));
            }
        }
        private static DocStages ToDocStages(DocStagesDTO dto)
        {
            return new DocStages(dto.ID, dto.DocStages, dto.DocStagesValue);
        }
    }
}
