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
		ControlTemplate tabbed = new ControlTemplate(typeof(TabbedView));
		public LoyaltyConfirmation()
		{
			InitializeComponent();
			TabbedView.ControlTemplate = tabbed;
			CreateProgressBar();
			CreateSegmentedControl();
		}

		private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
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
			List<string> list = new List<string>();
			list.Add("Loyalty");
			list.Add("History");
			list.Add("Setting");



		}
	}
}