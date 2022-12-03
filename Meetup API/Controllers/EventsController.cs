using Microsoft.AspNetCore.Mvc;
using Meetup_EF.Models;
using Meetup_API.EventData.Interfaces;

namespace Meetup_API.Controllers
{
    [ApiController]
    public class EventsController : ControllerBase
    {
        private IEventData _eventData;
        public EventsController(IEventData evenData)
        {
            _eventData = evenData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllEvents()
        {
            return Ok(_eventData.GetAllEvents());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEvent(Guid id)
        {
            var @event = _eventData.GetEvent(id);

            return @event == null ? NotFound($"Event with Id: {id} was not found") : Ok(@event);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetEvent(Event @event)
        {
            _eventData.AddEvent(@event);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + @event.Id,
                @event);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEvent(Guid id)
        {
            var @event = _eventData.GetEvent(id);
            if (@event != null)
            {
                _eventData.DeleteEvent(@event);
                return Ok(@event);
            }
            return NotFound($"Event with Id: {id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEvent(Guid id, Event @event)
        {
            var existingEvent = _eventData.GetEvent(id);
            if (existingEvent != null)
            {
                @event.Id = existingEvent.Id;
                _eventData.EditEvent(@event);

            }
            return Ok(@event);
        }
    }
}
