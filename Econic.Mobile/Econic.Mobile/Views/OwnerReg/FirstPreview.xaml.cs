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
        AddOwnerViewModel _addOwnerViewModel;
        public FirstPreview(AddOwnerViewModel addOwnerViewModel)
        {
            InitializeComponent();
            BindingContext = _addOwnerViewModel = addOwnerViewModel;
            Initials.Text = _addOwnerViewModel?.GetInitials();
        }
        async void ContinueClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new DragAndDrop(_addOwnerViewModel));
        }
    }
}