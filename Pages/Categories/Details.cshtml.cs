using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Books.DBContext;
using Books.Models;

namespace Books.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly BooksProjectContext _context;

        public DetailsModel(BooksProjectContext context)
        {
            _context = context;
            Category = new Category();
            Books = new List<Book>();
        }

        public Category Category { get; set; } = default!; 
        public List<Book> Books { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            Category = category;
            Books = await _context.Books.Where(b => b.CategoryId == id).ToListAsync();

            return Page();
        }
    }
}
