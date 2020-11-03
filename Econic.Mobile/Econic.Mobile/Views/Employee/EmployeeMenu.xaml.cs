using Econic.Mobile.Views.OwnerProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Employee
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeMenu : ContentPage
    {
        public EmployeeMenu()
        {
            InitializeComponent();
        }
        public async void PurchaseTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new OrderList { BindingContext = this.BindingContext });
        }
        public async void ClientTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CustomerList { BindingContext = this.BindingContext });
        }

    }
}