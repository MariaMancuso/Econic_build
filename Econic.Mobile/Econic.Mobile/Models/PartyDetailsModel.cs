 using Econic.Mobile.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Econic.Mobile.Models
{
    public class PartyDetailsModel
    {
        public string Name { get; set; }
        public string PartyType { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public long Number { get; set; }
        public int CountryCode { get; set; }
        public AddressModel Address { get; set; }
        public ObservableCollection<EmployeeScheduleModel> Schedule { get; set; }
    }
}
