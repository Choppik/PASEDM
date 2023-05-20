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
        public async Task<IEnumerable<MoveCard>> GetAllMoveUserSender(MoveCard moveCard, User user)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<MoveCardDTO> moveCardDTO = await context.MoveCards
                    .Include(u => u.Card).ThenInclude(u => u.Recipient).ThenInclude(u => u.User)
                    .Where(p => p.TypeUserID == moveCard.TypeUserID && p.Card.UserID == user.Id)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.DocStages)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.SecrecyStamps)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.Term)
                    .Include(u => u.Card).ThenInclude(u => u.DocumentTypes)
                    .Include(u => u.Card).ThenInclude(u => u.Employee).ThenInclude(u => u.AccessRights)
                    .Include(u => u.Card).ThenInclude(u => u.Task).ThenInclude(u => u.TaskStages)
                    .Include(u => u.Card).ThenInclude(u => u.Case)
                    .Include(u => u.Card).ThenInclude(u => u.User)
                    .ToListAsync();

                if (moveCardDTO == null)
                {
                    return null;
                }

                return moveCardDTO.Select(u => ToMoveCardEdit(u));
            }
        }
        public async Task<IEnumerable<MoveCard>> GetAllMoveUserRecipient(MoveCard moveCard, User user)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<MoveCardDTO> moveCardDTO = await context.MoveCards
                    .Include(u => u.Card).ThenInclude(u => u.Recipient).ThenInclude(u => u.User)
                    .Where(p => p.TypeUserID == moveCard.TypeUserID && p.Card.Recipient.UserID == user.Id)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.DocStages)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.SecrecyStamps)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.Term)
                    .Include(u => u.Card).ThenInclude(u => u.DocumentTypes)
                    .Include(u => u.Card).ThenInclude(u => u.Employee).ThenInclude(u => u.AccessRights)
                    .Include(u => u.Card).ThenInclude(u => u.Task).ThenInclude(u => u.TaskStages)
                    .Include(u => u.Card).ThenInclude(u => u.Case)
                    .Include(u => u.Card).ThenInclude(u => u.User)
                    .OrderBy(u => u.CardID)
                    .ToListAsync();

                if (moveCardDTO == null)
                {
                    return null;
                }

                return moveCardDTO.Select(u => ToMoveCardEdit(u));
            }
        }
        private static MoveCard ToMoveCardEdit(MoveCardDTO dto)
        {
            SecrecyStamps secrecyStamps = new(dto.Card.Document.SecrecyStamps.ID, dto.Card.Document.SecrecyStamps.SecrecyStamp, dto.Card.Document.SecrecyStamps.SecrecyStampValue);
            Document document = new(dto.Card.Document.ID, dto.Card.Document.NameDoc, dto.Card.Document.RegistrationNumber, dto.Card.Document.DateCreateDoc, dto.Card.Document.Summary, dto.Card.Document.Path, dto.Card.Document.TermID, secrecyStamps, dto.Card.Document.DocStagesID);
            DocumentTypes documentTypes = new(dto.Card.DocumentTypes.ID, dto.Card.DocumentTypes.Name);
            Tasks tasks = new(dto.Card.TaskID, dto.Card.Task.NameTask, dto.Card.Task.Contents, dto.Card.Task.TaskStagesID);
            TaskStages taskStages = new(dto.Card.Task.TaskStages.ID, dto.Card.Task.TaskStages.TaskStages, dto.Card.Task.TaskStages.TaskStagesValue);
            Case cases = new(dto.Card.Case.ID, dto.Card.Case.NumberCase, dto.Card.Case.Desription);
            AccessRights accessRights = new(dto.Card.Employee.AccessRights.ID, dto.Card.Employee.AccessRights.AccessRights, dto.Card.Employee.AccessRights.AccessRightsValue);
            Employee employee = new(dto.Card.EmployeeID, dto.Card.Employee.NumberEmployee, dto.Card.Employee.FullName, dto.Card.Employee.Mail, accessRights, dto.Card.Employee.DivisionID);
            DocStages docStages = new(dto.Card.Document.DocStagesID, dto.Card.Document.DocStages.NameDocStage, dto.Card.Document.DocStages.DocStagesValue);
            Deadlines deadlines = new(dto.Card.Document.Term.ID, dto.Card.Document.Term.NameTerm, dto.Card.Document.Term.Term);
            User user = new(dto.Card.Recipient.User.ID, dto.Card.Recipient.User.UserName);

            return new MoveCard(
                dto.ID,
                dto.Viewed,
                dto.CardID,
                dto.Card.NumberCard,
                dto.Card.NameCard,
                document,
                deadlines,
                docStages,
                secrecyStamps,
                documentTypes,
                tasks,
                taskStages,
                cases,
                employee,
                dto.Card.DateOfFormation,
                dto.Card.Comment,
                user,
                dto.Card.User.UserName
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
    }
}