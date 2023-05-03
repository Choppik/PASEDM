using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class RecipientDTO
    {
        [Key]
        public int ID { get; set; }
        public int? TaskID { get; set; }
        public TaskDTO Task { get; set; }
        public int? UserID { get; set; }
        public UserDTO User { get; set; }
        public ICollection<CardDTO> Cards { get; set; }
    }
}