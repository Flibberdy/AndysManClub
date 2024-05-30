using AndysManClub.Domain.Repositories;
using AndysManClub.Shared.Dto;
using AutoMapper;
using AmcEvent = AndysManClub.Domain.AggregateRoot.AmcEvent;

namespace AndysManClub.Data.Repositories
{
    public class AmcEventRepository : IAmcEventRepository
    {
        private AMCContext _context;
        private readonly IMapper _mapper;

        public AmcEventRepository(AMCContext amcContext, IMapper mapper)
        {
            _context = amcContext ?? throw new ArgumentNullException(nameof(amcContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public List<ViewAmcEventSummaryDto> Get()
        {
            var events = _context.Events.Where(x => x.IsActive);
            return _mapper.Map<List<Models.AmcEvent>, List<ViewAmcEventSummaryDto>>(events.ToList());
        }

        public AmcEvent? Get(Guid id)
        {
            var amcEvent = _context.Events.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<Models.AmcEvent, AmcEvent>(amcEvent);
        }

        public void Create(AmcEvent amcEvent)
        {
            var dataAmcEvent = _mapper.Map<AmcEvent, Models.AmcEvent>(amcEvent);
            _context.Events.Add(dataAmcEvent);
        }

        // Quite a common method - maybe should be in a base repo?
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
