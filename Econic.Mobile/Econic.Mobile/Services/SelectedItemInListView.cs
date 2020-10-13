using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;


namespace Econic.Mobile.Services
{
	public class LabelConverter : IValueConverter
	{

		#region IValueConverter implementation

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				if ((Boolean)value)
					return Color.FromHex("#404040");
				else
					return Color.White;
			}
			return Color.Black;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}

	public class BackgroundConverter : IValueConverter
	{

		#region IValueConverter implementation

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				if ((Boolean)value)
					return Color.White;
				else
					return Color.FromHex("#404040");
			}
			return Color.White;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
	public class NoWhiteSpaceTextConverter : IValueConverter
	{

		#region IValueConverter implementation

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if ((value is string) == false)
			{
				throw new ArgumentNullException("value should be string type");
			}

			string returnValue = (value as string);

			return Regex.Replace(returnValue, @"\s+", "");
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
