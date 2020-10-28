using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Econic.Mobile.Models;
using Econic.Mobile.Views.Templates;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Customer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DealBoard : ContentPage
	{
		ControlTemplate deals = new ControlTemplate(typeof(DealsDashboard));
		ControlTemplate tabbed = new ControlTemplate(typeof(TabbedView));
		//ControlTemplate card = new ControlTemplate(typeof(CardView));
		public DealBoard()
		{
			InitializeComponent();
			Refreshing(true);
			TabbedView.ControlTemplate = tabbed;
			Dash.ControlTemplate = deals;
			//cardView.ControlTemplate = card;
		}
		private async void Refreshing(bool running)
		{
			runner.IsRunning = running;
			if (running)
			{
				Dash.IsVisible = false;
				await Task.Delay(2000);
				Refreshing(false);
				Dash.IsVisible = true;
			}
		}
	}

}