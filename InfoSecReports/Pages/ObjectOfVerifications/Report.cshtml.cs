using InfoSecReports.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InfoSecReports.Pages.ObjectOfVerifications
{
    public class ReportModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public ReportModel(InfoSecReportsContext context)
        {
            _context = context;
        }
        public IList<EventOfObject> EventOfObject { get; set; }
        public IList<FlawOfObject> FlawOfObject { get; set; }
        public IList<Event> Event { get; set; }
        public IList<Flaw> Flaw { get; set; }
        public IList<Recomendation> Recomendation { get; set; }
        public IList<Category> Category { get; set; }
        [BindProperty]
        public List<string> Flaws { get; set; }
        [BindProperty]
        public List<string> Events { get; set; }
        public string NameOfCompany { get; set; }


        public async Task<IActionResult> OnGetAsync(string id)
        {
            NameOfCompany = id;
            EventOfObject = await _context.EventOfObject.ToListAsync();
            FlawOfObject = await _context.FlawOfObject.ToListAsync();

            Category = await _context.Category.ToListAsync();
            Event = await _context.Event.ToListAsync();
            Flaw = await _context.Flaw.ToListAsync();

            return Page();
        }
        public IActionResult OnPost(string id)
        {
            NameOfCompany = id;
            return RedirectToPage("/ObjectOfVerifications/Details", routeValues: new { id = NameOfCompany, eventslist = Events, flawslist = Flaws });
        }
    }

}