using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EventApp.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Speaker { get; set; }
        [Required]
        public string Place { get; set; }
        [DisplayName("Date")]
        public DateTime CreatedDate { get; set; }
    }
}
