using Econic.Mobile.Models;
using Econic.Mobile.Resources;
using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.Customer;
using Econic.Mobile.Views.EconicStudio;
using Econic.Mobile.Views.Employee;
using Econic.Mobile.Views.Gamification;
using Econic.Mobile.Views.OwnerProfile;
using Econic.Mobile.Views.OwnerReg;
using Econic.Mobile.Views.Shared;
using Econic.Mobile.Views.Shared.HamburgerMenu;
using Plugin.Multilingual;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Quicksand-Regular.ttf", Alias = "Quicksand")]
[assembly: ExportFont("Quicksand-Bold.ttf", Alias = "QuicksandBold")]
[assembly: ExportFont("Quicksand-Light.ttf", Alias = "QuicksandLight")]
[assembly: ExportFont("Quicksand-SemiBold.ttf", Alias = "QuicksandSemiBold")]
[assembly: ExportFont("Quicksand-Medium.ttf", Alias = "QuicksandMedium")]
[assembly: ExportFont("Roboto-Regular.ttf", Alias = "RobotoRegular")]
[assembly: ExportFont("Roboto-Bold.ttf", Alias = "RobotoBold")]
[assembly: ExportFont("Roboto-Light.ttf", Alias = "RobotoLight")]
[assembly: ExportFont("Lora-Regular.ttf", Alias = "LoraRegular")]
[assembly: ExportFont("Lora-Medium.ttf", Alias = "LoraMedium")]
[assembly: ExportFont("Lora-Bold.ttf", Alias = "LoraBold")]

namespace Econic.Mobile
{
    public partial class App : Application
    {
        public static NavigationPage Navigation = null;

        public App()
        {
            CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("en");
            AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
            Device.SetFlags(new[] { "SwipeView_Experimental", "Expander_Experimental" });
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzMzMzI5QDMxMzgyZTMzMmUzMFpUbmo3aGYzM2M5R2cyTmc0WjlhRmhnckFPT3RVR2tzTGlkMlk1WSs0bnM9");

            InitializeComponent();

            //Navigation = new NavigationPage(new LandingPage());

            Navigation = new NavigationPage(new MainPage());
            //Navigation.BarBackgroundColor = Color.WhiteSmoke;
            //Navigation.BarTextColor = Color.FromHex("#404040");


            Current.MainPage = Navigation;
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
	}
}
