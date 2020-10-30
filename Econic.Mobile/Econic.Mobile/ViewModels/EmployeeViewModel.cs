using Econic.Mobile.Views.Shared.HamburgerMenu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Econic.Mobile.ViewModels
{
   public class EmployeeViewModel
    {
        public ObservableCollection<HamburgerMasterMenuItem> MenuItems { get; set; }

        public EmployeeViewModel()
        {
            MenuItems = new ObservableCollection<HamburgerMasterMenuItem>(new[]
            {
                    new HamburgerMasterMenuItem { Id = 0, Title = "My Dashboard", Icon = "icon_account", TargetType = typeof(Dashboard) },
                    new HamburgerMasterMenuItem { Id = 1, Title = "Settings", Icon = "icon_settings", TargetType = typeof(Settings) },
                    new HamburgerMasterMenuItem { Id = 2, Title = "Support", Icon = "icon_support", TargetType = typeof(Support) },
                    new HamburgerMasterMenuItem { Id = 3, Title = "Revyvv U", Icon = "icon_revyvvu", TargetType = typeof(RevyvvU) }
            });
            OpenPageCommand = new Command<string>((arg) => OpenPage(arg));
        }
        public ICommand OpenPageCommand { private set; get; }
        private async void OpenPage(string value)
        {
            switch (value)
            {
                case "Privacy":
                    await Application.Current.MainPage.Navigation.PushAsync(new PrivacyAndSecurity { BindingContext = this });
                    break;
                case "ContactDetails":
                    await Application.Current.MainPage.Navigation.PushAsync(new ContactDetails { BindingContext = this });
                    break;
                default:
                    break;
            }
        }
    }
}
