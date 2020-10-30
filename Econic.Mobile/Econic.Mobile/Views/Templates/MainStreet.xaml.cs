using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	
	public partial class MainStreet : ContentView
	{
		CustomerViewModel customer = new CustomerViewModel();
		public MainStreet()
		{
			InitializeComponent();
			CreateGrid();
		}

		private void CreateGrid()
		{
			ObservableCollection<CustomerLevels> level = customer.SetLevelImages();
			var index = 0;
			for(int r = 0; r < 3; r++)
			{
				for(int c = 0; c < 3; c++)
				{
					Image img = new Image()
					{
						Source = level[index].disabled,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						HeightRequest = 70
					};

					Label label = new Label()
					{
						Text = "Level " + level[index].level,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center
					};

					StackLayout stack = new StackLayout()
					{
						Children =
						{
							img, label
						}
					};

					grid.Children.Add(stack, c, r);
					index++;
				}
			}
		}
	}
}