using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.Templates;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Customer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LandingPage : ContentPage
	{
		ControlTemplate welcome = new ControlTemplate(typeof(WelcomeActions));
		ControlTemplate services = new ControlTemplate(typeof(FavoriteServices));
		ControlTemplate products = new ControlTemplate(typeof(FavoriteServices));
		public LandingPage()
		{
			InitializeComponent();
			WelcomeContent.ControlTemplate = welcome;
			FaveServices.ControlTemplate = services;
			FaveProducts.ControlTemplate = products;

		}

		private async void Shop_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Views.Customer.ListProducts());
		}

		private async void Book_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Views.Customer.ListServices());
		}
	}
}