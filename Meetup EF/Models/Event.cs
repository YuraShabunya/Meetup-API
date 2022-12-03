using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Meetup_EF.Models
{
    public class Event
    {

        [Key]
        public Guid Id { get; set; }
        public int Number { get; set; }
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
