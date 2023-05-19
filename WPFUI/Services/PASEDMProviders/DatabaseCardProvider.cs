using PASEDM.Data.DTOs;
using PASEDM.Data;
using System.Linq;
using System.Threading.Tasks;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PASEDM.Services.PASEDMProviders
{
    public class DatabaseCardProvider : ICardProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseCardProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<Card> GetCard(Card card)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                CardDTO cardDTO = await context.Cards
                    .Where(u => u.DateOfFormation == card.DateOfFormation)
                    .FirstOrDefaultAsync();

                if (cardDTO == null)
                {
                    return null;
                }

                return ToDefiniteCard(cardDTO);
            }
        }
        private static Card ToDefiniteCard(CardDTO dto)
        {
            return new Card(dto.ID, dto.NameCard);
        }

        public async Task<IEnumerable<Card>> GetAllTaskExecutor(User user)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<CardDTO> cardDTO = await context.Cards
                    .Where(u => u.EmployeeID == user.EmployeeID)
                    .Include(u => u.Task).ThenInclude(u => u.TaskStages)
                    .OrderBy(u => u.Task.TaskStages.TaskStagesValue)
                    .ToListAsync();

                if (cardDTO == null)
                {
                    return null;
                }

                return cardDTO.Select(u => ToTasksExecutor(u)).DistinctBy(u => u.TaskID);
            }
        }

        private Card ToTasksExecutor(CardDTO dto)
        {
            return new Card(dto.ID, dto.TaskID, dto.Task.NameTask, dto.Task.Contents, dto.Task.TaskStages.TaskStages);
        }
    }
}