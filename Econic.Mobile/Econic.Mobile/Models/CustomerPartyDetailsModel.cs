using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Econic.Mobile.Models
{
    public class CustomerPartyDetailsModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long Number { get; set; }
        public int CountryCode { get; set; }
        public DateTime StartDate { get; set; }
        public AddressModel ShippingAddress { get; set; }
        public ObservableCollection<SummaryOrderModel> Orders { get; set; }
    }
}
