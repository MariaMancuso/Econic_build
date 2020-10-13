using Econic.Mobile.Services;
using Econic.Mobile.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Econic.Mobile.ViewModels;

namespace Econic.Mobile.Views.OwnerReg
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoneySplash : ContentPage
    {
        public MoneySplash()
        {
            InitializeComponent();
            gg.HeightRequest = Application.Current.MainPage.Height;
            BindingContext = new OwnerViewModel();
        }
    }
}