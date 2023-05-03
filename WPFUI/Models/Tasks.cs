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

        public Tasks(int id, string nameTask, string contents)
        {
            Id = id;
            NameTask = nameTask;
            Contents = contents;
        }

        public int Id { get; }
        public string NameTask { get; }
        public string Contents { get; }
        public Task<IEnumerable<Tasks>> GetAllTasks()
        {
            return _tasksProviders.GetAllTasks();
        }
    }
}