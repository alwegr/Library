using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Library.Date;
using Library.Entities;

namespace Library.Pages.LibrarianPages
{
    public class DetailsModel : PageModel
    {
        private readonly Library.Date.ApplicationDbContext _context;

        public DetailsModel(Library.Date.ApplicationDbContext context)
        {
            _context = context;
        }

      public Librarian Librarian { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Librarians == null)
            {
                return NotFound();
            }

            var librarian = await _context.Librarians.FirstOrDefaultAsync(m => m.Id == id);
            if (librarian == null)
            {
                return NotFound();
            }
            else 
            {
                Librarian = librarian;
            }
            return Page();
        }
    }
}
