using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.Flaws
{
    public class CreateModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public CreateModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; }
        public IList<Recomendation> Recomendation { get; set; }

        public IActionResult OnGet()
        {
            Category = _context.Category.ToList();
            Recomendation = _context.Recomendation.ToList();
            return Page();
        }

        [BindProperty]
        public Flaw Flaw { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Flaw.Add(Flaw);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
