using Econic.Mobile.Models;
using Syncfusion.DataSource;
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
    public partial class CustomerList : ContentPage
    {
        public CustomerList()
        {
            InitializeComponent();
            customerlistview.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "Name",
                KeySelector = (object obj1) =>
                {
                    var item = (obj1 as CustomerPartyDetailsModel);
                    return item.Name[0].ToString();
                }
            });
        }
        Entry searchBar = null;
        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as Entry);
            if (customerlistview.DataSource != null)
            {
                this.customerlistview.DataSource.Filter = FilterContacts;
                this.customerlistview.DataSource.RefreshFilter();
            }
        }

        private bool FilterContacts(object obj)
        {
            if (searchBar == null || searchBar.Text == null)
                return true;

            var contacts = obj as CustomerPartyDetailsModel;
            if (contacts.Name.ToLower().Contains(searchBar.Text.ToLower())
                 || contacts.Name.ToLower().Contains(searchBar.Text.ToLower()))
                return true;
            else
                return false;
        }
    }
}