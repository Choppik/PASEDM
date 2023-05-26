using PASEDM.Data.DTOs;
using PASEDM.Data;
using System.Threading.Tasks;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Models;

namespace PASEDM.Services.PASEDMCreator
{
    public class DatabaseTaskCreator : ITaskCreator
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseTaskCreator(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateTask(Tasks tasks)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    TaskDTO taskDTO = ToTaskDTO(tasks);
                    context.Tasks.Add(taskDTO);
                }
                finally
                {
                    await context.SaveChangesAsync();
                }
            }
        }

        private static TaskDTO ToTaskDTO(Tasks tasks)
        {
            return new TaskDTO()
            {
                NameTask = tasks.NameTask,
                Contents = tasks.Contents,
                TaskStagesID = tasks.TaskStage.Id
            };
        }
    }
}