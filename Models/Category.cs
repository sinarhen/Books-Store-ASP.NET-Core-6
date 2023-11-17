using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }
		
		[Required(ErrorMessage = "Name is required")]
		[Column("Name", TypeName="Varchar(50)")]
		public string Name { get; set; }
		
		public string? Description { get; set; }
	}
}
