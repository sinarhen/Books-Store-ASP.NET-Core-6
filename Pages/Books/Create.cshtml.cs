using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Books.DBContext;
using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly BooksProjectContext _context;

        public CreateModel(BooksProjectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Categories = new SelectList(await _context.Categories.ToArrayAsync(), "Id", "Name");

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        
        public SelectList Categories { get; set; }
        
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Books == null || Book == null)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
