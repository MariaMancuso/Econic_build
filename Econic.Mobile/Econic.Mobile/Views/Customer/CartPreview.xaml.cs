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
	public partial class CartPreview : ContentPage
	{
		//ControlTemplate carts = new ControlTemplate(typeof(CartWithItems));
		ControlTemplate tabbed = new ControlTemplate(typeof(TabbedView));
		public CartPreview(Models.Products products)
		{
			InitializeComponent();
			//cart.ControlTemplate = carts;
			TabbedView.ControlTemplate = tabbed;
			BindingContext = products;
		}
	}
}