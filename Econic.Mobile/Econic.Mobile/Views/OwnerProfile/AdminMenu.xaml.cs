﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.OwnerProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminMenu : ContentPage
    {
        public AdminMenu()
        {
            InitializeComponent();
        }
        public async void QrTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Shared.HamburgerMenu.Settings { BindingContext = this.BindingContext });
        }
        public async void EmployeesTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new EmployeeList { BindingContext = this.BindingContext });
        }
        public async void CustomersTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CustomerList { BindingContext = this.BindingContext });
        }
    }
}