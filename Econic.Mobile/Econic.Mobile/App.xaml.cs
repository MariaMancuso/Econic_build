﻿using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.Gamification;
using Econic.Mobile.Views.OwnerProfile;
using Econic.Mobile.Views.OwnerReg;
using Econic.Mobile.Views.Shared;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Quicksand-Regular.ttf", Alias = "Quicksand")]
[assembly: ExportFont("Quicksand-Bold.ttf", Alias = "QuicksandBold")]
[assembly: ExportFont("Quicksand-Light.ttf", Alias = "QuicksandLight")]
[assembly: ExportFont("Quicksand-SemiBold.ttf", Alias = "QuicksandSemiBold")]
[assembly: ExportFont("Quicksand-Medium.ttf", Alias = "QuicksandMedium")]

namespace Econic.Mobile
{
    public partial class App : Application
    {
        public static NavigationPage Navigation = null;

        public App()
        {
            Device.SetFlags(new[] { "SwipeView_Experimental" });
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzMzMzI5QDMxMzgyZTMzMmUzMFpUbmo3aGYzM2M5R2cyTmc0WjlhRmhnckFPT3RVR2tzTGlkMlk1WSs0bnM9");

            InitializeComponent();
            /*Image i = new Image();
            i.Source = "OwnerSplashPage1.png";
            OwnerModel m = new OwnerModel()
            {
                Items = new ObservableCollection<ItemModel>() { new ItemModel() { Image = i, Name = "TestName", MinPrice = "9", MaxPrice = "19", Description = "Description" } }
            };
            OwnerViewModel viewmodel = new OwnerViewModel();

            viewmodel.Owner = m; */
            Navigation = new NavigationPage(new MainPage());
           // Navigation = new NavigationPage(new WelcomeSplash());

            Current.MainPage = Navigation;
            ControlTemplateViewModel control = new ControlTemplateViewModel();
            BindingContext = control;
        }
        public async void OnBackButtonPressed(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

		private async void App_Clicked(object sender, EventArgs e)
		{
            await Application.Current.MainPage.Navigation.PushAsync(new Views.Customer.BookAppointment());
        }

		private async void Sale_Clicked(object sender, EventArgs e)
		{
            await Application.Current.MainPage.Navigation.PushAsync(new Views.Customer.OnSale());
        }
	}
}
