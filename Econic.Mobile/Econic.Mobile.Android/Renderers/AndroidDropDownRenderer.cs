using System;
using System.ComponentModel;
using Android.Content;
using Android.Widget;

using Econic.Mobile.Droid.Renderers;
using Econic.Mobile.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomDropDown), typeof(AndroidDropDownRenderer))]
namespace Econic.Mobile.Droid.Renderers
{
    class AndroidDropDownRenderer : ViewRenderer<CustomDropDown, Spinner>
	{
		CustomDropDown element;
		Spinner spinner;
		public AndroidDropDownRenderer(Context context) : base(context) { }

		protected override void OnElementChanged(ElementChangedEventArgs<CustomDropDown> e)
		{
			base.OnElementChanged(e);

			//element = (CustomDropDown)this.Element;

			if (Control == null)
			{
				//Control.Background = AddPickerStyles(element.Image);
				spinner = new Spinner(Context);
				SetNativeControl(spinner);
			}

			if (e.OldElement != null)
			{
				Control.ItemSelected -= OnItemSelected;
			}

			if (e.NewElement != null)
			{
				var view = e.NewElement;
				ArrayAdapter adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleListItem1, view.ItemsSource);
				Control.Adapter = adapter;

				if (view.SelectedIndex != -1)
				{
					Control.SetSelection(view.SelectedIndex);
				}
				Control.ItemSelected += OnItemSelected;
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			var view = Element;
			if (e.PropertyName == CustomDropDown.ItemsSourceProperty.PropertyName)
			{
				ArrayAdapter adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleListItem1, view.ItemsSource);
				Control.Adapter = adapter;
			}

			if (e.PropertyName == CustomDropDown.SelectedIndexProperty.PropertyName)
			{
				Control.SetSelection(view.SelectedIndex);
			}
			base.OnElementPropertyChanged(sender, e);
		}

		private void OnItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			var view = Element;
			if (view != null)
			{
				view.SelectedIndex = e.Position;
				view.OnItemSelected(e.Position);
			}
		}

	
	}
}