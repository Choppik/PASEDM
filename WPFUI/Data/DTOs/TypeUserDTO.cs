using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class TypeUserDTO
    {
        [Key]
        public int ID { get; set; }
        public string TypeUser { get; set; }
        public int TypeUserValue { get; set; }
        public ICollection<MoveUserDTO> MoveUsers { get; set; }
    }
}