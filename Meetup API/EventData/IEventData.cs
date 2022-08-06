using Meetup_API.Models;

namespace Meetup_API.EventData
{
    public interface IEventData
    {
        List<Event> GetEvents();
        Event GetEvent(Guid id);
        Event AddEvent(Event @event);
        void DeleteEvent(Event @event);
        Event EditEvent(Event @event);
    }
}
