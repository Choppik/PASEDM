using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class MoveDocumentDTO
    {
        [Key]
        public int ID { get; set; }
        public int? UserID { get; set; }
        public UserDTO User { get; set; }
        public int? DocumentID { get; set; }
        public DocumentDTO Document { get; set; }
    }
}
