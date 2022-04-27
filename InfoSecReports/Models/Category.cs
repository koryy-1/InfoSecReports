using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoSecReports.Models
{
    public class Category
    {
        [Required]
        [Key]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
        public ICollection<Event> Event { get; set; }
        public ICollection<Flaw> Flaw { get; set; }
        public ICollection<Recomendation> Recomendation { get; set; }
    }
}
