using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Tasks
    {
        private readonly ITasksProvider _tasksProviders;

        public Tasks(ITasksProvider tasksProviders)
        {
            _tasksProviders = tasksProviders;
        }

        public Tasks(string nameTask, string contents)
        {
            NameTask = nameTask;
            Contents = contents;
        }

        public string NameTask { get; }
        public string Contents { get; }
        public Task<IEnumerable<Tasks>> GetAllTasks()
        {
            return _tasksProviders.GetAllTasks();
        }
    }
}