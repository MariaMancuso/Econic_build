using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Syncfusion.SfRating.XForms;

namespace Econic.Mobile.Controls.ListViews
{
	class CustomFPCell : ViewCell
	{
		public CustomFPCell()
		{
			var frame = new Frame()
			{ 
				HeightRequest = 141,
				WidthRequest = 141
			};

			var rating = new SfRating() 
			{ 
				ItemCount = 5,
				Value = 5,
				ItemSize = 10,
			};
			rating.SetBinding(SfRatingItem.AutomationIdProperty, new Binding("Rating"));

			var label2 = new Label
			{
				Text = "Name",
				FontAttributes = FontAttributes.Bold
			};
			label2.SetBinding(Label.TextProperty, new Binding("Name"));

			var label3 = new Label
			{
				Text = "Price",
				FontAttributes = FontAttributes.None
			};
			label3.SetBinding(Label.TextProperty, new Binding("Price"));

			View = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.StartAndExpand,
				//Padding = new Thickness(15, 5, 15, 15),
				Children = {
					new StackLayout
					{
						//Rotation = 270,
						Orientation = StackOrientation.Vertical,
						Children =
						{
							frame,
							rating,
							label2,
							label3
						}

					}
				}

			};
		}
	}
}
