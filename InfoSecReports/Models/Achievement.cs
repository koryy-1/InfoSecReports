using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InfoSecReports.Models
{
    public class Achievement
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string NodeAdress { get; set; }
        [Required]
        public DateTime AuthData { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public string NameOfСompany { get; set; }
        [Required]
        public string Member { get; set; }
        public ObjectOfVerification ObjectOfVerification { get; set; }
    }
}
