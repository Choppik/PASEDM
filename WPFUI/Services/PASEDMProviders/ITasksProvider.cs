using PASEDM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders
{
    public interface ITasksProvider
    {
        Task<IEnumerable<Tasks>> GetAllTasks();
    }
}