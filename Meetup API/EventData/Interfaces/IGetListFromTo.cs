using Meetup_EF.Models;

namespace Meetup_API.EventData.Interfaces
{
    public interface IGetListFromTo
    {
        public List<Event> Get(int n1, int n2);
        public List<Event> Skip(int n1, int n2);

    }
}
