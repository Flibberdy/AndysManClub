using AndysManClub.Domain.AggregateRoot;
using AutoMapper;

namespace AndysManClub.Domain.Mapper
{
    public class PersonMap : Profile
    {
        public PersonMap()
        {
            CreateMap<Data.Models.Person, Person>().ReverseMap();
        }
    }
}
