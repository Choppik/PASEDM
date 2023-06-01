using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class TypeCardDTO
    {
        [Key]
        public int ID { get; set; }
        public string TypeCard { get; set; }
        public int TypeCardValue { get; set; }
        public ICollection<MoveCardDTO> MoveCards { get; set; }
    }
}