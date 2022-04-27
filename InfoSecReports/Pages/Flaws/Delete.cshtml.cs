using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.Flaws
{
    public class DeleteModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public DeleteModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Flaw Flaw { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flaw = await _context.Flaw.FirstOrDefaultAsync(m => m.Name == id);

            if (Flaw == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flaw = await _context.Flaw.FindAsync(id);

            if (Flaw != null)
            {
                _context.Flaw.Remove(Flaw);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
