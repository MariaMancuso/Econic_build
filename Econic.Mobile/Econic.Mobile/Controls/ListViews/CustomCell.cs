using Xamarin.Forms;
using Econic.Mobile.ViewModels;
using Econic.Mobile.Models;

namespace Econic.Mobile.Controls.ListViews
{
	public class ListButton : Button { }
	class CustomCell : ViewCell
	{
		public CustomCell()
		{
				var frame = new Frame
				{
					HeightRequest = 75,
					WidthRequest = 75
				};

				var label1 = new Label
				{
					Text = "Label 1",
					FontAttributes = FontAttributes.Bold,
					FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
				};
				label1.SetBinding(Label.TextProperty, new Binding("Name"));

				var label2 = new Label
				{
					Text = "Label 2",
					FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
					HorizontalOptions = LayoutOptions.EndAndExpand
				};
				label2.SetBinding(Label.TextProperty, new Binding("ServiceType"));

			var button = new ListButton
			{
				Text = "Book",
				WidthRequest = 90,
				HeightRequest = 37,
				TextColor = Color.FromHex("#517486"),
				BackgroundColor = Color.FromHex("#dfecf2"),
				HorizontalOptions = LayoutOptions.EndAndExpand,
				CornerRadius = 18,
			};

			button.SetBinding(Button.CommandParameterProperty, new Binding("."));
			View = new StackLayout
				{
					Orientation = StackOrientation.Horizontal,
					//HorizontalOptions = LayoutOptions.StartAndExpand,
					//Padding = new Thickness(15, 5, 15, 15),
					HeightRequest = 75,
					Children = {
						frame,
						new StackLayout{
							Orientation = StackOrientation.Vertical,
							Children = { label1, label2 }
						},
						button
					}

				};
		}
	}
}
