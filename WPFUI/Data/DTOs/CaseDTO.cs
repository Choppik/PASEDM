using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class CaseDTO
    {
        [Key]
        public int ID { get; set; }
        public int NumberCase { get; set; }
        public string Desription { get; set; }
        public ICollection<CardDTO> Cards { get; set; }
    }
}