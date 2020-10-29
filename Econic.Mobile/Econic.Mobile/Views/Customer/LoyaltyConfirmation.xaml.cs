using Econic.Mobile.Views.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.ProgressBar;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Dynamic;

namespace Econic.Mobile.Views.Customer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoyaltyConfirmation : ContentPage
	{
		List<string> list = new List<string>();

		ControlTemplate tabbed = new ControlTemplate(typeof(TabbedView));
		ControlTemplate history = new ControlTemplate(typeof(LoyaltyHistory));
		ControlTemplate settings = new ControlTemplate(typeof(CustomerSettings));
		ControlTemplate mainstreet = new ControlTemplate(typeof(MainStreet));
		ControlTemplate badges = new ControlTemplate(typeof(Badges));
		public LoyaltyConfirmation()
		{
			InitializeComponent();
			TabbedView.ControlTemplate = tabbed;
			CreateProgressBar();

			list.Add("Loyalty");
			list.Add("History");
			list.Add("Settings");


			CreateSegmentedControl();
			History(false);
			Settings(false);
			MainStreet(false);
			Badges(false);
			Points(true);
		}

		private void Points_Tapped(object sender, EventArgs e)
		{
			StreetView.ControlTemplate = mainstreet;
			Points(false);
			History(false);
			Settings(false);
			Badges(false);
			MainStreet(true);
		}

		private void blackFriday_Tapped(object sender, EventArgs e)
		{
			BadgeView.ControlTemplate = badges;
			Points(false);
			History(false);
			Settings(false);
			MainStreet(false);
			Badges(true);
		}

		private void Token_Tapped(object sender, EventArgs e)
		{

		}

		private void CreateProgressBar() 
		{
			// Create StepProgressBar control
			stepProgressBar.Orientation = StepOrientation.Horizontal;
			stepProgressBar.VerticalOptions = LayoutOptions.Center;

			//Completed Style
			stepProgressBar.CompletedStepStyle.MarkerContentFillColor = Color.Black;
			stepProgressBar.CompletedStepStyle.MarkerContentType = StepContentType.None;

			//InProgress
			stepProgressBar.InProgressStepStyle.MarkerStrokeColor = Color.Black;
			stepProgressBar.InProgressStepStyle.MarkerStrokeWidth = 1;
			stepProgressBar.InProgressStepStyle.MarkerContentFillColor = Color.Transparent;
			stepProgressBar.InProgressStepStyle.MarkerContentType = StepContentType.None;

			//Not Started
			stepProgressBar.NotStartedStepStyle.MarkerStrokeColor = Color.Black;
			stepProgressBar.NotStartedStepStyle.MarkerStrokeWidth = 1;
			stepProgressBar.NotStartedStepStyle.MarkerContentFillColor = Color.Transparent;
			stepProgressBar.NotStartedStepStyle.MarkerContentType = StepContentType.None;

			int maxNum = 1000;
			int totalPoints = 536;
			var rangeNum = maxNum / 250;
			rangeNum = rangeNum + 1;

			for(int i = 0; i < rangeNum; i++)
			{
				var num = maxNum / (rangeNum - 1) * (i + 1);
				if (num == maxNum)
				{
					stepProgressBar.Children.Add(new StepView()
					{
						PrimaryText = maxNum.ToString(),
						ImageSource = "img_token_yellow.png"
					});
				}
				else
				{
					if(i == 0)
					{
						stepProgressBar.Children.Add(new StepView() { PrimaryText = "0" });
					}

					

					if(num > maxNum)
					{
						goto End;
					}

						stepProgressBar.Children.Add(new StepView() { PrimaryText = num.ToString() });
				}
				
			} End:;
			
		}

		private void CreateSegmentedControl()
		{
			SelectionIndicatorSettings selectionIndicator = new SelectionIndicatorSettings();
			selectionIndicator.Position = SelectionIndicatorPosition.Bottom;
			segControl.SelectionIndicatorSettings = selectionIndicator;
			segControl.SelectionChanged += SegControl_SelectionChanged;
			segControl.FontColor = Color.FromHex("#343434");
			segControl.SelectionTextColor = Color.Black;
			segControl.SelectedIndex = 0;
			segControl.FontSize = 16;
			segControl.BorderColor = Color.Transparent;
			segControl.BackgroundColor = Color.Transparent;
			segControl.DisplayMode = SegmentDisplayMode.Text;
			segControl.ItemsSource = list;

		}

		private void SegControl_SelectionChanged(object sender, Syncfusion.XForms.Buttons.SelectionChangedEventArgs e)
		{
			var name = list[e.Index];
			Console.WriteLine(name);
			if(name.Equals("History"))
			{
				Points(false);
				Settings(false);
				MainStreet(false);
				Badges(false);
				History(true);
				HistoryView.ControlTemplate = history;
				
			}

			if (name.Equals("Loyalty"))
			{
				Points(true);
				History(false);
				Settings(false);
				MainStreet(false);
				Badges(false);
			}

			if (name.Equals("Settings"))
			{
				Points(false);
				History(false);
				Settings(true);
				MainStreet(false);
				Badges(false);

				SettingsView.ControlTemplate = settings;
			}
		}

		private void Points(bool visible)
		{
			PointsLayout.IsVisible = visible;
			PointsLayout.IsEnabled = visible;
		}

		private void History(bool visible)
		{
			HistoryLayout.IsVisible = visible;
			HistoryLayout.IsEnabled = visible;
		}

		private void Settings(bool visible)
		{
			SettingsLayout.IsVisible = visible;
			SettingsLayout.IsEnabled = visible;
		}

		private void MainStreet(bool visible)
		{
			StreetLayout.IsVisible = visible;
			StreetLayout.IsEnabled = visible;
		}

		private void Badges(bool visible)
		{
			BadgeLayout.IsVisible = visible;
			BadgeLayout.IsEnabled = visible;
		}
	}
}