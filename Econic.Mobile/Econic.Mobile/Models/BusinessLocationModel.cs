using Econic.Mobile.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Econic.Mobile.Models
{
    public class BusinessLocationModel
    {
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public long Number { get; set; }
        public ObservableCollection<ScheduleModel> Hours { get; set; }
    }
}
