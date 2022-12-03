using Meetup_EF.Models;

namespace Meetup_API.EventData.Interfaces
{
    public interface IGetAll
    {
        public List<Event> Get();
        public int GetCount();
    }
}
