using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.Templates;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.EconicStudio
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChooseTheme : ContentPage
	{
		IList<ControlTemplates> templates = new List<ControlTemplates>();

		
		public ChooseTheme(OwnerViewModel owner)
		{
			InitializeComponent();
			//BindingContext = owner;
		}
		public ChooseTheme()
		{
			InitializeComponent();

			//carouselView.ItemsSource = templates;
			//Content = carouselView;
		}

	}
}