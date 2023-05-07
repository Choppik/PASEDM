using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class RecipientDTO
    {
        [Key]
        public int ID { get; set; }
        public int? UserID { get; set; }
        public UserDTO User { get; set; }
        public int? CardID { get; set; }
        public CardDTO Card { get; set; }
        public ICollection<SenderDTO> Senders { get; set; }
    }
}