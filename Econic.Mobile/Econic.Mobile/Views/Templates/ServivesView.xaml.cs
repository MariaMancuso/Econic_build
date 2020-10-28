using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.Customer;
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

		private async void Button_Clicked(object sender, System.EventArgs e)
		{
			//Models.Services ser = (sender as Button).BindingContext as Models.Services;
			await Navigation.PushAsync(new BookAppointment());
		}
	}
}