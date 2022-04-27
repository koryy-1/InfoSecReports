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
    
    public class IndexModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public IndexModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        public IList<ObjectOfVerification> ObjectOfVerification { get;set; }

        public async Task OnGetAsync()
        {
            ObjectOfVerification = await _context.ObjectOfVerification.Where(m => m.Owner == User.Identity.Name).ToListAsync();
        }
    }
}
