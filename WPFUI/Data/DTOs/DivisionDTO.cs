using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class DivisionDTO
    {
        [Key]
        public int ID {  get; set; }
        public int NumberDivision {  get; set; }
        public string Division { get; set; }
        public ICollection<EmployeeDTO> Employee { get; set; }
    }
}