using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.Customer;
using Econic.Mobile.Views.OwnerProfile;
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
            /*OwnerModel owner = new OwnerModel();
            OwnerViewModel model = new OwnerViewModel(owner);
            var page = new Hamburger { BindingContext = model };
            //page.Master = new HamburgerMaster { BindingContext = model };
            page.Detail = new NavigationPage(new OwnerTabbedPage 
            { 
                BindingContext = model, 
                BarBackgroundColor = Color.WhiteSmoke 
            }) 
            { 
                BarBackgroundColor = Color.WhiteSmoke,
                BackgroundColor = Color.WhiteSmoke
            };*/
            await Navigation.PushAsync(new WelcomeSplash()) ;
        }

        async void EmployeeClicked(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new SharedSplashOne { BindingContext = new EmployeeBoardingViewModel() });
            //await Navigation.PushModalAsync(new Hamburger());
        }

        async void CustomerClicked(object sender, EventArgs arg)
        {

            await Navigation.PushAsync(new SharedSplashOne { BindingContext = new CustomerViewModel() });
        }
    }
}
