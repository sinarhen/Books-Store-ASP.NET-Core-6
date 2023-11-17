using Books.DBContext;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Pages.Categories
{
    public class BooksModel : PageModel
    {
        private readonly BooksProjectContext _context;

        public BooksModel(BooksProjectContext context)
        {
            _context = context;
            Categories = new List<Category>();
        }

        public List<Category> Categories { get; set; }

        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.ToListAsync();
        }
    }
}
