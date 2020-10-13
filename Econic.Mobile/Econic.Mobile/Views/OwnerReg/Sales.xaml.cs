using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.OwnerReg
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sales : ContentPage
    {
        public Sales(OwnerViewModel OwnerVM)
        {
            InitializeComponent();
            BindingContext = OwnerVM;
        }
    }
}