using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Tasks
    {
        private readonly ITaskCreator _taskCreator;
        private readonly ITasksProvider _tasksProviders;

        public Tasks() { }
        public Tasks(string nameTask, string contents, TaskStages taskStage)
            :this(default, nameTask, contents, taskStage)
        { }
        public Tasks(int id, string nameTask, TaskStages taskStage)
            :this(id, nameTask, "", taskStage)
        { }
        public Tasks(int? id, string nameTask, string contents, TaskStages taskStage)
        {
            Id = id;
            NameTask = nameTask;
            Contents = contents;
            TaskStage = taskStage;
        }

        public Tasks(ITaskCreator taskCreator, ITasksProvider tasksProviders)
        {
            _taskCreator = taskCreator;
            _tasksProviders = tasksProviders;
        }

        public Tasks(ITasksProvider tasksProviders)
        {
            _tasksProviders = tasksProviders;
        }

        public int? Id { get; }
        public string NameTask { get; set; }
        public string Contents { get; }
        public TaskStages TaskStage { get; }

        public async Task AddTask(Tasks task)
        {
            await _taskCreator.CreateTask(task);
        }
        public Task<IEnumerable<Tasks>> GetAllTasks()
        {
            return _tasksProviders.GetAllTasks();
        }
        public Task EditTask(Tasks task)
        {
            return _tasksProviders.EditTask(task);
        }
        public Task<Tasks> GetTask(Tasks task)
        {
            return _tasksProviders.GetTask(task);
        }
        public override string ToString()
        {
            return $"{NameTask}";
        }
    }
}