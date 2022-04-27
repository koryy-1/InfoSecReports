using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.ObjectOfVerifications
{
    public class EditModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public EditModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ObjectOfVerification ObjectOfVerification { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ObjectOfVerification = await _context.ObjectOfVerification.FirstOrDefaultAsync(m => m.Name == id);

            if (ObjectOfVerification == null)
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

            string Owner = User.Identity.Name;
            ObjectOfVerification.Owner = Owner;
            _context.Attach(ObjectOfVerification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectOfVerificationExists(ObjectOfVerification.Name))
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

        private bool ObjectOfVerificationExists(string id)
        {
            return _context.ObjectOfVerification.Any(e => e.Name == id);
        }
    }
}
