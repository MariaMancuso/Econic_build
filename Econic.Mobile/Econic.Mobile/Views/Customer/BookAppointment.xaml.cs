using Econic.Mobile.Renderers;
using Econic.Mobile.Views.Templates.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Customer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookAppointment : ContentPage
	{

		//List<string> servicelist = new List<string>();
		//List<string> monthlist = new List<string>();
		//List<string> datelist = new List<string>();
		//List<string> appointmentlist = new List<string>();
		
		
		public BookAppointment()
		{
			InitializeComponent();
			
			//SelectService();
			//SelectDay();
			//SelectMonth();
			
		}

		/*private void SelectService() 
		{
			IList<Models.Services> ser = new List<Models.Services> {
				new Models.Services ("Waxing"),
				new Models.Services ("Threading"),
				new Models.Services ("Cut")
			};

			for(int i = 0; i < ser.Count; i++)
			{
				Console.WriteLine(ser[i].Name);
				servicelist.Add(ser[i].Name);
			}

			serviceDropdown.ItemsSource = servicelist;
			serviceDropdown.SelectedIndex = 1;
			serviceDropdown.ItemSelected += OnDropdownSelected;
		}

		private void SelectDay()
		{
			DateTime date = DateTime.Now;
			int month = date.Month;
			int year = date.Year;
			var dayNum = DateTime.DaysInMonth(year, month);
			for (int i = 1; i < dayNum + 1; i++)
			{
				datelist.Add(i.ToString());
			}

			dayDropdown.ItemsSource = datelist;
			dayDropdown.SelectedIndex = 1;
			dayDropdown.ItemSelected += OnDropdownSelected;

		}

		private void SelectMonth()
		{
			for (int i = 0; i < 12; i++)
			{
				monthlist.Add(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[i]);
			}
			monthDropdown.ItemsSource = monthlist;
			monthDropdown.SelectedIndex = 1;
			monthDropdown.ItemSelected += OnDropdownSelected;
		}

		private void OnDropdownSelected(object sender, ItemSelectedEventArgs e)
		{
			var service = servicelist[e.SelectedIndex];
			Console.WriteLine("You selected: " + service);

			//service = list[e.SelectedIndex];
			await DisplayAlert("", list[e.SelectedIndex], "OK");
		}*/

	}
}