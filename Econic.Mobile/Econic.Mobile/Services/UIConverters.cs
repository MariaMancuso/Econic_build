using Syncfusion.ListView.XForms;
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
	public class DayLabelConverter : IValueConverter
	{

		#region IValueConverter implementation

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				if (!(Boolean)value)
					return Color.FromHex("#4c6d7e");
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
	public class DayBorderConverter : IValueConverter
	{

		#region IValueConverter implementation

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				if ((Boolean)value)
					return Color.FromHex("#4c6d7e");
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
	public class DayBackgroundConverter : IValueConverter
	{

		#region IValueConverter implementation

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				if (!(Boolean)value)
					return Color.FromHex("#e3e3e3");
				else
					return Color.FromHex("#4c6d7e");
			}
			return Color.Black;
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
	public class IsStringNullorEmpty : IValueConverter
	{

		#region IValueConverter implementation

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if ((value is string) == false)
				return false;
			else
            {
				string returnValue = (value as string);

				if (returnValue != "")
					return true;
				else
					return false;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
	public class PhoneNumConverter : IValueConverter
	{

		#region IValueConverter implementation

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if ((value is string) == false)
			{
				throw new ArgumentNullException("value should be string type");
			}

			string returnValue = (value as string);

			returnValue = returnValue[0] + " (***) *** **" + returnValue[returnValue.Length - 2] + returnValue[returnValue.Length - 1];

			return returnValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
	public class FrameBorderColorConverter : IValueConverter
	{

		#region IValueConverter implementation

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				if ((Boolean)value)
					return Color.FromHex("#404040");
				else
					return Color.LightGray;
			}
			return Color.White;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
	public class FrameBackgroundColorConverter : IValueConverter
	{

		#region IValueConverter implementation

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				if ((Boolean)value)
					return Color.White;
				else
					return Color.WhiteSmoke;
			}
			return Color.White;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
