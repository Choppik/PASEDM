using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class SenderDTO
    {
        [Key]
        public int ID { get; set; }
        public int? RecipientID { get; set; }
        public RecipientDTO Recipient { get; set; }
    }
}