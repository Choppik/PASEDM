using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class TaskStages
    {
        private ITaskStagesProvider _taskStagesProvider;

        public TaskStages() { }
        public TaskStages(ITaskStagesProvider taskStagesProvider)
        {
            _taskStagesProvider = taskStagesProvider;
        }

        public TaskStages(int id, string nameTaskStage, int taskStagesValue)
        {
            Id = id;
            NameTaskStage = nameTaskStage;
            TaskStagesValue = taskStagesValue;
        }

        public int Id { get; }
        public string NameTaskStage { get; set; }
        public int TaskStagesValue { get; }
        public Task<IEnumerable<TaskStages>> GetAllTaskStages()
        {
            return _taskStagesProvider.GetAllTaskStages();
        }
        public override string ToString()
        {
            return $"{NameTaskStage}";
        }
    }
}