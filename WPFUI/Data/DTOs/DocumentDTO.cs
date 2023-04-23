using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class DocumentDTO
    {
        [Key]
        public int ID {  get; set; }
        public int RegistrationNumber { get; set; }
        public string Name { get; set; }
        public string TypeDocument { get; set; }
        public DateTime DateOfFormation { get; set; }
        public ICollection<CardDTO> Cards { get; set; }
    }
}