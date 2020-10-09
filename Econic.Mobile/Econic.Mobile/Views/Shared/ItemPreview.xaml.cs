using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPreview : ContentPage
    {
        AddOwnerViewModel _addOwnerViewModel;
        Item _item;
        public ItemPreview(AddOwnerViewModel addOwnerViewModel, Item item)
        {
            InitializeComponent();
            _addOwnerViewModel = addOwnerViewModel;
            BindingContext = _item = item;
        }
        async void AddBtnClicked(object sender, EventArgs args)
        {
            _addOwnerViewModel.Items.Add(_item);
            await Navigation.PushAsync(new AddItem(_addOwnerViewModel));
        }
    }
}