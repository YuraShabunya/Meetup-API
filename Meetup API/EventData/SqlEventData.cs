using Meetup_API.Models;

namespace Meetup_API.EventData
{
    public class SqlEventData : IEventData
    {
        private EventContext _eventContext;
        public SqlEventData(EventContext eventContext)
        {
            _eventContext = eventContext;
        }
        public Event AddEvent(Event @event)
        {
            @event.Id = Guid.NewGuid();
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

        public List<Event> GetEvents()
        {
            return _eventContext.Events.ToList();
        }
    }
}
