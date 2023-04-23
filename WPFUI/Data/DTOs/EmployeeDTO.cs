using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class EmployeeDTO
    {
        [Key]
        public int ID { get; set; }
        public int NumberEmployee { get; set; }
        public string Name { get; set; }
        public int? DivisionID { get; set; }
        public virtual DivisionDTO Division { get; set; }
        public ICollection<UserDTO> Users { get; set; }
        public ICollection<CardDTO> Cards { get; set; }
    }
}