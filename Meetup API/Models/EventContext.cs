using Microsoft.EntityFrameworkCore;

namespace Meetup_API.Models
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
    }
}
