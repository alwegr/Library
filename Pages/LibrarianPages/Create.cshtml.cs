using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.Date;
using Library.Entities;

namespace Library.Pages.LibrarianPages
{
    public class CreateModel : PageModel
    {
        private readonly Library.Date.ApplicationDbContext _context;

        public CreateModel(Library.Date.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Librarian Librarian { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if ( _context.Librarians == null || Librarian == null)
            {
                return Page();
            }

            _context.Librarians.Add(Librarian);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
