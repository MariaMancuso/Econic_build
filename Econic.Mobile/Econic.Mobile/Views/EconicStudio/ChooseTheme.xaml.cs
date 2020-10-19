using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
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
		IList<BoxColorModel> boxes;
		BoxColorViewModel boxvm;
		public ChooseTheme(OwnerViewModel owner)
		{
			InitializeComponent();
			BindingContext = owner;
			//SetColorGrid();
		}

		public void SetColorGrid()
		{
			//boxes = boxvm.SetColors();
			
		}
	}
}