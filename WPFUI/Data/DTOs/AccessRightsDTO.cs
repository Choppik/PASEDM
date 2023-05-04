using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class AccessRightsDTO
    {
        [Key]
        public int ID { get; set; }
        public string AccessRights { get; set; }
        public int AccessRightsValue { get; set; }
        public ICollection<EmployeeDTO> Staff { get; set; }
    }
}