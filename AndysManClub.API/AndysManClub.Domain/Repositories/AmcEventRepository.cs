﻿using AndysManClub.Data;
using AndysManClub.Data.Models;
using AndysManClub.Data.Repositories;

namespace AndysManClub.Domain.Repositories
{
    public class AmcEventRepository : IAmcEventRepository
    {
        private AMCContext _context;

        public AmcEventRepository(AMCContext amcContext)
        {
            _context = amcContext ?? throw new ArgumentNullException(nameof(amcContext));
        }

        public IEnumerable<AmcEvent> Get()
        {
            return _context.Events.Where(x => x.IsActive);
        }

        public AmcEvent Get(Guid id)
        {
            return _context.Events.SingleOrDefault(x => x.Id == id);
        }

        public void Create(AmcEvent amcEvent)
        {
            _context.Events.Add(amcEvent);
        }

        // Quite a common method - maybe should be in a base repo?
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
