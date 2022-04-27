using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.Flaws
{
    public class IndexModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public IndexModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        public IList<Flaw> Flaw { get;set; }

        public async Task OnGetAsync()
        {
            Flaw = await _context.Flaw.ToListAsync();
        }
    }
}
