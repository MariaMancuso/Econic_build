using Econic.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Econic.Mobile.ViewModels
{
    public class SelectionViewModel<T>
    {
        public SelectionViewModel()
        {
            ClassificationTapped = new Command(classificationtapped);
        }
        public T Data { get; set; }
        public bool IsSelected { get; set; }

        public ICommand ClassificationTapped { get; set; }

        private void classificationtapped(Object sender)
        {
            var tgr = (TapGestureRecognizer)sender;
            var f = tgr.Parent as Frame;
            var sl = f.Children[0] as StackLayout;
            var l = sl.Children[1] as Label;

            IsSelected = !IsSelected;
            f.BackgroundColor = f.BackgroundColor == Color.White ? Color.FromHex("#404040") : Color.White;
            l.TextColor = l.TextColor == Color.White ? Color.FromHex("#404040") : Color.White;
        }
    }
}
