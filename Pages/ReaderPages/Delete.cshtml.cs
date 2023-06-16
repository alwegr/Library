using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Library.Date;
using Library.Entities;

namespace Library.Pages.ReaderPages
{
    public class DeleteModel : PageModel
    {
        private readonly Library.Date.ApplicationDbContext _context;

        public DeleteModel(Library.Date.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Reader Reader { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Readers == null)
            {
                return NotFound();
            }

            var reader = await _context.Readers.FirstOrDefaultAsync(m => m.Id == id);

            if (reader == null)
            {
                return NotFound();
            }
            else 
            {
                Reader = reader;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Readers == null)
            {
                return NotFound();
            }
            var reader = await _context.Readers.FindAsync(id);

            if (reader != null)
            {
                Reader = reader;
                _context.Readers.Remove(Reader);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
