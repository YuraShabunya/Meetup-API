using Microsoft.EntityFrameworkCore;

namespace Meetup_EF.Models
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        { 
            Database.EnsureCreated();
        }

        public DbSet<Event> Events { get; set; }
    }
}
