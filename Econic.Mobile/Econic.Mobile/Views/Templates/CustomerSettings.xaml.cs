using Econic.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomerSettings : ContentView
	{
		CustomerViewModel customer = new CustomerViewModel();
		public CustomerSettings()
		{
			InitializeComponent();
		}

		private void Contact_Tapped(object sender, EventArgs e)
		{
			customer.GoTo("Contact");
		}

		private void Payment_Tapped(object sender, EventArgs e)
		{
			customer.GoTo("Payment");
		}

		private void Privacy_Tapped(object sender, EventArgs e)
		{
			customer.GoTo("Privacy");
		}

		private void Languages_Tapped(object sender, EventArgs e)
		{
			customer.GoTo("Languages");
		}

		private void Revyvv_Tapped(object sender, EventArgs e)
		{
			customer.GoTo("Revyvv");
		}
	}
}