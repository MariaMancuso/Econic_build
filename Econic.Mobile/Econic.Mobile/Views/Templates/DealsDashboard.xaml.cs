using System;
using System.Collections.Generic;
using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.Customer;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DealsDashboard : ContentView
	{
		CustomerViewModel customer = new CustomerViewModel();
		
		public DealsDashboard()
		{
			
			InitializeComponent();
			var screenWidth = DeviceDisplay.MainDisplayInfo.Width;
			var screenHeight = DeviceDisplay.MainDisplayInfo.Height;
			var dealsList = customer.SetDeals();

			listview.ItemSize = 100;
			listview.WidthRequest = screenWidth * .88;
			listview.HeightRequest = dealsList.Count * 200;
			listview.ItemsSource = dealsList;
			Content = listview;
		}

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ClickedDeal());
		}
	}
}