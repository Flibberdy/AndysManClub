namespace AndysManClub.Domain.AggregateRoot;

public class AmcEvent
{

    public AmcEvent()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get;}
    public Guid OrganiserId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string Location { get; set; }
    public DateTime? EventDateTime { get; set; }
    public bool IsActive { get; set; }
    public List<Person> Volunteers { get; set; }


    public void RegisterPerson(Person person)
    {
        Volunteers.Add(person);
    }
}
