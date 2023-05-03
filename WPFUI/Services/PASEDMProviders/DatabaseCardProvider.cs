using PASEDM.Data.DTOs;
using PASEDM.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.Models;
using Microsoft.EntityFrameworkCore;

namespace PASEDM.Services.PASEDMProviders
{
    public class DatabaseCardProvider : ICardProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseCardProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<Card>> GetAllCard()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<CardDTO> cardDTOs = await context.Cards
                    .Include(u => u.Document)
                    .Include(u => u.DocumentTypes)
                    .Include(u => u.Case)
                    .Include(u => u.User)
                    .Include(u => u.Employee)
                    .Include(u => u.Recipient).ThenInclude(u => u.User)
                    .ToListAsync();

                return cardDTOs.Select(u => ToCard(u));
            }
        }
        private static Card ToCard(CardDTO dto)
        {
            return new Card(dto.NumberCard, dto.NameCard, dto.Comment, dto.Document.NameDoc, dto.DocumentTypes.Name, dto.Case.NumberCase, dto.User.UserName, dto.Employee.FullName, dto.Recipient.User.UserName);
        }
/*        public async Task<Document> GetDoc(Document document)
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
        }*/
    }
}