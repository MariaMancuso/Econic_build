using Econic.Mobile.Services;
using Econic.Mobile.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Econic.Mobile.ViewModels;
using Econic.Mobile.Renderers;
using System.Collections.Generic;
using Syncfusion.XForms.ComboBox;

namespace Econic.Mobile.Views.OwnerReg
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoneySplash : ContentPage
    {
		public MoneySplash()
        {
            InitializeComponent();
		}

        private async void BtnClicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new CheckNameClassifyBusiness() { BindingContext = new OwnerBoardingViewModel()});
		}
	}
}