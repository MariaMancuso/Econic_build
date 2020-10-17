﻿using Econic.Mobile.Controls.ListViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavoriteServices : ContentView
	{
		
		public FavoriteServices()
		{
			InitializeComponent();
			
			//List<Models.Services> services = new List<Models.Services>
			//{
			//	new Models.Services( "Full Brow", "Waxing" ),
			//	new Models.Services( "Partial Cut", "Hair Cut" )
			//};
			//faveServicesListview.HeightRequest = services.Count * 100;

			//faveServicesListview.ItemsSource = services;
			faveServicesListview.ItemTemplate = new DataTemplate(typeof(CustomCell));

			Padding = new Thickness(0, 20, 0, 0);
			Content = faveServicesListview;
		}
	}
}