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
    public class IndexModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public IndexModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        public IList<ScriptOfObject> ScriptOfObject { get;set; }

        public async Task OnGetAsync()
        {
            ScriptOfObject = await _context.ScriptOfObject.ToListAsync();
        }
    }
}
