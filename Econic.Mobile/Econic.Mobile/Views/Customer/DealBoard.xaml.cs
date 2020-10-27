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
		public DealBoard()
		{
			InitializeComponent();
			TabbedView.ControlTemplate = tabbed;
			Dash.ControlTemplate = deals;
		}
	}

}