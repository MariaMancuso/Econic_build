﻿using Econic.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.OwnerReg
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Address : ContentPage
    {
        AddOwnerViewModel _addOwnerViewModel;
        public Address(AddOwnerViewModel addOwnerViewModel)
        {
            InitializeComponent();
            BindingContext = _addOwnerViewModel = addOwnerViewModel;

            List<string> states = new List<string>();
            states.Add("AL");
            states.Add("AK");
            states.Add("AZ");
            states.Add("AR");
            states.Add("CA");
            states.Add("CO");
            states.Add("CT");
            states.Add("DE");
            states.Add("DC");
            states.Add("FL");
            states.Add("GA");
            states.Add("HI");
            states.Add("ID");
            states.Add("IL");
            states.Add("IN");
            states.Add("IA");
            states.Add("KS");
            states.Add("KY");
            states.Add("LA");
            states.Add("ME");
            states.Add("MD");
            states.Add("MA");
            states.Add("MI");
            states.Add("MN");
            states.Add("MS");
            states.Add("MO");
            states.Add("MT");
            states.Add("NE");
            states.Add("NV");
            states.Add("NH");
            states.Add("NJ");
            states.Add("NM");
            states.Add("NY");
            states.Add("NC");
            states.Add("ND");
            states.Add("OH");
            states.Add("OK");
            states.Add("OR");
            states.Add("PA");
            states.Add("RI");
            states.Add("SC");
            states.Add("SD");
            states.Add("TN");
            states.Add("TX");
            states.Add("UT");
            states.Add("VT");
            states.Add("VA");
            states.Add("WA");
            states.Add("WV");
            states.Add("WI");
            states.Add("WY");
            Statedd.ItemsSource = states;

        }
        async void ContinueClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Sales(_addOwnerViewModel));
        }
    }
}