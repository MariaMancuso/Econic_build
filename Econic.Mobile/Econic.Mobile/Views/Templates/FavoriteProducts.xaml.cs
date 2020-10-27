﻿using Econic.Mobile.Controls.ListViews;
using Econic.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavoriteProducts : ContentView
	{
		ProductsViewModel prod = new ProductsViewModel();
		public FavoriteProducts()
		{
			InitializeComponent();
			ObservableCollection<Models.Products> products;
			products = prod.SetProducts();
			listview.HeightRequest = products.Count * 100;
			listview.ItemsSource = products;
			listview.ItemTemplate = new DataTemplate(typeof(CustomFPCell));

			Padding = new Thickness(0, 20, 0, 0);
			Content = listview;
		}
	}
}