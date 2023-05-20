namespace PASEDM.Models
{
    public class AccessRights
    {
        public AccessRights(int id, string nameAccessRight, int accessRightsValue)
        {
            Id = id;
            NameAccessRight = nameAccessRight;
            AccessRightsValue = accessRightsValue;
        }

        public int Id { get; }
        public string NameAccessRight { get; }
        public int AccessRightsValue { get; }
    }
}