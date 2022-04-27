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
    public class IndexModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public IndexModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        public IList<WorkingGroup> WorkingGroup { get;set; }

        public async Task OnGetAsync()
        {
            WorkingGroup = await _context.WorkingGroup.ToListAsync();
        }
    }
}
