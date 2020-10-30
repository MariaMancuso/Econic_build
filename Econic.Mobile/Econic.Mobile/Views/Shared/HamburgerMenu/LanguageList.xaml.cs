using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Shared.HamburgerMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguageList : ContentPage
    {
        public LanguageList()
        {
            InitializeComponent();
            langugelistview.ItemsSource = new ObservableCollection<Language>
            {
                new Language{ Name = "Use device Language", Detail = "English (United States)"},
                 new Language{ Name = "Dansk", Detail = "Danish"},
                 new Language{ Name = "Netherlands (Belgie)", Detail = "Dutch (Belgium)"},
                 new Language{ Name = "Netherlands (Netherland)", Detail = "Dutch (The Netherlands)"},
                 new Language{ Name = "English (Australia)", Detail = "English (Australia)"},
                 new Language{ Name = "English (Great Brittian)", Detail = "English (Great Brittian)"},
                 new Language{ Name = "English (Great America)", Detail = "English (Great America)"},
            };
        }
    }
    public class Language
    {
        public string Name { get; set; }
        public string Detail { get; set; }
    }
}