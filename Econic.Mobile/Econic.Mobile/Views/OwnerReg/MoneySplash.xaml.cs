using Econic.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.OwnerReg
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoneySplash : ContentPage
    {
        AddOwnerViewModel _addOwnerViewModel;
        public MoneySplash()
        {
            InitializeComponent();
            //gg.HeightRequest = Application.Current.MainPage.Height;
            BindingContext = _addOwnerViewModel = new AddOwnerViewModel();
        }
        async void ContinueClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Address(_addOwnerViewModel));
        }
    }
}