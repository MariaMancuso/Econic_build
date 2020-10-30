using Econic.Mobile.Controls.ListViews;
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
	public partial class FavoriteServices : ContentView
	{
		ServicesViewModel ser = new ServicesViewModel();
		public FavoriteServices()
		{
			InitializeComponent();

			ObservableCollection<Models.Services> products;
			ObservableCollection<Models.Services> list = new ObservableCollection<Models.Services>();
			products = ser.SetServices();

			for (int i = 0; i < 3; i++)
			{
				list.Add(products[i]);
			}

			var screenHeight = DeviceDisplay.MainDisplayInfo.Height;
			listview.ItemSize = screenHeight;
			listview.HeightRequest = list.Count * 100;
			listview.ItemsSource = list;
			//listview.ItemTemplate = new DataTemplate(typeof(CustomCell));

			Padding = new Thickness(0, 20, 0, 0);
			Content = listview;
		}
	}
}