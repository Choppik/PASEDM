using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class RoleDTO
    {
        [Key]
        public int ID { get; set; }
        public string NameRole { get; set; }
        public int SignificanceRole { get; set; }
        public ICollection<UserDTO> Users { get; set; }
    }
}