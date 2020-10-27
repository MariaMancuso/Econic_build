using Econic.Mobile.ViewModels;
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
	public partial class WelcomeActions : ContentView
	{
		CustomerViewModel customer;
		public WelcomeActions()
		{
			InitializeComponent();
			//bool appointment = customer.HasAppointment();
			//if(!appointment)
			//{
				appbttn.IsVisible = false;
			//}
		}
	}
}