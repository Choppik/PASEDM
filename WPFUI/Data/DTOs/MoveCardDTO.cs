using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class MoveCardDTO
    {
        [Key]
        public int ID { get; set; }
        public int Viewed { get; set; }
        public int? TypeCardID { get; set; }
        public TypeCardDTO TypeCard { get; set; }
        public int? CardID { get; set; }
        public CardDTO Card { get; set; }
        public int? UserID { get; set; }
        public UserDTO User { get; set; }
    }
}