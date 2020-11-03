using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Econic.Mobile.Models
{
    public class ItemModel
    {
        public ImageSource ImageSource { get; set; }

        public string Name { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string StockCount { get; set; }
        public bool IsShipped { get; set; }
        public int ShippingRate { get; set; }
        public string ServiceDuration { get; set; }
        public string PriceRange
        {
            get
            {
                return string.Format("${0}-${1}", MinPrice, MaxPrice);
            }
        }
    }
}
