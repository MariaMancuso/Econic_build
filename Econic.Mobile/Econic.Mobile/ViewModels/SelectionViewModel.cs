using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Econic.Mobile.ViewModels
{
    public class SelectionViewModel
    {
        public SelectionViewModel()
        {
            ItemTapped = new Command(itemTapped);
            Items = new ObservableCollection<string>();
        }

        public ObservableCollection<string> Items { get; set; }

        public ICommand ItemTapped { private set; get; }

        private void itemTapped(Object sender)
        {
            TapGestureRecognizer tapGesture = sender as TapGestureRecognizer;

            Frame frame = tapGesture.Parent as Frame;
            StackLayout stackLayout = frame.Children[0] as StackLayout;

            Label label = stackLayout.Children[1] as Label;

            if (Items.Contains(label.Text))
                Items.Remove(label.Text);
            else
                Items.Add(label.Text);

            frame.BackgroundColor = frame.BackgroundColor == Color.White ? Color.FromHex("#404040") : Color.White;
            label.TextColor = label.TextColor == Color.White ? Color.FromHex("#404040") : Color.White;
        }
    }
}
