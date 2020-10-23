using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econic.Mobile.Views.Shared.HamburgerMenu
{

    public class HamburgerMasterMenuItem
    {
        public HamburgerMasterMenuItem()
        {
            TargetType = typeof(HamburgerMasterMenuItem);
        }
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}