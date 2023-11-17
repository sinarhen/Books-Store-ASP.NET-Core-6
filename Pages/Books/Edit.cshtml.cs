
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Books.DBContext;
using Books.Models;

namespace Books.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly BooksProjectContext _context;

        public EditModel(BooksProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        public SelectList Categories { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }
            var categories = await _context.Categories.ToArrayAsync();
            var book = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);
            
            if (book == null)
            {
                return NotFound();
            }
            Book = book;
            Categories = new SelectList(categories, "Id", "Name");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Mark the entity as modified
            _context.Entry(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.Id))
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


        private bool BookExists(int id)
        {
            return (_context.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
