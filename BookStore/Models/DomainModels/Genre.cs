using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.DomainModels
{
	public class Genre
	{
		[Required(ErrorMessage ="Please enter genre id")]
		[MaxLength(10)]
		public string GenreId { get; set; }

		[Required(ErrorMessage = "Please enter genre name")]
		[StringLength(25)]
		public string Name { get; set; }

		public ICollection<Book> Books { get; set; }
	}
}
