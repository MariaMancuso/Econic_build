using System;
using System.Collections.Generic;
using System.Text;

namespace Econic.Mobile.Models
{
	public class Products
	{
		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public int Rating { private set; get; }
		//public string Name { set; get; }

		public int Price { private set; get; }

		
	}
}
