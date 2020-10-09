using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.OwnerReg;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DragAndDrop : ContentPage
    {
        AddOwnerViewModel _addOwnerViewModel;
        public DragAndDrop(AddOwnerViewModel addOwnerViewModel)
        {
            InitializeComponent();
            _addOwnerViewModel = addOwnerViewModel;
            listView.ItemsSource = _addOwnerViewModel.OwnerGoals;
        }
        async void ContinueClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Classification(_addOwnerViewModel));
        }
    }
}