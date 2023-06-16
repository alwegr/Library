using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Library.Date;
using Library.Entities;

namespace Library.Pages.CardPages
{
    public class IndexModel : PageModel
    {
        private readonly Library.Date.ApplicationDbContext _context;

        public IndexModel(Library.Date.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Card> Card { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Card != null)
            {
                Card = await _context.Card
                .Include(c => c.Books)
                .Include(c => c.Librarians)
                .Include(c => c.Readers).ToListAsync();
            }
        }
    }
}
