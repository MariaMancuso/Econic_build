﻿using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;
using Econic.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using Econic.Mobile.Views.Customer;

namespace Econic.Mobile.Views.EconicStudio
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChooseTheme : ContentPage
	{
		ControlTemplates previousItem;
		ControlTemplates currentItem;

				
		object template { get; set; }
		//public ChooseTheme()

		//ControlTemplateViewModel control;
		public ChooseTheme(OwnerBoardingViewModel OwnerVM)
		{

			InitializeComponent();
			//BindingContext = control = new ControlTemplateViewModel(); ;
			//control.OBViewModel = OwnerVM;
			BindingContext = OwnerVM;
			CreateBoxGrid(OwnerVM);
		}

		//void OnCurrentItemChanged(object sender, CurrentItemChangedEventArgs e) 
		//{
		//	previousItem = e.PreviousItem as ControlTemplates;
		//	currentItem = e.CurrentItem as ControlTemplates;
		//	//control.ItemChanged(currentItem);
		//	//Console.WriteLine(currentItem.name);
		//	template = currentItem.name;
		//	//Console.WriteLine(template);
		//}

		private void CreateBoxGrid(OwnerBoardingViewModel control)
		{

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

		//private async void Button_Clicked(object sender, EventArgs e)
		//{
		//	if (template != null)
		//	{

		//		//control.ChangeThemeInfo(template);
		//		//await Navigation.PushAsync(new ChooseLogo());
		//	}
		//	else
		//	{
		//		Console.WriteLine("Oops! Something went wrong!");
		//	}
		//}
	}
}