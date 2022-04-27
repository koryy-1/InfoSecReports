using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InfoSecReports.Models;

namespace InfoSecReports.Pages.ObjectOfVerifications
{
    public class CreateModel : PageModel
    {
        private readonly InfoSecReportsContext _context;

        public CreateModel(InfoSecReportsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ObjectOfVerification ObjectOfVerification { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string Owner = User.Identity.Name;
            ObjectOfVerification.Owner = Owner;
            _context.ObjectOfVerification.Add(ObjectOfVerification);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

