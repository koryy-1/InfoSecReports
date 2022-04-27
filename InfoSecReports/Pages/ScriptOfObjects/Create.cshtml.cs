using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InfoSecReports.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoSecReports.Pages.ScriptOfObjects
{
    public class CreateModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public CreateModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        public string NameOfCompany { get; set; }
        public IList<Script> Script { get; set; }


        public IActionResult OnGet(string id)
        {
            NameOfCompany = id;
            Script = _context.Script.ToList();
            return Page();
        }

        [BindProperty]
        public ScriptOfObject ScriptOfObject { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Script = await _context.Script.ToListAsync();
            _context.ScriptOfObject.Add(ScriptOfObject);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}
