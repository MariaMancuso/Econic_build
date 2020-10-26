using Econic.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Customer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GenerateDeals : ContentPage
	{
		//CustomerViewModel CustomerVM = new CustomerViewModel();
		public GenerateDeals()
		{
			InitializeComponent();
			//BindingContext = CustomerVM;
		}
	}
}