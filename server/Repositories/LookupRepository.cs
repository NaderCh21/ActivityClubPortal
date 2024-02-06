using System.Collections.Generic;
using System.Linq;
using ActivityClubPortal.Models;

namespace ActivityClubPortal.Repositories
{
    public class LookupRepository
    {
        private readonly activityclubportalContext _context;

        public LookupRepository(activityclubportalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Lookup> GetAllLookups()
        {
            return _context.Lookups.ToList();
        }
    }
}
