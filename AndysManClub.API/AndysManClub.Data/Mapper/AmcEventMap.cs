using AndysManClub.Domain.AggregateRoot;
using AutoMapper;

namespace AndysManClub.Data.Mapper
{
    public class AmcEventMap : Profile
    {
        public AmcEventMap()
        {
            CreateMap<Data.Models.AmcEvent, AmcEvent>().ReverseMap();
        }
    }
}
