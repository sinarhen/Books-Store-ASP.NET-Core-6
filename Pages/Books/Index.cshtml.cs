using Books.DBContext;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Books.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Books.Pages.Books
{
    public class BooksModel : PageModel
    {
        private readonly BooksProjectContext _context;

        public BooksModel(BooksProjectContext context)
        {
            _context = context;
            Books = new List<BookStats>();
            Categories = new List<Category>();
            SortBy = "name";
        }

        public List<BookStats> Books { get; set; }
        public List<Category> Categories { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Enter something")]
        public string? Query { get; set; }

        [BindProperty]
        public string? SortBy { get; set; }
        public async Task OnGetAsync(string sortBy, string query)
        {
            SortBy = sortBy;

            var categories = await _context.Categories.ToListAsync();

            var booksUpd = from b in _context.Books 
                join c in _context.Categories on b.CategoryId equals c.Id
                select new BookStats()
                {
                    Author = b.Author,
                    Title = b.Title,
                    Description = b.Description,
                    Price = b.Price,
                    ThumbnailUrl = b.ThumbnailUrl,
                    CategoryId = b.CategoryId,
                    CategoryName = c != null ? c.Name : null,
                }
                ;
            if (!String.IsNullOrEmpty(query))
            {
                booksUpd = booksUpd.Where(book =>
                book.CategoryName.Contains(query) ||
                book.Title.Contains(query) ||
                book.Author.Contains(query) ||
                book.Description.Contains(query));
                    
            }
            if (!String.IsNullOrEmpty(SortBy))
            {
                switch (SortBy.ToLower())
                {
                    case "name":
                        booksUpd = booksUpd.OrderBy(b => b.Title);
                        break;
                    case "author":
                        booksUpd = booksUpd.OrderBy(b => b.Author);
                        break;
                    case "genre":
                        booksUpd = booksUpd.OrderBy(b => b.CategoryName);
                        break;

                }

            }
            Books = await booksUpd.ToListAsync();
            Categories = categories;
        }

    }
}
