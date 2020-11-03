using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Econic.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.EconicStudio
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomeScreen : ContentPage
	{
		public WelcomeScreen(OwnerBoardingViewModel User)
		{
			InitializeComponent();
			BindingContext = User;
		}
	}
}