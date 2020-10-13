using Econic.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.OwnerReg
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Features : ContentPage
    {
        public Features(OwnerViewModel OwnerVM)
        {
            InitializeComponent();
            BindingContext = OwnerVM;
        }
    }
}