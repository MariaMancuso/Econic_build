using System;
using System.Collections.Generic;
using System.Text;

namespace Econic.Mobile.Models
{
	public class CustomerAppointment
	{
		public DateTime start { get; set; }
		public DateTime end { get; set; }
		public DateTime date { get; set; }
		public string service { get; set; }
		public string location { get; set; }
	}
}
