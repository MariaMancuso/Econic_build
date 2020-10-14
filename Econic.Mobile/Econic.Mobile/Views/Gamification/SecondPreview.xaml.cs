using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Econic.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.OwnerReg
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPreview : ContentPage
    {
        public SecondPreview(OwnerViewModel OwnerVM)
        {
            InitializeComponent();
            BindingContext = OwnerVM;
            Initials.Text = OwnerVM?.GetInitials();
        }
    }
}