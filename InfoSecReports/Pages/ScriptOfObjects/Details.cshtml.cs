using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.ScriptOfObjects
{
    public class DetailsModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public DetailsModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        public ScriptOfObject ScriptOfObject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScriptOfObject = await _context.ScriptOfObject.FirstOrDefaultAsync(m => m.Id == id);

            if (ScriptOfObject == null)
            {
                return NotFound();
            }
            return RedirectToPage("/ObjectOfVerifications/");
        }
    }
}
