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
    public class DatabaseDocTypProvider : IDocTypProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseDocTypProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<DocumentTypes>> GetAllDocTyp()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<DocumentTypesDTO> docTypDTOs = await context.DocumentTypes.ToListAsync();

                return docTypDTOs.Select(u => ToDocTyp(u));
            }
        }
        private static DocumentTypes ToDocTyp(DocumentTypesDTO dto)
        {
            return new DocumentTypes(dto.ID, dto.Name);
        }
    }
}