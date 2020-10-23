using System;
using System.ComponentModel;
using Android.Content;
using Econic.Mobile.Droid.Renderers;
using Econic.Mobile.Renderers;
using Xamarin.Forms;
using Syncfusion.XForms.Android.ComboBox;
using Xamarin.Forms.Platform.Android;
using Syncfusion.XForms.ComboBox;

[assembly: ExportRenderer(typeof(CustomDropDown), typeof(AndroidDropDownRenderer))]
namespace Econic.Mobile.Droid.Renderers
{
    class AndroidDropDownRenderer : SfComboBoxRenderer
	{

		public AndroidDropDownRenderer(Context context) : base(context) 
		{ 
			
		}
        protected override void OnElementChanged(ElementChangedEventArgs<SfComboBox> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
        }
    }
}