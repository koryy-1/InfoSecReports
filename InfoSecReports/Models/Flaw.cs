using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InfoSecReports.Models
{
    public class Flaw
    {
        [Required]
        [Key]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [Range(0, 11)]
        public int ImportanceFactor { get; set; }
        [Required]
        public string RecomindationID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public Category Category { get; set; }
    }
}
