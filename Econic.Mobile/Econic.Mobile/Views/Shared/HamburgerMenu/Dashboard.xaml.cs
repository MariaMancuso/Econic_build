using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Shared.HamburgerMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : TabbedPage
    {
        public Dashboard()
        {
            InitializeComponent();
			BindingContext = new StripLinesViewModel();

        }
    }
	public class StripLinesViewModel
	{
		public ObservableCollection<ChartDataModel> StripLineData { get; set; }

		public ObservableCollection<ChartDataModel> Data1 { get; set; }

		public StripLinesViewModel()
		{

			StripLineData = new ObservableCollection<ChartDataModel>
			{
				 new ChartDataModel { Name = "Jan", Value = 1},
				 new ChartDataModel { Name = "Feb", Value = 2},
				 new ChartDataModel { Name = "Mar", Value = 2.8},
				 new ChartDataModel { Name = "Apr", Value = 2},
				 new ChartDataModel { Name = "May", Value = 2.5},
				 new ChartDataModel { Name = "Jun", Value = 3},
			};

			Data1 = new ObservableCollection<ChartDataModel>
			{
				 new ChartDataModel { Name = "Jan", Value = 0},
				 new ChartDataModel { Name = "Feb", Value = 1},
				 new ChartDataModel { Name = "Mar", Value = 6},
			};
		}
	}
	public class ChartDataModel
    {
		public string Name { get; set; }
		public double Value { get; set; }
	}
}