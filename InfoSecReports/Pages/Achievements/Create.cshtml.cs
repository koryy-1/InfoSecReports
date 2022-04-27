using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.Achievements
{
    public class CreateModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public CreateModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get; set; }
        public string NameOfCompany { get; set; }

        public IActionResult OnGet(string id)
        {
            Member = _context.Member.ToList();
            NameOfCompany = id;
            return Page();
        }

        [BindProperty]
        public Achievement Achievement { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Member = _context.Member.ToList();
            NameOfCompany = id;
            _context.Achievement.Add(Achievement);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}
