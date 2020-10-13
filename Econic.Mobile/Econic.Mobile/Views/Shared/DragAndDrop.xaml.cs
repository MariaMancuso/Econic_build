using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.OwnerReg;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DragAndDrop : ContentPage
    {
        public DragAndDrop(OwnerViewModel OwnerVM)
        {
            InitializeComponent();
            BindingContext = OwnerVM;
        }
    }
}