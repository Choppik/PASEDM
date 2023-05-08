using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class MoveUserDTO
    {
        [Key]
        public int ID { get; set; }
        public int? TypeUserID { get; set; }
        public TypeUserDTO TypeUser { get; set; }
        public int? CardID { get; set; }
        public CardDTO Card { get; set; }
    }
}