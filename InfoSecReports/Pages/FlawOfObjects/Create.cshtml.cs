using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.FlawOfObjects
{
    public class CreateModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public CreateModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        public string NameOfCompany { get; set; }
        public IList<Flaw> Flaw { get; set; }

        public IActionResult OnGet(string id)
        {
            NameOfCompany = id;
            Flaw = _context.Flaw.ToList();
            return Page();
        }

        [BindProperty]
        public FlawOfObject FlawOfObject { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FlawOfObject.Add(FlawOfObject);
            await _context.SaveChangesAsync();

            return RedirectToPage("/ObjectOfVerifications/Index");
        }
    }
}
