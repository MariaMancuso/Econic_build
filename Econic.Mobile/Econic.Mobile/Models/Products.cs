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
		public string img { get; set; }
		public string Price { set; get; }
	}
}
