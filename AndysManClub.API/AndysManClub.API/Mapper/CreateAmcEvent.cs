using AndysManClub.Domain.AggregateRoot;
using AndysManClub.Shared.Dto;
using AutoMapper;

namespace AndysManClub.Data.Mapper
{
    public class CreateAmcEvent : Profile
    {
        public CreateAmcEvent()
        {
            CreateMap<CreateAmcEventDto, AmcEvent>();
        }
    }
}
