namespace AndysManClub.Domain.DTO;

public class Person
{
    public Guid Id { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public List<PersonEvent> Volunteers { get; set; } // better name?

}