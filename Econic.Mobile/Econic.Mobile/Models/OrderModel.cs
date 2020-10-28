using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Econic.Mobile.Models
{
    public class SummaryOrderModel
    {
        public string ProductName { get; set; }
        public long OrderNumber { get; set; }
        public int Price { get; set; }
        public DateTime OrderDate { get; set; }
        public bool status { get; set; }
        public bool PaymentVerified { get; set; }
        public int CountryCode { get; set; }
        public string ImageSource { get; set; }
    }
}
