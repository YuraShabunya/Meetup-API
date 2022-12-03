using Meetup_EF.Models;

namespace Meetup_API.EventData.Interfaces
{
    public interface IEventData
    {
        public List<Event> GetAllEvents();
        public Event GetEvent(Guid id);
        public Event AddEvent(Event @event);
        public void DeleteEvent(Event @event);
        public Event EditEvent(Event @event);
    }
}
