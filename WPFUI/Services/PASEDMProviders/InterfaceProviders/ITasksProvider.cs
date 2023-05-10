using PASEDM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders.InterfaceProviders
{
    public interface ITasksProvider
    {
        Task<IEnumerable<Tasks>> GetAllTasks();
        Task EditTask(Tasks task);
        Task<Tasks> GetTask(Tasks task);
    }
}