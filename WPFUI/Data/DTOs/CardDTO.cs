using System;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class CardDTO
    {
        [Key]
        public int ID {  get; set; }
        public int NumberCard { get; set; }
        public int NameCard { get; set; }
        public DateTime DateOfFormation { get; set; }
        public string Comment { get; set; }
        public int? DocumentID { get; set; }
        public DocumentDTO Document { get; set; }
        public int? DocumentTypesID { get; set; }
        public DocumentTypesDTO DocumentTypes { get; set; }
        public int? CaseID { get; set; }
        public CaseDTO Case { get; set; }
        public int? UserID { get; set; }
        public UserDTO User { get; set; }
        public int? EmployeeID { get; set; }
        public EmployeeDTO Employee { get; set; }
        public int? RecipientID { get; set; }
        public RecipientDTO Recipient { get; set; }
    }
}