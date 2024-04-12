using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AndysManClub.Data.Models;

[Table(nameof(Person))]
public class Person : IdentityUser
{
    [ProtectedPersonalData]
    public required string FirstName { get; set; }
    [ProtectedPersonalData]
    public required string LastName { get; set; }
}