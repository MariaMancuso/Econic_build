using Econic.Mobile.Models;
using Syncfusion.SfChart.XForms;
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
			BindingContext = new TempChartViewModel();
		}
    }
	public class TempChartViewModel : ViewModel.BaseVM
	{
		public ObservableCollection<ChartDataModel> Charts { get; set; }

		ChartDataModel _selectedChart;
		public ChartDataModel SelectedChart
		{
			get { return _selectedChart; }
			set
			{
				_selectedChart = value;
				OnPropertyChanged("SelectedChart");
			}
		}
		public TempChartViewModel()
		{
			Charts = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel
				{
					Name = "1 wk",
					Data = new ObservableCollection<ChartData>
                    {
						new ChartData { Name = "Mon", Value = 5},
						new ChartData { Name = "Tue", Value = 2},
						new ChartData { Name = "Wed", Value = 3.5},
						new ChartData { Name = "Thur", Value = 1},
						new ChartData { Name = "Fri", Value = 4.5},
						new ChartData { Name = "Sat", Value = 4},
						new ChartData { Name = "Sun", Value = 1.5}
					},
					Target = 4,
					Colors = new ObservableCollection<Color>()
				},
				new ChartDataModel
				{
					Name = "1m",
					Data = new ObservableCollection<ChartData>
					{
						new ChartData { Name = "Week 1", Value = 5},
						new ChartData { Name = "Week 2", Value = 2},
						new ChartData { Name = "Week 3", Value = 3.5},
						new ChartData { Name = "Week 4", Value = 1}
					},
					Target = 2,
					Colors = new ObservableCollection<Color>()
				},
				new ChartDataModel
				{
					Name = "3m",
					Data = new ObservableCollection<ChartData>
					{
						new ChartData { Name = "Apr", Value = 1},
						new ChartData { Name = "May", Value = 4.5},
						new ChartData { Name = "Jun", Value = 4}
					},
					Target = 3,
					Colors = new ObservableCollection<Color>()
				},
				new ChartDataModel
				{
					Name = "6m",
					Data = new ObservableCollection<ChartData>
					{
						new ChartData { Name = "Jan", Value = 5},
						new ChartData { Name = "Feb", Value = 2},
						new ChartData { Name = "Mar", Value = 3.5},
						new ChartData { Name = "Apr", Value = 1},
						new ChartData { Name = "May", Value = 4.5},
						new ChartData { Name = "Jun", Value = 4}
					},
					Target = 2.5,
					Colors = new ObservableCollection<Color>()
				},
				new ChartDataModel
				{
					Name = "1yr",
					Data = new ObservableCollection<ChartData>
					{
						new ChartData { Name = "Jul", Value = 1.1},
						new ChartData { Name = "Aug", Value = 3.7},
						new ChartData { Name = "Sep", Value = 3.5},
						new ChartData { Name = "Oct", Value = 2.7},
						new ChartData { Name = "Nov", Value = 4.5},
						new ChartData { Name = "Dec", Value = 4},
						new ChartData { Name = "Jan", Value = 5},
						new ChartData { Name = "Feb", Value = 2},
						new ChartData { Name = "Mar", Value = 3.5},
						new ChartData { Name = "Apr", Value = 1},
						new ChartData { Name = "May", Value = 4.5},
						new ChartData { Name = "Jun", Value = 4}
					},
					Target = 3,
					Colors = new ObservableCollection<Color>()
				},
			};


			foreach (var chart in Charts)
			{
				foreach(var v in chart.Data)
                {
					if (v.Value > chart.Target)
						chart.Colors.Add(Color.FromHex("#3E8F52"));
					else
						chart.Colors.Add(Color.FromHex("#D03737"));
				}
			}
			SelectedChart = Charts.First();
		}
	}
	public class ChartData
    {
		public string Name { get; set; }
		public double Value { get; set; }
	}
	public class ChartDataModel
	{
		public double Target { get; set; }
		public string Name { get; set; }
		public ObservableCollection<ChartData> Data { get; set; }
		public ObservableCollection<Color> Colors { get; set; }
	}
}