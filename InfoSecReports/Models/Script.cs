using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InfoSecReports.Models
{
    public class Script
    {
        // [Required]
        // public int Id { get; set; }
        [Key]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
