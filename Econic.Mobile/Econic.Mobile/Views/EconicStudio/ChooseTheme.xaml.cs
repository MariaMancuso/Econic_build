using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.Templates;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Econic.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.EconicStudio
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChooseTheme : ContentPage
	{
		
		public ChooseTheme(OwnerViewModel owner)
		{
			InitializeComponent();
		}

		public ChooseTheme()
		{
			InitializeComponent();
			
		}

	}
}