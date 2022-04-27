using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InfoSecReports.Models
{
    public class Recomendation
    {
        // [Required]
        // public int Id { get; set; }
        [Key]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1, 2)]
        public int Level { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public Category Category { get; set; }
    }
}
