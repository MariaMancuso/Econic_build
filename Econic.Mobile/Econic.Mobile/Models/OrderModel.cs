using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace Econic.Mobile.Models
{
    public class SummaryOrderModel
    {
        public string ProductName { get; set; }
        public long OrderNumber { get; set; }
        public int Price { get; set; }
        public DateTime OrderDate { get; set; }
        public bool status { get; set; }
        public int CountryCode { get; set; }
        public string ImageSource { get; set; }
    }
    public class DetailOrderModel
    {
        public DateTime OrderDate { get; set; }
        public bool status { get; set; }
        public long OrderNumber { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public int Tax { get; set; }
        public int Total { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public long CustomerNumber { get; set; }
        public AddressModel ShippingAddress { get; set; }
        public string Type { get; set; }
        public bool PaymentVerified { get; set; }
    }
    public class Item
    {
        public int Count { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
