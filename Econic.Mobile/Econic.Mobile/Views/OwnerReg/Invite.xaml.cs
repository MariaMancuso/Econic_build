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
    public partial class Invite : ContentPage
    {
        public Invite(OwnerViewModel OwnerVM)
        {
            InitializeComponent();
            BindingContext = OwnerVM;
        }
        void OnCheckedChanged(object sender, CheckedChangedEventArgs args)
        {
            messageContent.InputTransparent = !messageContent.InputTransparent;
            messageContent.Opacity = messageContent.Opacity == 1 ? 0.3 : 1;
        }
    }
}