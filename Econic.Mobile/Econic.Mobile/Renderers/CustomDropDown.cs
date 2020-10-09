using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Econic.Mobile.Renderers
{
    public class CustomDropDown : Picker
    {
		public static readonly BindableProperty ImageProperty =
		BindableProperty.Create(nameof(Image), typeof(string), typeof(CustomDropDown), string.Empty);

		public string Image
		{
			get { return (string)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value); }
		}
	}
}
