using AndysManClub.Domain.AggregateRoot;
using AndysManClub.Shared.Dto;
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
    
    public class ViewAmcEventSummary : Profile
    {
        public ViewAmcEventSummary()
        {
            CreateMap<Models.AmcEvent, ViewAmcEventSummaryDto>().ReverseMap();
        }
    }
}
