using PASEDM.Data.DTOs;
using PASEDM.Data;
using PASEDM.Models;
using System.Linq;
using System.Threading.Tasks;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MaterialDesignThemes.Wpf;

namespace PASEDM.Services.PASEDMProviders
{
    public class DatabaseMoveUserProvider : IMoveUserProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseMoveUserProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<MoveUser>> GetAllMoveUserSender(MoveUser moveUser, User user)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<MoveUserDTO> moveUserDTO = await context.MoveUsers
                    .Include(u => u.Card).ThenInclude(u => u.Recipient).ThenInclude(u => u.User)
                    .Where(p => p.TypeUserID == moveUser.TypeUserID && p.Card.UserID == user.Id)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.DocStages)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.SecrecyStamps)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.Term)
                    .Include(u => u.Card).ThenInclude(u => u.DocumentTypes)
                    .Include(u => u.Card).ThenInclude(u => u.Employee)
                    .Include(u => u.Card).ThenInclude(u => u.Task).ThenInclude(u => u.TaskStages)
                    .Include(u => u.Card).ThenInclude(u => u.Case)
                    .Include(u => u.Card).ThenInclude(u => u.User)
                    .ToListAsync();

                if (moveUserDTO == null)
                {
                    return null;
                }

                return moveUserDTO.Select(u => ToMoveUserEdit(u));
            }
        }
        public async Task<IEnumerable<MoveUser>> GetAllMoveUserRecipient(MoveUser moveUser, User user)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<MoveUserDTO> moveUserDTO = await context.MoveUsers
                    .Include(u => u.Card).ThenInclude(u => u.Recipient).ThenInclude(u => u.User)
                    .Where(p => p.TypeUserID == moveUser.TypeUserID && p.Card.Recipient.UserID == user.Id)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.DocStages)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.SecrecyStamps)
                    .Include(u => u.Card).ThenInclude(u => u.Document).ThenInclude(u => u.Term)
                    .Include(u => u.Card).ThenInclude(u => u.DocumentTypes)
                    .Include(u => u.Card).ThenInclude(u => u.Employee)
                    .Include(u => u.Card).ThenInclude(u => u.Task).ThenInclude(u => u.TaskStages)
                    .Include(u => u.Card).ThenInclude(u => u.Case)
                    .Include(u => u.Card).ThenInclude(u => u.User)
                    .OrderBy(u => u.CardID)
                    .ToListAsync();

                if (moveUserDTO == null)
                {
                    return null;
                }

                return moveUserDTO.Select(u => ToMoveUserEdit(u));
            }
        }
        private static MoveUser ToMoveUserEdit(MoveUserDTO dto)
        {
            Document document = new(dto.Card.Document.ID, dto.Card.Document.NameDoc, dto.Card.Document.RegistrationNumber, dto.Card.Document.DateCreateDoc, dto.Card.Document.Summary, dto.Card.Document.Path, dto.Card.Document.TermID, dto.Card.Document.SecrecyStampsID, dto.Card.Document.DocStagesID);
            DocumentTypes documentTypes = new(dto.Card.DocumentTypes.ID, dto.Card.DocumentTypes.Name);
            Tasks tasks = new(dto.Card.TaskID, dto.Card.Task.NameTask, dto.Card.Task.Contents, dto.Card.Task.TaskStagesID);
            TaskStages taskStages = new(dto.Card.Task.TaskStages.ID, dto.Card.Task.TaskStages.TaskStages, dto.Card.Task.TaskStages.TaskStagesValue);
            Case cases = new(dto.Card.Case.ID, dto.Card.Case.NumberCase, dto.Card.Case.Desription);
            Employee employee = new(dto.Card.EmployeeID, dto.Card.Employee.NumberEmployee, dto.Card.Employee.FullName, dto.Card.Employee.Mail, dto.Card.Employee.AccessRightsID, dto.Card.Employee.DivisionID);
            DocStages docStages = new(dto.Card.Document.DocStagesID, dto.Card.Document.DocStages.NameDocStage, dto.Card.Document.DocStages.DocStagesValue);
            SecrecyStamps secrecyStamps = new(dto.Card.Document.SecrecyStamps.ID, dto.Card.Document.SecrecyStamps.SecrecyStamp, dto.Card.Document.SecrecyStamps.SecrecyStampValue);
            Deadlines deadlines = new(dto.Card.Document.Term.ID, dto.Card.Document.Term.NameTerm, dto.Card.Document.Term.Term);
            User user = new(dto.Card.Recipient.User.ID, dto.Card.Recipient.User.UserName);

            return new MoveUser(
                dto.ID,
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
        public async Task DeleteMoveUser(MoveUser moveUser)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    MoveUserDTO moveUserDTO = await context.MoveUsers
                        .Where(x => x.ID == moveUser.Id)
                        .FirstOrDefaultAsync();

                    if (moveUserDTO != null) context.MoveUsers.Remove(moveUserDTO);
                }
                finally
                {
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}