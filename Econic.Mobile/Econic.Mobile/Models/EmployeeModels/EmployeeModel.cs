using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Econic.Mobile.Models.EmployeeModels
{
    public class EmployeeModel
    {
        public ObservableCollection<EmployeeSpecialitiesModel> EmployeeSpecialities { get; set; }
        public ObservableCollection<ScheduleModel> EmployeeSchedules { get; set; }
        public ObservableCollection<DetailOrderModel> Orders { get; set; }
    }
}
