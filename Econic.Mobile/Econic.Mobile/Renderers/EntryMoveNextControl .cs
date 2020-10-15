using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Econic.Mobile.Renderers
{
    public class EntryMoveNextControl : Entry
    {
        public static readonly BindableProperty IsFocusProperty = BindableProperty.Create("IsFocus", typeof(bool), typeof(EntryMoveNextControl), false, propertyChanged: OnChanged);
        static void OnChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var entry = bindable as EntryMoveNextControl;

            var focus = (bool)newValue;

            if (focus)
            {
                entry.Focus();
            }
            else
            {
                entry.Unfocus();
            }

        }
        public bool IsFocus
        {
            get { return (bool)GetValue(IsFocusProperty); }
            set
            {
                SetValue(IsFocusProperty, value);
            }
        }
        public EntryMoveNextControl()
        {
            this.Focused += MyEntry_Focused;
            this.Unfocused += MyEntry_Unfocused;
        }
        private void MyEntry_Unfocused(object sender, FocusEventArgs e)
        {
            this.IsFocus = false;
        }

        private void MyEntry_Focused(object sender, FocusEventArgs e)
        {
            this.IsFocus = true;
        }

    }
}
