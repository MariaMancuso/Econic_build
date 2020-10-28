using Econic.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Shared.HamburgerMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
	{
        public Dashboard()
        {
            InitializeComponent();
			BindingContext = new StripLinesViewModel();
		}
    }
	public class StripLinesViewModel
	{
		public ObservableCollection<ChartDataModel> WholeData { get; set; }
		public ObservableCollection<ChartDataModel> GoodData { get; set; }
		public ObservableCollection<ChartDataModel> BadData { get; set; }

		public StripLinesViewModel()
		{

			GoodData = new ObservableCollection<ChartDataModel>
			{
				 new ChartDataModel { Name = "Jan", Value = 5, Target = 3},
				 new ChartDataModel { Name = "Feb", Value = 3, Target = 3},
				 new ChartDataModel { Name = "Mar", Value = 3.5, Target = 3},
				 new ChartDataModel { Name = "Apr", Value = 3, Target = 3},
				 new ChartDataModel { Name = "May", Value = 4.5, Target = 3},
				 new ChartDataModel { Name = "Jun", Value = 4, Target = 3},
			};
			BadData = new ObservableCollection<ChartDataModel>
			{
				 new ChartDataModel { Name = "Jan", Value = 3, Target = 3},
				 new ChartDataModel { Name = "Feb", Value = 2.1, Target = 3},
				 new ChartDataModel { Name = "Mar", Value = 3, Target = 3},
				 new ChartDataModel { Name = "Apr", Value = 2.5, Target = 3},
				 new ChartDataModel { Name = "May", Value = 3, Target = 3},
				 new ChartDataModel { Name = "Jun", Value = 3, Target = 3},
			};
		}
	}
	public class ChartDataModel
    {
		public string Name { get; set; }
		public double Value { get; set; }
		public double Target { get; set; }
	}
}