using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.OwnerReg
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Classification : ContentPage
    {
        AddOwnerViewModel _addOwnerViewModel;

        public Classification(AddOwnerViewModel addOwnerViewModel)
        {
            List<ClassificationModel> CMlist = new List<ClassificationModel>()
            {
            new ClassificationModel() { Name = "Services" },
            new ClassificationModel() { Name = "Products" },
            new ClassificationModel() { Name = "Assets" }
            };
            
            InitializeComponent();

            CMlistView.ItemsSource = CMlist;
        }
        void ItemSelected(object sender, SelectedItemChangedEventArgs args)
        {

        }
        async void ContinueClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddItem(_addOwnerViewModel));
        }
    }
}