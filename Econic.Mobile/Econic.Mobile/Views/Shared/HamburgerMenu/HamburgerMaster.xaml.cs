using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Shared.HamburgerMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HamburgerMaster : ContentPage
    {
        public ListView ListView;

        public HamburgerMaster()
        {
            InitializeComponent();

            BindingContext = new HamburgerMasterViewModel();
            ListView = MenuItemsListView;
        }

        class HamburgerMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<HamburgerMasterMenuItem> MenuItems { get; set; }

            public HamburgerMasterViewModel()
            {
                MenuItems = new ObservableCollection<HamburgerMasterMenuItem>(new[]
                {
                    new HamburgerMasterMenuItem { Id = 0, Title = "My Dashboard", Icon = "icon_account", TargetType = typeof(Dashboard) },
                    new HamburgerMasterMenuItem { Id = 1, Title = "Settings", Icon = "icon_settings", TargetType = typeof(Settings) },
                    new HamburgerMasterMenuItem { Id = 2, Title = "Support", Icon = "icon_support", TargetType = typeof(Support) },
                    new HamburgerMasterMenuItem { Id = 3, Title = "Revyvv U", Icon = "icon_revyvvu", TargetType = typeof(RevyvvU) }
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}