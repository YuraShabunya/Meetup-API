using System.ComponentModel.DataAnnotations;

namespace Meetup_API.Models
{
    public class Event
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Speker { get; set; }
        [Required] 
        public string DataAndPlase { get; set; }
    }
}
