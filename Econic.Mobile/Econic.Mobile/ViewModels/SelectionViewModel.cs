using Econic.Mobile.Models;
using Econic.Mobile.ViewModel;
using System;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Econic.Mobile.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class SelectionViewModel<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SelectionViewModel(ObservableCollection<SelectableData<T>> items)
        {
            Items = items;
        }

        public ObservableCollection<SelectableData<T>> Items { get; set; }

        SelectableData<T> _selectedItem { get; set; }

        public SelectableData<T> SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                _selectedItem.Selected = !_selectedItem.Selected;

                _selectedItem = null;
            }
        }
    }
}
