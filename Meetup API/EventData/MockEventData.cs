using Meetup_API.Models;

namespace Meetup_API.EventData
{
    public class MockEventData : IEventData
    {
        private List<Event> _events = new List<Event>()
        {
            new Event()
            {
                Id = Guid.NewGuid(),
                Title = "Run",
                Description = "People run 3 km",
                Speker = "Non",
                DataAndPlase = "SportStation"
            },
            new Event()
            {
                Id= Guid.NewGuid(),
                Title = "Motivation",
                Description = "Speaker will tolk about motivation.",
                Speker = "Lead of Bank",
                DataAndPlase = "Office"
            }
        };
        public Event AddEvent(Event @event)
        {
            @event.Id = Guid.NewGuid();
            _events.Add(@event);
            return @event;
        }

        public void DeleteEvent(Event @event)
        {
            _events.Remove(@event);
        }

        public Event EditEvent(Event @event)
        {
            var existingEvent = GetEvent(@event.Id);
            existingEvent.Title = @event.Title;
            existingEvent.Description = @event.Description;
            existingEvent.Speker = @event.Speker;
            existingEvent.DataAndPlase = @event.DataAndPlase;
            return existingEvent;
        }

        public Event GetEvent(Guid id)
        {
            return _events.SingleOrDefault(e => e.Id == id);
        }

        public List<Event> GetEvents()
        {
            return _events;
        }
    }
}
