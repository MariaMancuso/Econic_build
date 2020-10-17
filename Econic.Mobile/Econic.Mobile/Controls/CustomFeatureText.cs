using Xamarin.Forms;

namespace Econic.Mobile.Controls
{
	public class CustomFeatureText : ContentView
	{
		public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create(nameof(HeaderText), typeof(string), typeof(CustomFeatureText), default(string));

		public string HeaderText
		{
			get => (string)GetValue(HeaderTextProperty);
			set => SetValue(HeaderTextProperty, value);
		}
	}
}
