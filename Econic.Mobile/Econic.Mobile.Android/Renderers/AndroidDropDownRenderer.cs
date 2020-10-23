using System;
using System.ComponentModel;
using Android.Content;
using Econic.Mobile.Droid.Renderers;
using Econic.Mobile.Renderers;
using Xamarin.Forms;
using Syncfusion.XForms.Android.ComboBox;
using Xamarin.Forms.Platform.Android;
using Android.OS;
using Android.Graphics.Drawables.Shapes;
using Android.App;

using Syncfusion.XForms.ComboBox;
using Android.Widget;

[assembly: ExportRenderer(typeof(CustomDropDown), typeof(AndroidDropDownRenderer))]
namespace Econic.Mobile.Droid.Renderers
{
    class AndroidDropDownRenderer : CustomDropDown
	{

		//CustomDropDown element;
		//Spinner spinner;
		//public AndroidDropDownRenderer(Context context) : base(context){ }

		//protected override void OnElementChanged(ElementChangedEventArgs<CustomDropDown> e)
		//{
		//	base.OnElementChanged(e);

		//	//element = (CustomDropDown)this.Element;
			
		//	if (Control == null)
		//	{
		//		spinner = new Spinner(Context);
		//		LayoutParams layout = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
		//		spinner.LayoutParameters = layout;
		//		spinner.SetClipToPadding(true);
		//		var width = layout.Width;
		//		spinner.DropDownWidth = width;
		//		spinner.DropDownVerticalOffset = 130;
		//		Java.Lang.Reflect.Field popup = spinner.Class.GetDeclaredField("mPopup");
		//		popup.Accessible = true;
		//		var popupWindow = (ListPopupWindow)popup.Get(spinner);
		//		popupWindow.Height = 500;

		//		SetNativeControl(spinner);
		//	}

		//	if (e.OldElement != null)
		//	{
		//		Control.ItemSelected -= OnItemSelected;
		//	}

		//	if (e.NewElement != null)
		//	{
		//		var view = e.NewElement;
		//		ArrayAdapter adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleListItem1, view.ItemsSource);
		//		Control.Adapter = adapter;

		//		if (view.SelectedIndex != -1)
		//		{
		//			Control.SetSelection(view.SelectedIndex);
		//		}
		//		Control.ItemSelected += OnItemSelected;
				
		//	}
		//}

		//protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		//{
		//	var view = Element;
		//	if (e.PropertyName == CustomDropDown.ItemsSourceProperty.PropertyName)
		//	{
		//		ArrayAdapter adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleListItem1, view.ItemsSource);	
		//		Control.Adapter = (Syncfusion.Android.ComboBox.ComboBoxAdapter)adapter;
		//	}

		//	if (e.PropertyName == CustomDropDown.SelectedIndexProperty.PropertyName)
		//	{
		//		Control.SetSelection(view.SelectedIndex);
		//	}
		//	base.OnElementPropertyChanged(sender, e);
		//}

		//private void OnItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		//{
		//	var view = Element;
		//	if (view != null && view.SelectedIndex != 0)
		//	{
		//		view.SelectedIndex = e.Position;
		//		view.OnItemSelected(e.Position);
		//	}
		//}
	//}


	//	public AndroidDropDownRenderer(Context context) : base(context) 
	//	{ 
			
	//	}
 //       protected override void OnElementChanged(ElementChangedEventArgs<SfComboBox> e)
 //       {
 //           base.OnElementChanged(e);
 //           if (Control != null)
 //               Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
 //       }
    }

}