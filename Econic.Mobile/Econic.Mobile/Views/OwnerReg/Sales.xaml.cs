using Econic.Mobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.OwnerReg
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sales : ContentPage
    {
        AddOwnerViewModel _addOwnerViewModel;
        public Sales(AddOwnerViewModel addOwnerViewModel)
        {
            InitializeComponent();
            BindingContext = _addOwnerViewModel = addOwnerViewModel;
        }
        async void ContinueClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new FirstPreview(_addOwnerViewModel));
        }
    }
}