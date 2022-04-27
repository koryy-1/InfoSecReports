using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.Scripts
{
    public class DeleteModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public DeleteModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Script Script { get; set; }

        public async Task<IActionResult> OnGetAsync(string Name)
        {
            if (Name == null)
            {
                return NotFound();
            }

            Script = await _context.Script.FirstOrDefaultAsync(m => m.Name == Name);

            if (Script == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string Name)
        {
            if (Name == null)
            {
                return NotFound();
            }

            Script = await _context.Script.FindAsync(Name);

            if (Script != null)
            {
                _context.Script.Remove(Script);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
