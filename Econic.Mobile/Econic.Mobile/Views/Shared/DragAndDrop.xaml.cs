using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using Econic.Mobile.Views.OwnerReg;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DragAndDrop : ContentPage
    {
        ObservableCollection<OwnerGoalModel> Goals;
        public DragAndDrop()
        {
            InitializeComponent();

            Goals = new ObservableCollection<OwnerGoalModel>()
                {
                new OwnerGoalModel() { Goal = "Connect you to your customers", Value = 1},
                new OwnerGoalModel() { Goal = "Increate your profibility", Value = 2},
                new OwnerGoalModel() { Goal = "Identify your best products and service - every day", Value = 3},
                new OwnerGoalModel() { Goal = "Identify and reward your most loyal customers", Value = 4},
                new OwnerGoalModel() { Goal = "Lower your transactions costs", Value = 5}
                };

            listView.ItemsSource = Goals;
        }
    }
}