namespace AndysManClub.Data.Models
{
    public class AmcEvent
    {
        public AmcEvent()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid OrganiserId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Location { get; set; }
        public DateTime? EventDateTime { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Person> Volunteers { get; set; }
    }
}
