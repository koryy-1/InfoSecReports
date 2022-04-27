using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InfoSecReports.Models
{
    public class WorkingGroup
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NameOfСompany { get; set; }
        [Required]
        public string Member { get; set; }
        public ObjectOfVerification ObjectOfVerification { get; set; }
    }
}
