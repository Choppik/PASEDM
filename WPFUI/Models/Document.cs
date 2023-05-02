using System;

namespace PASEDM.Models
{
    public class Document
    {
        public int Id { get; }
        public string NameDoc { get; }
        public int RegistrationNumber { get; }
        public DateTime DateCreateDoc { get; }
        public string Summary { get; }
        public string ConditionDoc { get; }
        public string SecrecyStamp { get; }
        public string Path { get; }
        public int? TermID { get; }
    }
}