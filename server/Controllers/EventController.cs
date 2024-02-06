using Microsoft.AspNetCore.Mvc;
using ActivityClubPortal.Models;
using ActivityClubPortal.Repositories;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly EventRepository _eventRepository;

    public EventController(EventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Event>> GetAllEvents()
    {
        var events = _eventRepository.GetAllEvents();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public ActionResult<Event> GetEventById(int id)
    {
        var ev = _eventRepository.GetEventById(id);

        if (ev == null)
        {
            return NotFound();
        }

        return Ok(ev);
    }

    [HttpPost]
    public ActionResult<Event> CreateEvent([FromBody] Event newEvent)
    {
        if (newEvent == null)
        {
            return BadRequest("Invalid event data");
        }

        _eventRepository.AddEvent(newEvent);

        return CreatedAtAction(nameof(GetEventById), new { id = newEvent.EventId }, newEvent);
    }

    [HttpPut("{id}")]
    public ActionResult<Event> UpdateEvent(int id, [FromBody] Event updatedEvent)
    {
        var existingEvent = _eventRepository.GetEventById(id);

        if (existingEvent == null)
        {
            return NotFound();
        }

        existingEvent.Name = updatedEvent.Name;
        existingEvent.Description = updatedEvent.Description;
        existingEvent.CategoryId = updatedEvent.CategoryId;
        existingEvent.Destination = updatedEvent.Destination;
        existingEvent.DateFrom = updatedEvent.DateFrom;
        existingEvent.DateTo = updatedEvent.DateTo;
        existingEvent.Cost = updatedEvent.Cost;
        existingEvent.Status = updatedEvent.Status;
        existingEvent.GuideId = updatedEvent.GuideId;

        _eventRepository.UpdateEvent(existingEvent);

        return Ok(existingEvent);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteEvent(int id)
    {
        var existingEvent = _eventRepository.GetEventById(id);

        if (existingEvent == null)
        {
            return NotFound();
        }

        _eventRepository.DeleteEvent(id);

        return NoContent();
    }
}
