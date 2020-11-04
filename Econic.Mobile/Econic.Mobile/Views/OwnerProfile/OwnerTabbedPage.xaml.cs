using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.OwnerProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OwnerTabbedPage : Renderers.CustomTabbedPage
    {
        public OwnerTabbedPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}