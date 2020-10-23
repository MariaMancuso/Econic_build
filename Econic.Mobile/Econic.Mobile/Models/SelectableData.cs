using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace Econic.Mobile.Models
{
    [AddINotifyPropertyChangedInterface]
    public class ClassificationModel
    {
        public string Name { get; set; }
    }
    public class NotifyModel
    {
        public string Name { get; set; }
    }
}
