using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.EventOfObjects
{
    public class DeleteModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public DeleteModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EventOfObject EventOfObject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EventOfObject = await _context.EventOfObject.FirstOrDefaultAsync(m => m.Id == id);

            if (EventOfObject == null)
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

            EventOfObject = await _context.EventOfObject.FindAsync(id);

            if (EventOfObject != null)
            {
                _context.EventOfObject.Remove(EventOfObject);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
