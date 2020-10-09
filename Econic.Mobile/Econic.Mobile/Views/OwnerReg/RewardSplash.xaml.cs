﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.OwnerReg
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RewardSplash : ContentPage
    {
        public RewardSplash()
        {
            InitializeComponent();
        }
        async void BtnClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new DealSplash());
        }
    }
}