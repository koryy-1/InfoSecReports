using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.ObjectOfVerifications
{
    public class DeleteModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public DeleteModel(InfoSecReportsContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ObjectOfVerification = await _context.ObjectOfVerification.FindAsync(id);

            if (ObjectOfVerification != null)
            {
                _context.ObjectOfVerification.Remove(ObjectOfVerification);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
