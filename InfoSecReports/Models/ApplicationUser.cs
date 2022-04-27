using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoSecReports.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}