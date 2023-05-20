namespace PASEDM.Models
{
    public class MoveDocument
    {
        public MoveDocument(int id, User user, Document document)
        {
            Id = id;
            User = user;
            Document = document;
        }

        public int Id { get; set; }
        public User User { get; set; }
        public Document Document { get; set; }
    }
}