using System;
using System.Collections.Generic;
using System.Text;

namespace Econic.Mobile.Models
{
	class Products
	{
		public int Rating { private set; get; }
		public string Name { private set; get; }

		public int Price { private set; get; }

		public Products(int rating, string name, int price)
		{
			this.Rating = rating;
			this.Name = name;
			this.Price = price;
		}
	}
}
