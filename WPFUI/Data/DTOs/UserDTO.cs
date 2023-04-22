using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class UserDTO
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? EmployeeID { get; set; }
        public EmployeeDTO Employee { get; set; }
    }
}