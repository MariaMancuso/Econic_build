using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Econic.Mobile.Models
{
	public class CustomerModel
	{
		public bool hasAccount { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public ObservableCollection<OwnerGoalModel> Goals { get; set; }
		public Account Account { get; set; }
		public bool hasAppointment { get; set; }
		public ObservableCollection<CustomerAppointment> app { get; set; }
	}
}
