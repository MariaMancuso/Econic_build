﻿using Econic.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Gamification
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FifthPreview : ContentPage
    {
        public FifthPreview(OwnerBoardingViewModel OwnerVM)
        {
            InitializeComponent();
            BindingContext = OwnerVM;
        }
    }
}