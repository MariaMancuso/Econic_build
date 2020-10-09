﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Econic.Mobile.Models
{
    public class Item
    {
        public Image Image { get; set; }

        public string Name { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
        public string Description { get; set; }

        public string PriceRange
        {
            get
            {
                return string.Format("${0}-${1}", MinPrice, MaxPrice);
            }
        }
    }
}