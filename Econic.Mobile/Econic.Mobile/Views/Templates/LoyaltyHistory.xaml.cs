using Econic.Mobile.Models;
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
	public partial class LoyaltyHistory : ContentView
	{
		CustomerViewModel cvm = new CustomerViewModel();
		ObservableCollection<SummaryOrderModel> orderModels = new ObservableCollection<SummaryOrderModel>();
		public LoyaltyHistory()
		{
			InitializeComponent();
			orderModels = cvm.SetOrders();
			listview.ItemsSource = orderModels;
			listview.WidthRequest = DeviceDisplay.MainDisplayInfo.Width * .88;
			listview.HeightRequest = orderModels.Count * 200;
			Content = listview;
		}
	}
}