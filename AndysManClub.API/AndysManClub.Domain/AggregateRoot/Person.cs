namespace AndysManClub.Domain.AggregateRoot;

public class Person
{
    public Guid Id { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}