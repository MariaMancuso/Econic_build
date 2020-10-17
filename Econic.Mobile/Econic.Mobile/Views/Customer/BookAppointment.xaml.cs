using Econic.Mobile.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Customer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookAppointment : ContentPage
	{
		List<string> list = new List<string>();
		public BookAppointment()
		{
			InitializeComponent();
			SelectService();
		}

		private void SelectService() 
		{
			IList<Models.Services> ser = new List<Models.Services> {
				new Models.Services ("Waxing"),
				new Models.Services ("Threading"),
				new Models.Services ("Cut")
			};

			for(int i = 0; i < ser.Count; i++)
			{
				list.Add(ser[i].Name);
			}

			serviceDropdown.ItemsSource = list;
			serviceDropdown.SelectedIndex = 1;
			serviceDropdown.ItemSelected += OnDropdownSelected;
		}

		private async void OnDropdownSelected(object sender, ItemSelectedEventArgs e)
		{
			//service = list[e.SelectedIndex];
			await DisplayAlert("", list[e.SelectedIndex], "OK");
		}
	}
}