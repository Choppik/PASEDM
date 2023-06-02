using PASEDM.Data.DTOs;
using PASEDM.Data;
using PASEDM.Models;
using System.Linq;
using System.Threading.Tasks;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PASEDM.Services.PASEDMProviders
{
    public class DatabaseMoveCardProvider : IMoveCardProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseMoveCardProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<MoveCard>> GetAllMoveCardUniq(MoveCard moveCard)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<MoveCardDTO> moveCardDTO;

                if (moveCard.TypeCard.TypeCardValue > 0)
                {
                    moveCardDTO = await context.MoveCards
                    .Where(p => p.TypeCard.TypeCardValue > 0 && p.User.ID != moveCard.User.Id)
                    .Include(u => u.User)
                    .Include(u => u.TypeCard)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.DocStages)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.SecrecyStamps)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.Term)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.DocumentTypes)
                    .Include(u => u.Card).ThenInclude(u => u.Employee).ThenInclude(u => u.AccessRights)
                    .Include(u => u.Card).ThenInclude(u => u.Employee).ThenInclude(u => u.Division)
                    .Include(u => u.Card).ThenInclude(u => u.Task).ThenInclude(u => u.TaskStages)
                    .Include(u => u.Card).ThenInclude(u => u.Case)
                    .ToListAsync();
                }
                else
                {
                    moveCardDTO = await context.MoveCards
                    .Where(p => p.TypeCard.TypeCardValue == 0 && p.User.ID != moveCard.User.Id)
                    .Include(u => u.User)
                    .Include(u => u.TypeCard)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.DocStages)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.SecrecyStamps)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.Term)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.DocumentTypes)
                    .Include(u => u.Card).ThenInclude(u => u.Employee).ThenInclude(u => u.AccessRights)
                    .Include(u => u.Card).ThenInclude(u => u.Employee).ThenInclude(u => u.Division)
                    .Include(u => u.Card).ThenInclude(u => u.Task).ThenInclude(u => u.TaskStages)
                    .Include(u => u.Card).ThenInclude(u => u.Case)
                    .ToListAsync();
                }

                if (moveCardDTO == null)
                {
                    return null;
                }

                return moveCardDTO.Select(u => ToMoveCard(u));
            }
        }
        private static MoveCard ToMoveCard(MoveCardDTO dto)
        {
            SecrecyStamps secrecyStamps = new(dto.Card.Document.SecrecyStamps.ID, dto.Card.Document.SecrecyStamps.SecrecyStamp, dto.Card.Document.SecrecyStamps.SecrecyStampValue);
            DocumentTypes documentTypes = new(dto.Card.Document.DocumentTypes.ID, dto.Card.Document.DocumentTypes.Name);
            DocStages docStages = new(dto.Card.Document.DocStagesID, dto.Card.Document.DocStages.NameDocStage, dto.Card.Document.DocStages.DocStagesValue);
            Deadlines deadlines = new(dto.Card.Document.Term.ID, dto.Card.Document.Term.NameTerm, dto.Card.Document.Term.Term);
            Document document = new(dto.Card.Document.ID, dto.Card.Document.NameDoc, dto.Card.Document.RegistrationNumber, dto.Card.Document.Summary, dto.Card.Document.FileDoc, deadlines, secrecyStamps, docStages, documentTypes);
            TaskStages taskStages = new(dto.Card.Task.TaskStages.ID, dto.Card.Task.TaskStages.TaskStages, dto.Card.Task.TaskStages.TaskStagesValue);
            Tasks tasks = new(dto.Card.TaskID, dto.Card.Task.NameTask, dto.Card.Task.Contents, taskStages);
            Case cases = new(dto.Card.Case.ID, dto.Card.Case.NumberCase, dto.Card.Case.Desription);
            AccessRights accessRights = new(dto.Card.Employee.AccessRights.ID, dto.Card.Employee.AccessRights.AccessRights, dto.Card.Employee.AccessRights.AccessRightsValue);
            Division division = new(dto.Card.Employee.Division.ID, dto.Card.Employee.Division.NumberDivision, dto.Card.Employee.Division.Division);
            Employee employee = new(dto.Card.EmployeeID, dto.Card.Employee.NumberEmployee, dto.Card.Employee.FullName, dto.Card.Employee.Mail, accessRights, division);
            User user = new(dto.User.ID, dto.User.UserName);
            Card card = new(dto.Card.ID, dto.Card.NumberCard, dto.Card.NameCard, dto.Card.Comment, dto.Card.DateOfFormation, document, tasks, cases, employee);
            TypeCard typeCard = new(dto.TypeCard.ID, dto.TypeCard.TypeCard, dto.TypeCard.TypeCardValue);

            return new MoveCard(
                dto.ID,
                dto.Viewed,
                card,
                typeCard,
                user
                );
        }
        public async Task DeleteMoveCard(MoveCard moveCard)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    MoveCardDTO moveCardDTO = await context.MoveCards
                        .Where(x => x.ID == moveCard.Id)
                        .FirstOrDefaultAsync();

                    if (moveCardDTO != null) context.MoveCards.Remove(moveCardDTO);
                }
                finally
                {
                    await context.SaveChangesAsync();
                }
            }
        }
        public int GetCountViewedMoveCard(User user)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                int moveCardDTO = context.MoveCards
                    .Include(x => x.Card)
                    .Include(x => x.User)
                    .Include(x => x.TypeCard)
                    .Where(u => u.Viewed == 0 && u.TypeCard.TypeCardValue == 1 && u.User.ID == user.Id)
                    .Count();

                return moveCardDTO;
            }
        }
        public async Task<IEnumerable<MoveCard>> GetAllMoveCard()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<MoveCardDTO> moveCardDTO = await context.MoveCards
                    .Include(u => u.Card)
                    .Include(u => u.User)
                    .Include(u => u.TypeCard)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.DocStages)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.SecrecyStamps)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.Term)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.DocumentTypes)
                    .Include(u => u.Card).ThenInclude(u => u.Employee).ThenInclude(u => u.AccessRights)
                    .Include(u => u.Card).ThenInclude(u => u.Employee).ThenInclude(u => u.Division)
                    .Include(u => u.Card).ThenInclude(u => u.Task).ThenInclude(u => u.TaskStages)
                    .Include(u => u.Card).ThenInclude(u => u.Case)
                    .OrderBy(u => u.CardID)
                    .ToListAsync();

                if (moveCardDTO == null)
                {
                    return null;
                }

                return moveCardDTO.Select(u => ToMoveCard(u));
            }
        }
    }
}