using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Econic.Mobile.Renderers
{
    public class CustomDropDown : View
    {
		public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Image), typeof(string), typeof(CustomDropDown), string.Empty);
		public static readonly BindableProperty FieldTextProperty = BindableProperty.Create(nameof(FieldText), typeof(string), typeof(CustomDropDown), string.Empty);
		public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(List<string>), typeof(List<string>), defaultValue: null);
		public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(int), defaultValue: -1);
		public string Image
		{
			get { return (string)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value); }
		}

		public string FieldText 
		{ 
			get { return (string)GetValue(FieldTextProperty); }
			set { SetValue(FieldTextProperty, value); }
		}

		public List<string> ItemsSource
		{
			get { return (List<string>)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}
		public int SelectedIndex
		{

			get { return (int)GetValue(SelectedIndexProperty); }
			set { SetValue(SelectedIndexProperty, value); }
		}

		public event EventHandler<ItemSelectedEventArgs> ItemSelected;

		public void OnItemSelected(int pos)
		{
			ItemSelected?.Invoke(this, new ItemSelectedEventArgs() { SelectedIndex = pos });
		}

	}

	public class ItemSelectedEventArgs : EventArgs
	{
		public int SelectedIndex { get; set; }
	}
}
