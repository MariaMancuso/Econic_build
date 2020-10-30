using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace Econic.Mobile.Models.EmployeeModels
{
    [AddINotifyPropertyChangedInterface]
    public class ScheduleModel
    {
        public string Day { get; set; }
        public bool IsWorking { get; set; }
        public bool IsSelected { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }
}
