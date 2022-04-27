using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.Recomendations
{
    public class DetailsModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public DetailsModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        public Recomendation Recomendation { get; set; }

        public async Task<IActionResult> OnGetAsync(string Name)
        {
            if (Name == null)
            {
                return NotFound();
            }

            Recomendation = await _context.Recomendation.FirstOrDefaultAsync(m => m.Name == Name);

            if (Recomendation == null)
            {
                return NotFound();
            }
            return RedirectToPage("/ObjectOfVerifications/");
        }
    }
}
