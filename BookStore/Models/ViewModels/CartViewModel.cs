using BookStore.Models.DomainModels;
using BookStore.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.ViewModels
{
	public class CartViewModel
	{
		public IEnumerable<CartItem> List { get; set; }
		public double Subtotal { get; set; }
		public RouteDictionary BookGridRoute { get; set; }
	}
}
