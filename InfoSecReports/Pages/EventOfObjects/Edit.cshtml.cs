using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.EventOfObjects
{
    public class EditModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public EditModel(InfoSecReportsContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EventOfObject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventOfObjectExists(EventOfObject.Id))
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

        private bool EventOfObjectExists(int id)
        {
            return _context.EventOfObject.Any(e => e.Id == id);
        }
    }
}
