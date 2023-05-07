using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class TaskDTO
    {
        [Key]
        public int ID { get; set; }
        public string NameTask { get; set; }
        public string Contents { get; set; }
        public int? TaskStagesID { get; set; }
        public TaskStagesDTO TaskStages { get; set; }
        public ICollection<CardDTO> Cards { get; set; }
    }
}