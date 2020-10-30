using Syncfusion.XForms.ComboBox;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Econic.Mobile.Renderers
{
    public class CustomClass : SfComboBox
    {
        public CustomClass()
        {
        }
        public static readonly BindableProperty CurvedCornerRadiusProperty =
    BindableProperty.Create(
        nameof(CurvedCornerRadius),
        typeof(double),
        typeof(CustomClass),
        12.0);
        public double CurvedCornerRadius
        {
            get { return (double)GetValue(CurvedCornerRadiusProperty); }
            set { SetValue(CurvedCornerRadiusProperty, value); }
        }


        public static readonly BindableProperty CurvedBackgroundColorProperty =
            BindableProperty.Create(
                nameof(CurvedBackgroundColor),
                typeof(Color),
                typeof(CustomClass),
                Color.Default);
        public Color CurvedBackgroundColor
        {
            get { return (Color)GetValue(CurvedBackgroundColorProperty); }
            set { SetValue(CurvedBackgroundColorProperty, value); }
        }
    }
}
