using Econic.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductsView : ContentView
	{
		ProductsViewModel prod = new ProductsViewModel();
		public ProductsView()
		{
			InitializeComponent();
			ObservableCollection<Models.Products> products;
			products = prod.SetProducts();
			var screenHeight = DeviceDisplay.MainDisplayInfo.Height;
			listview.ItemSize = screenHeight;
			listview.HeightRequest = products.Count * 100;
			listview.ItemsSource = products;

			Padding = new Thickness(0, 20, 0, 0);
			Content = listview;
		}
	}
}