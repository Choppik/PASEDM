using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class DocumentTypesDTO
    {
        [Key]
        public int ID {  get; set; }
        public string Name { get; set; }
        public ICollection<DocumentDTO> Documents { get; set; }
    }
}