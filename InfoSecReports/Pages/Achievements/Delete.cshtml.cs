using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.Achievements
{
    public class DeleteModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public DeleteModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Achievement Achievement { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Achievement = await _context.Achievement.FirstOrDefaultAsync(m => m.Id == id);

            if (Achievement == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Achievement = await _context.Achievement.FindAsync(id);

            if (Achievement != null)
            {
                _context.Achievement.Remove(Achievement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
