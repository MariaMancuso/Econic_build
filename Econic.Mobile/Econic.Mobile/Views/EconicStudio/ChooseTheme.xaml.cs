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

		
		//public ChooseTheme(OwnerViewModel owner)
		//{
		//	InitializeComponent();
		//}

		
		public ChooseTheme()
		{
			InitializeComponent();
			CreateBoxGrid();
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
					BoxView boxes = new BoxView()
					{
						BackgroundColor = b[boxIndex].color,
						HeightRequest = 24, 
						WidthRequest = 24
					};

					grid.Children.Add(boxes, j, i);
					boxIndex++;
				}
			}
		}

	}
}