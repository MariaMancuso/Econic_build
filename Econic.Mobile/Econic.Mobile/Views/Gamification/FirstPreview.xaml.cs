using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.Shared;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.OwnerReg
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPreview : ContentPage
    {
        public FirstPreview(OwnerBoardingViewModel OwnerVM)
        {
            InitializeComponent();
            BindingContext = OwnerVM;
            //Initials.Text = OwnerVM?.GetInitials();
        }
    }
}