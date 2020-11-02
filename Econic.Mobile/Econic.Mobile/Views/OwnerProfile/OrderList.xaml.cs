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
        public OrderList()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.pendinglistview.DataSource.Filter = Filterpending;
            this.pendinglistview.DataSource.RefreshFilter();

            this.fullfilledlistview.DataSource.Filter = Filterfullfilled;
            this.fullfilledlistview.DataSource.RefreshFilter();
            isPending = true;
        }
        bool isPending;
        void OnTabChanged(object sender, Syncfusion.XForms.TabView.SelectionChangedEventArgs args)
        {
            if (args.Name == "Pending")
                isPending = true;
            else
                isPending = false;
        }
        private bool Filterpending(object obj)
        {
            var order = obj as DetailOrderModel;
            if (!order.status)
                return true;
            else
                return false;
        }
        private bool Filterfullfilled(object obj)
        {
            var order = obj as DetailOrderModel;
            if (order.status)
                return true;
            else
                return false;
        }
        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            if (isPending && pendinglistview.DataSource != null)
            {
                this.pendinglistview.DataSource.Filter = FilterOrders;
                this.pendinglistview.DataSource.RefreshFilter();
            }
            else if (!isPending && pendinglistview.DataSource != null)
            {
                this.fullfilledlistview.DataSource.Filter = FilterOrders;
                this.fullfilledlistview.DataSource.RefreshFilter();
            }
        }

        private bool FilterOrders(object obj)
        {
            if (SearchEntry == null || SearchEntry.Text == null)
                return true;

            var order = obj as DetailOrderModel;

            if(isPending)
            {
                if (order.OrderNumber.ToString().Contains(SearchEntry.Text) && Filterpending(obj))
                    return true;
                else
                    return false;
            }
            else
            {
                if (order.OrderNumber.ToString().Contains(SearchEntry.Text) && Filterfullfilled(obj))
                    return true;
                else
                    return false;

            }
        }
    }
}