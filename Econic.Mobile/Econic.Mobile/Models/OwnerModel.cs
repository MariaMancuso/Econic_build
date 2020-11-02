﻿using Econic.Mobile.Models.EmployeeModels;
using Econic.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public string Service { get; set; }
        public string Good { get; set; }
        public AddressModel Address { get; set; }
        public string BusinessNumber { get; set; }
        public string Title { get; set; }
        public int MonthlySales { get; set; }
        public string ServiceArea { get; set; }
        public ObservableCollection<OwnerGoalModel> Goals { get; set; }
        public ObservableCollection<ClassificationModel> Classifications { get; set; }
        public ObservableCollection<ItemModel> Items { get; set; }
        public ObservableCollection<NotifyModel> NotifyMethods { get; set; }
        public InviteMessageModel InviteMessages { get; set; }
        public ObservableCollection<PartyDetailsModel> Employees { get; set; }
        public ObservableCollection<CustomerPartyDetailsModel> Customers { get; set; }
        public bool HasEmployees { get; set; }
        public Account Account { get; set; }
        public ObservableCollection<DetailOrderModel> Orders { get; set; }
        public ObservableCollection<BusinessLocationModel> BusinessLocations { get; set; }
    }
}
