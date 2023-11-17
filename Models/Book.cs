using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }
		
		[Column("title", TypeName="Varchar(120)")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
		public string? Description { get; set; }

		public decimal? Price { get; set; }
        
		[Column("author", TypeName = "Varchar(50)")]
        [StringLength(50)]
        public string? Author { get; set; }
		public int? CategoryId { get; set; }
		public string? ThumbnailUrl { get; set; }
	}
}
