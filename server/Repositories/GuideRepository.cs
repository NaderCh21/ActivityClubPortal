using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ActivityClubPortal.Models;

namespace ActivityClubPortal.Repositories
{
    public class GuideRepository
    {
        private readonly activityclubportalContext _context;

        public GuideRepository(activityclubportalContext context)
        {
            _context = context;
        }

        public List<Guide> GetAllGuides()
        {
            return _context.Guides.ToList();
        }

        public Guide GetGuideById(int guideId)
        {
            return _context.Guides.Find(guideId);
        }

        public void AddGuide(Guide guide)
        {
            _context.Guides.Add(guide);
            _context.SaveChanges();
        }

        public void UpdateGuide(Guide guide)
        {
            _context.Entry(guide).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteGuide(int guideId)
        {
            var guide = _context.Guides.Find(guideId);
            if (guide != null)
            {
                _context.Guides.Remove(guide);
                _context.SaveChanges();
            }
        }
    }
}
