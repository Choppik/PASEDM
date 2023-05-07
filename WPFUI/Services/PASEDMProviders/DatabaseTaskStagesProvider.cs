using Microsoft.EntityFrameworkCore;
using PASEDM.Data;
using PASEDM.Data.DTOs;
using PASEDM.Models;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders
{
    public class DatabaseTaskStagesProvider : ITaskStagesProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseTaskStagesProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<TaskStages>> GetAllTaskStages()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<TaskStagesDTO> taskStagesDTOs = await context.TaskStages.ToListAsync();

                return taskStagesDTOs.Select(u => ToTaskStages(u));
            }
        }
        private static TaskStages ToTaskStages(TaskStagesDTO dto)
        {
            return new TaskStages(dto.ID, dto.TaskStages, dto.TaskStagesValue);
        }
    }
}