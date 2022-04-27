using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.FlawOfObjects
{
    public class DetailsModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public DetailsModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        public FlawOfObject FlawOfObject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FlawOfObject = await _context.FlawOfObject.FirstOrDefaultAsync(m => m.Id == id);

            if (FlawOfObject == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
