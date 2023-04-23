using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class RecipientDTO
    {
        [Key]
        public int ID {  get; set; }
        public int NumberRecipient { get; set; }
        public string GenericTask { get; set; }
        public DateTime TermOfExecution { get; set; }
        public int? UserID { get; set; }
        public UserDTO User { get; set; }
        public ICollection<CardDTO> Cards { get; set; }
    }
}