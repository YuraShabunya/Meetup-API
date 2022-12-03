using Meetup_API.EventData.Interfaces;
using Meetup_EF.Models;

namespace Meetup_API.EventData
{
    public class GetAllService : IGetAll
    {
        private EventContext _eventContext;
        public GetAllService(EventContext eventContext)
        {
            _eventContext = eventContext;
        }

        public List<Event> Get()
        {
            return _eventContext.Events.ToList();
        }

        public int GetCount()
        {
            return _eventContext.Events.Count();
        }
    }
}
