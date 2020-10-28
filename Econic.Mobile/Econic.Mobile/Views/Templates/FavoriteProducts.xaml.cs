using Econic.Mobile.Controls.ListViews;
using Econic.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavoriteProducts : ContentView
	{
		ProductsViewModel prod = new ProductsViewModel();
		CustomerViewModel customer = new CustomerViewModel();
		public FavoriteProducts()
		{
			InitializeComponent();
			ObservableCollection<Models.Products> products;
			ObservableCollection<Models.Products> list = new ObservableCollection<Models.Products>();
			products = prod.SetProducts();

			for(int i = 0; i < 3; i++)
			{
				list.Add(products[i]);
			}

			listview.HeightRequest = list.Count * 100;
			listview.ItemsSource = list;
			//listview.ItemTemplate = new DataTemplate(typeof(CustomFPCell));

			Padding = new Thickness(0, 20, 0, 0);
			Content = listview;
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			Models.Products product = (sender as Button).BindingContext as Models.Products;
			customer.SetCartPreview(product.Name);
		}
	}
}