using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class EmployeeDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DivisionId { get; set; }
        public virtual DivisionDTO Division { get; set; }
        public ICollection<UserDTO> Users { get; set; }
    }
}