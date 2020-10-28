using Econic.Mobile.Views.Templates;
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
	public partial class LoyaltyConfirmation : ContentPage
	{
		ControlTemplate tabbed = new ControlTemplate(typeof(TabbedView));
		public LoyaltyConfirmation()
		{
			InitializeComponent();
			TabbedView.ControlTemplate = tabbed;
		}
	}
}