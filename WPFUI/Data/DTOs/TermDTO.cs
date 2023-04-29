using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class TermDTO
    {
        [Key]
        public int ID { get; set; }
        public string NameTerm { get; set; }
        public string Term { get; set; }
        public ICollection<DocumentDTO> Documents { get; set; }
    }
}