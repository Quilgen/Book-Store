using BookStore.Models.DomainModels;
using BookStore.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.ViewModels
{
	public class AuthorListViewModel
	{
		public IEnumerable<Author> Authors { get; set; }
		public RouteDictionary CurrentRoute { get; set; }
		public int TotalPages { get; set; }
	}
}
