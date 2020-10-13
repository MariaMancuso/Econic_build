using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.OwnerReg;
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
        OwnerViewModel _OwnerVM;
        ItemModel _item;
        public ItemPreview(OwnerViewModel OwnerVM, ItemModel item)
        {
            InitializeComponent();
            _OwnerVM = OwnerVM;
            BindingContext = _item = item;
        }
        async void AddBtnClicked(object sender, EventArgs args)
        {
            _OwnerVM.Owner.Items.Add(_item);
            await Navigation.PushAsync(new AddItem(_OwnerVM));
        }
        async void ContinueClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SecondPreview(_OwnerVM));
        }
    }
}