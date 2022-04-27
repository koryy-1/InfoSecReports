using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.EventOfObjects
{
    public class CreateModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public CreateModel(InfoSecReportsContext context)
        {
            _context = context;
        }
        public string NameOfCompany { get; set; }
        public IList<Event> Event { get; set; }
        public IList<Category> Category { get; set; }
        public List<string> Events { get; set; }


        public IActionResult OnGet(string id)
        {
            NameOfCompany = id;
            Category = _context.Category.ToList();
            Event = _context.Event.ToList();
            return Page();
        }

        [BindProperty]
        public EventOfObject EventOfObject { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EventOfObject.Add(EventOfObject);
            await _context.SaveChangesAsync();

            return RedirectToPage("/ObjectOfVerifications/Index");
        }
    }
}
