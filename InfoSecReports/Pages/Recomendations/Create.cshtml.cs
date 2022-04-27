using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InfoSecReports.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoSecReports.Pages.Recomendations
{
    public class CreateModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public CreateModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; }
        public IActionResult OnGet()
        {
            Category = _context.Category.ToList();
            return Page();
        }

        [BindProperty]
        public Recomendation Recomendation { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD 
        
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Category = await _context.Category.ToListAsync();
            _context.Recomendation.Add(Recomendation);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}
