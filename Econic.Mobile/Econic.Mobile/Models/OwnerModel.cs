﻿using Econic.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Econic.Mobile.Models
{
    public class OwnerModel
    {
        public OwnerModel()
        {

        }
        public string BusinessName { get; set; }
        public string Product { get; set; }
        public string Service { get; set; }
        public AddressModel Address { get; set; }
        public int MonthlySales { get; set; }
        public string ServiceArea { get; set; }
        public List<OwnerGoalModel> Goals { get; set; }
        public List<SelectableData<ClassificationModel>> Classifications { get; set; }
        public List<ItemModel> Items { get; set; }
        public List<SelectableData<NotifyModel>> NotifyMethods { get; set; }
        public InviteMessageModel InviteMessages { get; set; }
        public bool HasEmployees { get; set; }
    }
}
