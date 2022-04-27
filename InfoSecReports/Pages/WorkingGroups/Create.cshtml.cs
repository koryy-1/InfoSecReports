using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InfoSecReports.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoSecReports.Pages.WorkingGroups
{
    public class CreateModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public CreateModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        public string NameOfCompany { get; set; }
        public IList<Member> Member { get; set; }

        public IActionResult OnGet(string id)
        {
            Member = _context.Member.ToList();
            NameOfCompany = id;
            return Page();
        }

        [BindProperty]
        public WorkingGroup WorkingGroup { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Member = await _context.Member.ToListAsync();
            _context.WorkingGroup.Add(WorkingGroup);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}
