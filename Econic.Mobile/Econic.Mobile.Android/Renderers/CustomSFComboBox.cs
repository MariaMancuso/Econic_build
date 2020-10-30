using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Econic.Mobile.Droid.Renderers;
using Econic.Mobile.Renderers;
using Syncfusion.XForms.Android.ComboBox;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomClass), typeof(CustomSFComboBox))]
namespace Econic.Mobile.Droid.Renderers
{
    class CustomSFComboBox : SfComboBoxRenderer
    {
        public CustomSFComboBox(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Syncfusion.XForms.ComboBox.SfComboBox> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(Android.Graphics.Color.White);
                gd.SetCornerRadius(12);
                gd.SetStroke(2, Android.Graphics.Color.LightGray);
                this.Control.SetBackgroundDrawable(gd);
            }
        }
    }
}