using System;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class DocumentDTO
    {
        [Key]
        public int ID { get; set; }
        public string NameDoc { get; set; }
        public int RegistrationNumber { get; set; }
        public DateTime DateCreateDoc { get; set; }
        public string ConditionDoc { get; set; }
        public string Path { get; set; }
    }
}