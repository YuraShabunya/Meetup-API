using Meetup_API.EventData.Interfaces;
using Meetup_EF.Models;

namespace Meetup_API.EventData
{
    public class GetListFromToService : IGetListFromTo
    {
        private EventContext _eventContext;
        public GetListFromToService(EventContext eventContext)
        {
            _eventContext = eventContext;
        }

        public List<Event> Get(int n1, int n2)
        {
            if (n1 > n2)
                (n1, n2) = (n2, n1);

            List<Event> newEvents = new List<Event>();
            foreach (Event e in _eventContext.Events)
            {
                if (e.Number >= n1 && e.Number <= n2)
                {
                    newEvents.Add(e);
                }
            }

            return newEvents;
        }

        public List<Event> Skip(int n1, int n2)
        {
            if (n1 > n2)
                (n1, n2) = (n2, n1);

            List<Event> newEvents = new List<Event>();
            foreach (Event e in _eventContext.Events)
            {
                if (e.Number < n1 || e.Number > n2)
                {
                    newEvents.Add(e);
                }
            }

            return newEvents;
        }
    }
}
