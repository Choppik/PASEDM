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
    public class DatabaseDocProvider : IDocProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseDocProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<Document>> GetAllDoc()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<DocumentDTO> docDTOs = await context.Documents.ToListAsync();

                return docDTOs.Select(u => ToDoc(u));
            }
        }
        private static Document ToDoc(DocumentDTO dto)
        {
            return new Document(dto.ID, dto.NameDoc, dto.RegistrationNumber, dto.DateCreateDoc, dto.Summary, dto.ConditionDoc, dto.SecrecyStamp, dto.Path, dto.TermID);
        }
        public async Task<Document> GetDoc(Document document)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                DocumentDTO docDTO = await context.Documents
                    .Where(u => u.NameDoc == document.NameDoc)
                    .FirstOrDefaultAsync();

                if (docDTO == null)
                {
                    return null;
                }

                return ToDefiniteDoc(docDTO);
            }
        }
        private static Document ToDefiniteDoc(DocumentDTO dto)
        {
            return new Document(dto.ID, dto.NameDoc);
        }
    }
}