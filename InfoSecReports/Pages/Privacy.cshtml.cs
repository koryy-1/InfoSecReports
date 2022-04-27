using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using InfoSecReports.Models;

namespace InfoSecReports.Pages
{   
    [Authorize(Roles = "Administrator")]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly InfoSecReportsContext _context;

        public PrivacyModel(ILogger<PrivacyModel> logger, InfoSecReportsContext context)
        {
            _logger = logger;
            _context = context;
        }
        

         public Event Event { get; set; }
         public Flaw Flaw { get; set; }
         public Category Category { get; set; }
         public Script Script { get; set; }
         public Achievement Achievement { get; set; }
         public Recomendation Recomendation { get; set; }
         public Member Member { get; set; }

        public int EventsCount { get; set; }
         public int FlawsCount { get; set; }
         public int CategoriesCount { get; set; }
         public int ScriptsCount { get; set; }
         public int AchievementsCount { get; set; }
         public int RecomendationsCount { get; set; }
         public int MembersCount { get; set; }

        public void OnGet()
        {
           EventsCount = _context.Event.Count();
           FlawsCount = _context.Flaw.Count();
           CategoriesCount = _context.Category.Count();
           ScriptsCount = _context.Script.Count();
           AchievementsCount = _context.Achievement.Count();
           RecomendationsCount = _context.Recomendation.Count();
           MembersCount = _context.Member.Count();
        }
    }
}
