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
    public class DetailsModel : PageModel
    {
        private readonly Library.Date.ApplicationDbContext _context;

        public DetailsModel(Library.Date.ApplicationDbContext context)
        {
            _context = context;
        }

      public Card Card { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Card == null)
            {
                return NotFound();
            }

            var card = await _context.Card.FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            else 
            {
                Card = card;
            }
            return Page();
        }
    }
}
