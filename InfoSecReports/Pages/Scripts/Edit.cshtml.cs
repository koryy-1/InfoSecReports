using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.Scripts
{
    public class EditModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public EditModel(InfoSecReportsContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Script).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScriptExists(Script.Name))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ScriptExists(string Name)
        {
            return _context.Script.Any(e => e.Name == Name);
        }
    }
}
