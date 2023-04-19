﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class DivisionDTO
    {
        [Key]
        public int Id {  get; set; }
        public string Division { get; set; }
        public ICollection<EmployeeDTO> Employee { get; set; }
    }
}
