using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InfoSecReports.Models
{
    public class Member
    {
        [Required]
        [Key]
        public string Name { get; set; }

    }
}
