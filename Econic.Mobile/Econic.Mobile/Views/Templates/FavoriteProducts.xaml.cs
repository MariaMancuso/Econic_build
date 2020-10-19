using Econic.Mobile.Controls.ListViews;
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
	public partial class FavoriteProducts : ContentView
	{
		public FavoriteProducts()
		{
			InitializeComponent();
			List<Models.Products> products = new List<Models.Products>
			{
				//new Models.Products( 4, "Eyebrow Brush", 18 ),
				//new Models.Products( 5, "The Brow Trio", 19 ),
				//new Models.Products( 2, "The Finish Wax", 29 ),
			};
			listview.HeightRequest = products.Count * 100;
			listview.ItemsSource = products;
			listview.ItemTemplate = new DataTemplate(typeof(CustomFPCell));

			Padding = new Thickness(0, 20, 0, 0);
			Content = listview;
		}
	}
}