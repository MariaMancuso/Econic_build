using Econic.Mobile.Views.OwnerReg;
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
            await Navigation.PushAsync(new WelcomeSplash());
        }

        async void EmployeeClicked(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new WelcomeSplash());
        }

        async void CustomerClicked(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new Views.Customer.LandingPage());
        }
    }
}
