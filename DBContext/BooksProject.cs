using Microsoft.EntityFrameworkCore;
using Books.Models;

namespace Books.DBContext

{
	public class BooksProjectContext : DbContext
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<Category> Categories { get; set; }

		public BooksProjectContext(DbContextOptions<BooksProjectContext> options) : base(options) 
		{ 
		
		}	
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>();
			modelBuilder.Entity<Category>();
		}
	}
}
