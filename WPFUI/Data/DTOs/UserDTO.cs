using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class UserDTO
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int? RoleID { get; set; }
        public RoleDTO Role { get; set; }
        public int? EmployeeID { get; set; }
        public EmployeeDTO Employee { get; set; }
        public ICollection<CardDTO> Cards { get; set; }
    }
}