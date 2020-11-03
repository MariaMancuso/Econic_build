using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.Templates;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Customer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListProducts : ContentPage
	{
		ControlTemplate tabbed = new ControlTemplate(typeof(TabbedView));
		ControlTemplate products = new ControlTemplate(typeof(ProductsView));
		public ListProducts()
		{
			InitializeComponent();
			TabbedView.ControlTemplate = tabbed;
			ProductsView.ControlTemplate = products;
		}
	}
}