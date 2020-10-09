using Econic.Mobile.Views.OwnerReg;
using Econic.Mobile.Views.Shared;
using System;
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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzMwMjA5QDMxMzgyZTMzMmUzMGhleGZINGkzc21xRGNyeXdTV3ltOExsM3NFcTJ6YzJMdmMvR2VwUlhJTVk9");

            InitializeComponent();

            Navigation = new NavigationPage(new WelcomeSplash());
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
