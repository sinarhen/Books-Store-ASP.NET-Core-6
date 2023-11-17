using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Books.DBContext;
using Books.Models;

namespace Books.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly BooksProjectContext _context;

        public CreateModel(BooksProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category{ get; set; } = default!;
        
    
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(Category);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");

            }
            else
            {       
                return Page();
            }

        }
    }
}
