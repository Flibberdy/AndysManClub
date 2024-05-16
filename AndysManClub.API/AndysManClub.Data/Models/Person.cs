namespace AndysManClub.Data.Models
{
    public class Person
    {
        public Guid Id { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public virtual ICollection<AmcEvent> Events { get; set; }
    }
}
