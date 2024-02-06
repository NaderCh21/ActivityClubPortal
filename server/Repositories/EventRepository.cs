using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ActivityClubPortal.Models;

namespace ActivityClubPortal.Repositories
{
    public class EventRepository
    {
        private readonly activityclubportalContext _context;

        public EventRepository(activityclubportalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Get all events
        public IEnumerable<Event> GetAllEvents()
        {
            return _context.Events.ToList();
        }

        // Get event by ID
        public Event GetEventById(int eventId)
        {
            return _context.Events.FirstOrDefault(e => e.EventId == eventId);
        }

        // Add a new event
        public void AddEvent(Event newEvent)
        {
            if (newEvent == null)
            {
                throw new ArgumentNullException(nameof(newEvent));
            }

            _context.Events.Add(newEvent);
            _context.SaveChanges();
        }

        // Update an existing event
        public void UpdateEvent(Event updatedEvent)
        {
            if (updatedEvent == null)
            {
                throw new ArgumentNullException(nameof(updatedEvent));
            }

            _context.Entry(updatedEvent).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Delete an event
        public void DeleteEvent(int eventId)
        {
            var eventToDelete = _context.Events.Find(eventId);

            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                _context.SaveChanges();
            }
        }
    }
}
