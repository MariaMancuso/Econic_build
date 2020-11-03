using Econic.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.EconicStudio
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChooseLogo : ContentPage
	{
		//OwnerViewModel OwnerVM = new OwnerViewModel();
		public ChooseLogo(OwnerBoardingViewModel ownervm)
		{
			InitializeComponent();
            bodyContent.BindingContext = ownervm;
		}
    }
}