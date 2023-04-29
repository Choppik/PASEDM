using System.Collections.Generic;

namespace PASEDM.Data.DTOs
{
    public class TaskDTO
    {
        public int ID { get; set; }
        public string NameTask { get; set; }
        public string Contents { get; set; }
        public string ConditionTask { get; set; }
        public ICollection<CardDTO> Cards { get; set; }
        public ICollection<RecipientDTO> Recipients { get; set; }
    }
}