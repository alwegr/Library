using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.Date;
using Library.Entities;

namespace Library.Pages.CardPages
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
        ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name");
        ViewData["LibrarianId"] = new SelectList(_context.Librarians, "Id", "LastName");
        ViewData["ReaderId"] = new SelectList(_context.Readers, "Id", "LastName");
            return Page();
        }

        [BindProperty]
        public Card Card { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if ( _context.Card == null || Card == null)
            {
                return Page();
            }

            _context.Card.Add(Card);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
