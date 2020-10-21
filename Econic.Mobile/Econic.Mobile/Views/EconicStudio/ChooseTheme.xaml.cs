using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;
using Econic.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.EconicStudio
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChooseTheme : ContentPage
	{
		public ChooseTheme()
		{
			InitializeComponent();
			ControlTemplateViewModel control = new ControlTemplateViewModel();
			CreateBoxGrid();
			BindingContext = control;
		}

		private void CreateBoxGrid()
		{
			ControlTemplateViewModel control = new ControlTemplateViewModel();
			IList<BoxColorModel> b = control.CreateBoxCollection();


			var boxIndex = 0;
			//rows
			for (int i = 0; i < 2; i++)
			{
				//columns
				for(int j = 0; j < 6; j++)
				{ 				
					Button boxes = new Button()
					{
						BackgroundColor = b[boxIndex].color,
						HeightRequest = 24, 
						WidthRequest = 24,
						CommandParameter = b[boxIndex].color
					};
					boxes.SetBinding(Button.CommandProperty, new Binding(nameof(control.BoxCommand), source: control));
					grid.Children.Add(boxes, j, i);
					boxIndex++;
				}
			}

		}

	}
}