using Econic.Mobile.Services;
using Econic.Mobile.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Econic.Mobile.ViewModels;
using Econic.Mobile.Renderers;
using System.Collections.Generic;
using Syncfusion.XForms.ComboBox;

namespace Econic.Mobile.Views.OwnerReg
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoneySplash : ContentPage
    {
		public MoneySplash()
        {
            InitializeComponent();
            //gg.HeightRequest = Application.Current.MainPage.Height;
            BindingContext = new OwnerBoardingViewModel();

           // SelectService();
			//SelectProduct();
			

		}

        //private void SelectService()
		//{

			//IList<Models.Services> ser = new List<Models.Services> {
			//	new Models.Services ("Services"),
			//	new Models.Services ("Apparel"),
			//	new Models.Services ("Food service"),
			//	new Models.Services ("Household goods"),
			//	new Models.Services ("Sports"),
			//	new Models.Services ("Health and Beauty"),
			//	new Models.Services ("Jewlery"),
			//};

			//for (int i = 0; i < ser.Count; i++)
			//{
			//	list.Add(ser[i].Name);
			//}
			
			//serviceDropdown.ItemsSource = list;
			//serviceDropdown.SelectedIndex = 0;
			//serviceDropdown.ItemSelected += OnServiceDropdownSelected;
		//}

		//private void OnServiceDropdownSelected(object sender, ItemSelectedEventArgs e)
		//{
		//	if(e.SelectedIndex != 0)
		//	{
		//		Console.WriteLine(list[e.SelectedIndex]);
		//		//serviceDropdown = list[e.SelectedIndex];
		//	}
			
		//}

		//private void SelectProduct()
		//{
			//IList<Models.Products> ser = new List<Models.Products> {
			//	new Models.Products ("Goods"),
			//	new Models.Products ("Apparel"),
			//	new Models.Products ("Food service"),
			//	new Models.Products ("Household goods"),
			//	new Models.Products ("Sports"),
			//	new Models.Products ("Health and Beauty"),
			//	new Models.Products ("Jewlery"),
			//};

			//for (int i = 0; i < ser.Count; i++)
			//{
			//	list2.Add(ser[i].Name);
			//}

			//productsDropdown.ItemsSource = list2;
			//productsDropdown.SelectedIndex = 0;
			//productsDropdown.ItemSelected += OnProductDropdownSelected;
			
			
		//}



		//private void OnProductDropdownSelected(object sender, ItemSelectedEventArgs e)
		//{
		//	if (e.SelectedIndex != 0)
		//	{
		//		Console.WriteLine(list2[e.SelectedIndex]);
		//		//serviceDropdown = list[e.SelectedIndex];
		//	}

		//}
	}
}