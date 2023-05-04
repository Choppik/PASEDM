using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class TaskStagesDTO
    {
        [Key]
        public int ID { get; set; }
        public string TaskStages { get; set; }
        public int TaskStagesValue { get; set; }
        public ICollection<TaskDTO> Tasks { get; set; }
    }
}