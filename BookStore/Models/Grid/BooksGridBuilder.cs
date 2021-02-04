using BookStore.Models.DomainModels;
using BookStore.Models.DTOs;
using BookStore.Models.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Grid
{
	// inherits the general purpose GridBuilder class and adds application-specific 
	// methods for loading and clearing filter route segments in route dictionary.
	// Also adds application-specific Boolean flags for sorting and filtering. 
	public class BooksGridBuilder : GridBuilder
	{
		// this constructor gets current route data from session
		public BooksGridBuilder(ISession session) : base(session) { }

		// this constructor stores filtering route segments, as well as
		// the paging and sorting route segments stored by the base constructor
		public BooksGridBuilder(ISession session, BookGridDTO values, string defaultSortFilter)
			: base(session, values, defaultSortFilter)
		{
			// store filter route segments - add filter prefixes if this is initial load
			// of page with default values rather than route values (route values have prefix)

			bool isInitial = values.Genre.IndexOf(FilterPrefix.Genre) == -1;
			Routes.AuthorFilter = (isInitial) ? FilterPrefix.Author + values.Author : values.Author;
			Routes.GenreFilter = (isInitial) ? FilterPrefix.Genre + values.Genre : values.Genre;
			Routes.PriceFilter = (isInitial) ? FilterPrefix.Price + values.Price : values.Price;

			SaveRouteSegment();
		}

		// load new filter route segments contained in a string array - add filter prefix 
		// to each one. if filtering by author (rather than just 'all'), add author slug 
		public void LoadFilterSegments(string[] filters, Author author)
		{
			if (author == null)
			{
				Routes.AuthorFilter = FilterPrefix.Author + filters[0];
			}
			else
			{
				Routes.AuthorFilter = FilterPrefix.Author + filters[0] + "-" + author.FullName.Slug();
			}

			Routes.GenreFilter = FilterPrefix.Genre + filters[1];
			Routes.PriceFilter = FilterPrefix.Price + filters[2];
		}

		public void ClearFilterSegments() => Routes.ClearFilters();

		//filter flags
		string def = BookGridDTO.DefaultFilter;
		public bool IsFilterByAuthor => Routes.AuthorFilter != def;
		public bool IsFilterByGenre => Routes.GenreFilter != def;
		public bool IsFilterByPrice => Routes.PriceFilter != def;

		//sort flags
		public bool IsSortByGenre => Routes.SortField.EqualsNoCase(nameof(Genre));
		public bool IsSortByPrice => Routes.SortField.EqualsNoCase(nameof(Book.Price));
	}
}
