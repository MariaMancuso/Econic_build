using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Econic.Mobile.Models;

namespace Econic.Mobile.ViewModels
{
	class ServicesViewModel
	{
		private ObservableCollection<Models.Services> serviceCollection;

		public ObservableCollection<Models.Services> ServiceCollection
		{
			get { return serviceCollection; }
			set { serviceCollection = value; }
		}
		public ServicesViewModel() { }
		public ObservableCollection<Models.Services> SetServices()
		{
			serviceCollection = new ObservableCollection<Models.Services>();
			serviceCollection.Add(new Models.Services() { Name = "Brow Shape", price = "$12- 16", deal = "Buy one, get 1"});
			serviceCollection.Add(new Models.Services() { Name = "Brow Fit", price = "$25", deal = "50% off" });
			serviceCollection.Add(new Models.Services() { Name = "Virgin Brow", price = "$49", deal = "2 for 1" });
			serviceCollection.Add(new Models.Services() { Name = "Wax-Full Body", price = "$40", deal = "15% off" });
			serviceCollection.Add(new Models.Services() { Name = "Couples Wax", price = "$40- 45", deal = "2 for 1" });
			serviceCollection.Add(new Models.Services() { Name = "Acne Facial", price = "$75", deal = "30% off" });
			return serviceCollection;
		}
	}
}
