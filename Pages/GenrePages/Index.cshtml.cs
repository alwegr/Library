using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Library.Date;
using Library.Entities;

namespace Library.Pages.GenrePages
{
    public class IndexModel : PageModel
    {
        private readonly Library.Date.ApplicationDbContext _context;

        public IndexModel(Library.Date.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Genre> Genre { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Genres != null)
            {
                Genre = await _context.Genres.ToListAsync();
            }
        }
    }
}
