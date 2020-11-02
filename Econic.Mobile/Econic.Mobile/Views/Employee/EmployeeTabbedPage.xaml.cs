using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Employee
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeTabbedPage : Renderers.CustomTabbedPage
    {
        public EmployeeTabbedPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }

    }
}