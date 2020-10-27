using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.Templates;
using Econic.Mobile.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Customer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClickedDeal : ContentPage
	{
		ControlTemplate tabbed = new ControlTemplate(typeof(TabbedView));
		CustomerViewModel customer = new CustomerViewModel();
		public ClickedDeal(Deals deals)
		{
			InitializeComponent();
			TabbedView.ControlTemplate = tabbed;
			var screenHeight = DeviceDisplay.MainDisplayInfo.Height;
			frame.HeightRequest = screenHeight;

			BindingContext = deals;
		}

		private async void ImageButton_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}