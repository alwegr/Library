using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Date;
using Library.Entities;

namespace Library.Pages.CardPages
{
    public class EditModel : PageModel
    {
        private readonly Library.Date.ApplicationDbContext _context;

        public EditModel(Library.Date.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Card Card { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Card == null)
            {
                return NotFound();
            }

            var card =  await _context.Card.FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            Card = card;
           ViewData["BookId"] = new SelectList(_context.Books, "Id", "Author");
           ViewData["LibrarianId"] = new SelectList(_context.Librarians, "Id", "FirstName");
           ViewData["ReaderId"] = new SelectList(_context.Readers, "Id", "FirstName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(Card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(Card.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CardExists(int id)
        {
          return (_context.Card?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
