using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class SecrecyStampDTO
    {
        [Key]
        public int ID { get; set; }
        public string SecrecyStamp { get; set; }
        public int SecrecyStampValue { get; set; }
        public ICollection<DocumentDTO> Documents { get; set; }
    }
}