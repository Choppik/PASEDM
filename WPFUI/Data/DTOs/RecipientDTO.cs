using System;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class RecipientDTO
    {
        [Key]
        public int Id {  get; set; }
        public int NumberRecipient { get; set; }
        public string GenericTask { get; set; }
        public DateTime TermOfExecution { get; set; }
    }
}
