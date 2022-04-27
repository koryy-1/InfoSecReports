using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.WorkingGroups
{
    public class DetailsModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public DetailsModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        public WorkingGroup WorkingGroup { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkingGroup = await _context.WorkingGroup.FirstOrDefaultAsync(m => m.Id == id);

            if (WorkingGroup == null)
            {
                return NotFound();
            }
            return RedirectToPage("/ObjectOfVerifications/");
        }
    }
}
