namespace PASEDM.Models
{
    public class Division
    {
        public Division() { }

        public Division(int id, int numberDivision, string nameDivision)
        {
            Id = id;
            NumberDivision = numberDivision;
            NameDivision = nameDivision;
        }

        public int Id { get; set; }
        public int NumberDivision { get; set; }
        public string NameDivision { get; set; }
    }
}