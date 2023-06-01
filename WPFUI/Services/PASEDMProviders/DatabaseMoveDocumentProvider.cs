using Microsoft.EntityFrameworkCore;
using PASEDM.Data;
using PASEDM.Data.DTOs;
using PASEDM.Models;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders
{
    public class DatabaseMoveDocumentProvider : IMoveDocumentProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseMoveDocumentProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<MoveDocument>> GetAllMoveDocument(User user)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<MoveDocumentDTO> moveDocumentDTO = await context.MoveDocuments
                    .Where(p => p.UserID == user.Id)
                    .Include(u => u.User)
                    .Include(u => u.Document).ThenInclude(u => u.DocumentTypes)
                    .Include(u => u.Document).ThenInclude(u => u.DocStages)
                    .Include(u => u.Document).ThenInclude(u => u.SecrecyStamps)
                    .Include(u => u.Document).ThenInclude(u => u.Term)
                    .ToListAsync();

                if (moveDocumentDTO == null)
                {
                    return null;
                }

                return moveDocumentDTO.Select(u => ToMoveDoc(u));
            }
        }

        private MoveDocument ToMoveDoc(MoveDocumentDTO dto)
        {
            SecrecyStamps secrecyStamps = new(dto.Document.SecrecyStamps.ID, dto.Document.SecrecyStamps.SecrecyStamp, dto.Document.SecrecyStamps.SecrecyStampValue);
            DocStages docStages = new(dto.Document.DocStagesID, dto.Document.DocStages.NameDocStage, dto.Document.DocStages.DocStagesValue);
            Deadlines deadlines = new(dto.Document.Term.ID, dto.Document.Term.NameTerm, dto.Document.Term.Term);
            DocumentTypes documentTypes = new(dto.Document.DocumentTypes.ID, dto.Document.DocumentTypes.Name);
            Document document = new(dto.Document.ID, dto.Document.NameDoc, dto.Document.RegistrationNumber, dto.Document.Summary, dto.Document.File, deadlines, secrecyStamps, docStages, documentTypes);
            User user = new(dto.User.ID, dto.User.UserName);

            return new MoveDocument(
                dto.ID,
                user,
                document
                );
        }

        public async Task DeleteMoveDocument(MoveDocument moveDocument)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    MoveDocumentDTO moveDocumentDTO = await context.MoveDocuments
                        .Where(x => x.ID == moveDocument.Id)
                        .FirstOrDefaultAsync();

                    if (moveDocumentDTO != null) context.MoveDocuments.Remove(moveDocumentDTO);
                }
                finally
                {
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
