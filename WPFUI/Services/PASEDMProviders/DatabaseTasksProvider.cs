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
            return new Tasks(dto.ID, dto.NameTask, dto.Contents, dto.TaskStagesID);
        }

        public async Task EditTask(Tasks task)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    TaskDTO taskDTO = await context.Tasks
                        .Where(t => t.ID == task.Id)
                        .FirstOrDefaultAsync();

                    if (taskDTO != null)
                    {
                        taskDTO.TaskStagesID = task.TaskStageID;
                    }
                }
                finally
                {
                    await context.SaveChangesAsync();
                }
            }
        }
        public async Task<Tasks> GetTask(Tasks tasks)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                TaskDTO taskDTO = await context.Tasks
                    .Where(u => u.NameTask == tasks.NameTask)
                    .FirstOrDefaultAsync();

                if (taskDTO == null)
                {
                    return null;
                }

                return ToDefiniteTask(taskDTO);
            }
        }
        private static Tasks ToDefiniteTask(TaskDTO dto)
        {
            return new Tasks(dto.ID, dto.NameTask, dto.Contents, dto.TaskStagesID);
        }
    }
}