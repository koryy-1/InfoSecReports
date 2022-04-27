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
    public class IndexModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public IndexModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        public IList<Recomendation> Recomendation { get;set; }

        public async Task OnGetAsync()
        {
            Recomendation = await _context.Recomendation.ToListAsync();
        }
    }
}
