using PASEDM.Data;
using PASEDM.Data.DTOs;
using PASEDM.Models;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMCreator
{
    public class DatabaseMoveDocumentCreator : IMoveDocumentCreator
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseMoveDocumentCreator(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task AddMoveDocument(MoveDocument moveDocument)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    MoveDocumentDTO moveDocumentDTO = ToMoveDocumentDTO(moveDocument);
                    context.MoveDocuments.Add(moveDocumentDTO);
                }
                finally
                {
                    await context.SaveChangesAsync();
                }
            }
        }
        private static MoveDocumentDTO ToMoveDocumentDTO(MoveDocument moveDocument)
        {
            return new MoveDocumentDTO()
            {
                UserID = moveDocument.User.Id,
                DocumentID = moveDocument.Document.Id
            };
        }
    }
}
