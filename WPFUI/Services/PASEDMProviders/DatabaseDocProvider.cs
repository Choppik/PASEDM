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
                IEnumerable<DocumentDTO> docDTOs = await context.Documents
                    .Include(u => u.SecrecyStamps)
                    .Include(u => u.DocStages)
                    .Include(u => u.DocumentTypes)
                    .Include(u => u.Term)
                    .ToListAsync();

                return docDTOs.Select(u => ToDoc(u));
            }
        }
        private static Document ToDoc(DocumentDTO dto)
        {
            SecrecyStamps secrecyStamps = new(dto.SecrecyStamps.ID, dto.SecrecyStamps.SecrecyStamp, dto.SecrecyStamps.SecrecyStampValue);
            DocumentTypes documentTypes = new(dto.DocumentTypes.ID, dto.DocumentTypes.Name);
            DocStages docStages = new(dto.DocStagesID, dto.DocStages.NameDocStage, dto.DocStages.DocStagesValue);
            Deadlines deadlines = new(dto.Term.ID, dto.Term.NameTerm, dto.Term.Term);

            return new Document(dto.ID, dto.NameDoc, dto.RegistrationNumber, dto.Summary, dto.File, deadlines, secrecyStamps, docStages, documentTypes);
        }
        public async Task<Document> GetDoc(Document document)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                DocumentDTO docDTO = await context.Documents
                    .Where(u => u.NameDoc == document.NameDoc
                    && u.RegistrationNumber == document.RegistrationNumber
                    && u.Summary == document.Summary
                    && u.File == document.File
                    && u.TermID == document.Term.Id
                    && u.SecrecyStampsID == document.SecrecyStamp.Id
                    && u.DocStagesID == document.DocStages.Id
                    && u.DocumentTypesID == document.DocumentTypes.Id)
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