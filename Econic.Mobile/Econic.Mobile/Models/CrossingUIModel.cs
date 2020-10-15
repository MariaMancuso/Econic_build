using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Econic.Mobile.Models
{
    public class CrossingUIModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int Id { get; set; }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        string fieldValue;

        public string FieldValue
        {
            get
            {
                return fieldValue;
            }
            set
            {
                if (fieldValue != value)
                {
                    if (value.Length == 2)
                    {
                        if (value.Substring(0, 1) == fieldValue)
                            fieldValue = value.Substring(1, 1);
                        else
                            fieldValue = value.Substring(0, 1);
                    }
                    else
                        fieldValue = value;
                    OnPropertyChanged("FieldValue");
                }
            }
        }
        bool isFocus = false;
        public bool IsFocus
        {
            get
            {
                return isFocus;
            }
            set
            {
                if (isFocus != value)
                {
                    isFocus = value;
                    OnPropertyChanged("IsFocus");
                }
            }
        }
        bool isDisabled = true;
        public bool IsDisabled
        {
            get
            {
                return isDisabled;
            }
            set
            {
                if (isDisabled != value)
                {
                    isDisabled = value;
                    OnPropertyChanged("IsDisabled");
                }
            }
        }
    }
}
