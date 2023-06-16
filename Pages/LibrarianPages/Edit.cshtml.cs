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

namespace Library.Pages.LibrarianPages
{
    public class EditModel : PageModel
    {
        private readonly Library.Date.ApplicationDbContext _context;

        public EditModel(Library.Date.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Librarian Librarian { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Librarians == null)
            {
                return NotFound();
            }

            var librarian =  await _context.Librarians.FirstOrDefaultAsync(m => m.Id == id);
            if (librarian == null)
            {
                return NotFound();
            }
            Librarian = librarian;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(Librarian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibrarianExists(Librarian.Id))
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

        private bool LibrarianExists(int id)
        {
          return (_context.Librarians?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
