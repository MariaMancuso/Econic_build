using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.Customer;
using Econic.Mobile.Views.OwnerReg;
using Econic.Mobile.Views.Shared.HamburgerMenu;
using Econic.Mobile.Views.Shared.SplashScreens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Econic.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void OwnerClicked(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new Views.EconicStudio.ChooseTheme());
        }

        async void EmployeeClicked(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new SharedSplashOne { BindingContext = new EmployeeViewModel() });
            //await Navigation.PushModalAsync(new Hamburger());
        }

        async void CustomerClicked(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new GenerateDeals());
        }
    }
}
