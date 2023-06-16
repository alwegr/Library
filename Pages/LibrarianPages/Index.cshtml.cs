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
    public class IndexModel : PageModel
    {
        private readonly Library.Date.ApplicationDbContext _context;

        public IndexModel(Library.Date.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Librarian> Librarian { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Librarians != null)
            {
                Librarian = await _context.Librarians.ToListAsync();
            }
        }
    }
}
