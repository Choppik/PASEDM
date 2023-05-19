using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class DocStagesDTO
    {
        [Key]
        public int ID { get; set; }
        public string NameDocStage { get; set; }
        public int DocStagesValue { get; set; }
        public ICollection<DocumentDTO> Documents { get; set; }
    }
}