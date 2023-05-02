using System;

namespace PASEDM.Models
{
    public class Card
    {
        public int Id { get; }
        public int NumberCard { get; }
        public int NameCard { get; }
        public DateTime DateOfFormation { get; }
        public string Comment { get; }
        public int? DocumentID { get; }
        public int? DocumentTypesID { get; }
        public int? CaseID { get; }
        public int? UserID { get; }
        public int? EmployeeID { get; }
        public int? RecipientID { get; }
    }
}