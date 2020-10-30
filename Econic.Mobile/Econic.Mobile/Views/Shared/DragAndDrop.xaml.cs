using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.OwnerReg;
using Syncfusion.DataSource.Extensions;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DragAndDrop : ContentPage
    {
        public DragAndDrop()
        {
            InitializeComponent();

        }
        /*private void ListView_ItemDraggingAsync(object sender, ItemDraggingEventArgs e)
        {
            if (e.Action == DragAction.Drop)
            {
                if (e.OldIndex < e.NewIndex)
                {
                    ChangeData(e);
                }
            }
        }

        private void ChangeData(ItemDraggingEventArgs e)
        {
            EmployeeBoardingViewModel model = BindingContext as EmployeeBoardingViewModel;
            model.Goals.MoveTo(e.OldIndex, e.NewIndex);
            for (int i = 0; i < model.Goals.Count; i++)
            {
                model.Goals[i].Value = i;
            }
        }*/
    }
}