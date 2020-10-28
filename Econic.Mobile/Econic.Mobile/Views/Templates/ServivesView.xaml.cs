using Econic.Mobile.ViewModels;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ServivesView : ContentView
	{
		ServicesViewModel ser = new ServicesViewModel();
		public ServivesView()
		{
			InitializeComponent();
			ObservableCollection<Models.Services> products;
			products = ser.SetServices();

			var screenHeight = DeviceDisplay.MainDisplayInfo.Height;
			//listview.ItemSize = screenHeight;
			listview.HeightRequest = products.Count * 100;
			listview.ItemsSource = products;

			Padding = new Thickness(0, 20, 0, 0);
			Content = listview;
		}
	}
}