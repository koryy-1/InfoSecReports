using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InfoSecReports.Models
{
    public class FlawOfObject
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NameOfCompany { get; set; }
        [Required]
        public string NameOfFlaw { get; set; }
        public ObjectOfVerification ObjectOfVerification { get; set; }
    }
}
