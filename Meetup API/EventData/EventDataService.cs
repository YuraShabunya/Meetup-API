using Meetup_API.EventData.Interfaces;
using Meetup_EF.Models;

namespace Meetup_API.EventData
{
    public class EventDataService : IEventData
    {
        private EventContext _eventContext;
        public EventDataService(EventContext eventContext)
        {
            _eventContext = eventContext;
        }
        public Event AddEvent(Event @event)
        {
            @event.Id = Guid.NewGuid();
            @event.Number = _eventContext.Events.Count() + 1;
            _eventContext.Events.Add(@event);
            _eventContext.SaveChanges();
            return @event;
        }

        public void DeleteEvent(Event @event)
        {
            _eventContext.Events.Remove(@event);
            _eventContext.SaveChanges();
        }

        public Event EditEvent(Event @event)
        {
            var existingEvent = GetEvent(@event.Id);
            if(existingEvent != null)
            {
                existingEvent.Title = @event.Title;
                existingEvent.Description = @event.Description;
                existingEvent.Speker = @event.Speker;
                existingEvent.DataAndPlase = @event.DataAndPlase;
                _eventContext.Events.Update(existingEvent);
                _eventContext.SaveChanges();
            }

            return @event;

        }

        public Event GetEvent(Guid id)
        {
            var @event = _eventContext.Events.Find(id);
            return @event;
        }

        public List<Event> GetAllEvents()
        {
            return _eventContext.Events.ToList();
        }
    }
}
