using Econic.Mobile.Models;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.OwnerProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderList : ContentPage
    {
        bool isPending;
        public OrderList()
        {
            InitializeComponent();
            buttonlist.ItemsSource = new string[] { "Pending", "Fullfilled" };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.orderslistview.DataSource.Filter = filterpending;
            this.orderslistview.DataSource.RefreshFilter();
            isPending = true;
        }
        private void OnTabChanged(object sender, EventArgs e)
        {
            var ev = (ItemSelectionChangedEventArgs)e;
            if (ev.AddedItems.Contains("Fullfilled"))
            {
                this.orderslistview.DataSource.Filter = filterfullfilled;
                isPending = false;
            }
            else
            {
                this.orderslistview.DataSource.Filter = filterpending;
                isPending = true;
            }
            this.orderslistview.DataSource.RefreshFilter();
        }
        private bool filterpending(object obj)
        {
            var order = obj as DetailOrderModel;
            if (!order.status)
                return true;
            else
                return false;
        }
        private bool filterfullfilled(object obj)
        {
            var order = obj as DetailOrderModel;
            if (order.status)
                return true;
            else
                return false;
        }
        Entry searchBar = null;
        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as Entry);
            if (orderslistview.DataSource != null)
            {
                this.orderslistview.DataSource.Filter = FilterOrders;
                this.orderslistview.DataSource.RefreshFilter();
            }
        }

        private bool FilterOrders(object obj)
        {
            if (searchBar == null || searchBar.Text == null)
                return true;

            var order = obj as DetailOrderModel;
            if(isPending)
                if (order.OrderNumber.ToString().Contains(searchBar.Text) && filterpending(obj))
                    return true;
                else
                    return false;
            else
                if (order.OrderNumber.ToString().Contains(searchBar.Text) && filterfullfilled(obj))
                return true;
            else
                return false;
        }
    }
}