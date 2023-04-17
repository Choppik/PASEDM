using PASEDM.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PASEDM.Data.DTOs
{
    public class UserDTO
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? EmployeeID { get; set; }
        public virtual EmployeeDTO Employee { get; set; }
    }
}
