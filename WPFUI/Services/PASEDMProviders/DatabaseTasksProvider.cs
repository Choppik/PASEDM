using PASEDM.Data.DTOs;
using PASEDM.Data;
using PASEDM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;

namespace PASEDM.Services.PASEDMProviders
{
    public class DatabaseTasksProvider : ITasksProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseTasksProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<Tasks>> GetAllTasks()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<TaskDTO> taskDTOs = await context.Tasks.ToListAsync();

                return taskDTOs.Select(u => ToTasks(u));
            }
        }

        private static Tasks ToTasks(TaskDTO dto)
        {
            return new Tasks(dto.NameTask, dto.Contents);
        }
    }
}