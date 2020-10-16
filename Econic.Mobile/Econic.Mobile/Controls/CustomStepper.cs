
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Controls
{
	public class CustomStepper : StackLayout
	{
		public static readonly BindableProperty TextProperty = BindableProperty.Create(propertyName: "Text", returnType: typeof(int), declaringType:(typeof(CustomStepper)), defaultValue: 1);
		
		public int Text
		{
			get { return (int)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		public CustomStepper()
		{
			Button PlusBttn = new Button
			{
				Text = "+",
				Padding = new Thickness(0, 0, 0, 0),
				WidthRequest = 31,
				HeightRequest = 35,
				FontSize = 20,
				BackgroundColor = (Color)Application.Current.Resources["ThemeColor"],
				TextColor = Color.White
			};
			//PlusBttn.SetBinding(Button.CommandParameterProperty, PlusBttn_Clicked);

			Button MinusBttn = new Button
			{
				Text = "-",
				Padding = new Thickness(0, 0, 0, 0),
				WidthRequest = 31,
				HeightRequest = 35,
				FontSize = 20,
				BackgroundColor = (Color)Application.Current.Resources["ThemeColor"],
				TextColor = Color.White
			};

			Orientation = StackOrientation.Horizontal;
			PlusBttn.Clicked += PlusBttn_Clicked;
			MinusBttn.Clicked += MinusBttn_Clicked;
			Spacing = -1;

			Label label = new Label
			{
				WidthRequest = 31,
				HeightRequest = 35,
				Padding = new Thickness(0,0,0,0),
				BackgroundColor = (Color)Application.Current.Resources["ThemeColor"],
				TextColor = Color.White,
				Text = "1"
			};
			label.SetBinding(Label.TextProperty, new Binding("Text"));

			Children.Add(MinusBttn);
			Children.Add(label);
			Children.Add(PlusBttn);
		}

		private void PlusBttn_Clicked(object sender, EventArgs e)
		{
			Console.WriteLine("Plus button clicked");
			Text++;
		}

		private void MinusBttn_Clicked(object sender, EventArgs e)
		{
			Console.WriteLine("Minus button clicked");
			if (Text > 1)
			{
				Text--;
			}
			else
			{
				Text = 1;
			}	
		}
	}
}
