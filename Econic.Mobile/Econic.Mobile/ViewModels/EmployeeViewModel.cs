using Econic.Mobile.Models;
using Econic.Mobile.Models.EmployeeModels;
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

        public EmployeeViewModel(EmployeeModel employee)
        {
            User = employee;
            MenuItems = new ObservableCollection<HamburgerMasterMenuItem>(new[]
            {
                    new HamburgerMasterMenuItem { Id = 0, Title = "My Dashboard", Icon = "icon_account", TargetType = typeof(Dashboard) },
                    new HamburgerMasterMenuItem { Id = 1, Title = "Settings", Icon = "icon_settings", TargetType = typeof(Settings) },
                    new HamburgerMasterMenuItem { Id = 2, Title = "Support", Icon = "icon_support", TargetType = typeof(Support) },
                    new HamburgerMasterMenuItem { Id = 3, Title = "Revyvv U", Icon = "icon_revyvvu", TargetType = typeof(RevyvvU) }
            });
            OpenPageCommand = new Command<string>((arg) => OpenPage(arg));
            addOrders();
        }
        public EmployeeModel User { get; set; }
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
        private void addOrders()
        {
            User.Orders = new ObservableCollection<DetailOrderModel>()
            {
                new DetailOrderModel
                {
                    Items = new ObservableCollection<Item>
                    {
                        new Item { Name = "Multi-Touch Brushes", Count = 2, Price = 38},
                        new Item { Name = "Brush Collection", Count = 1, Price = 19}
                    },
                    CustomerName = "John Doe fullfilled",
                    CustomerEmail = "JohnDoes@empr.co",
                    CustomerNumber = 8988997863,
                    OrderDate = DateTime.Now,
                    OrderNumber = 12345,
                    status = true,
                    PaymentVerified = true,
                    ShippingAddress = new AddressModel
                    {
                        Address1 = "300 N Akard St.",
                        Address2 = "Unit 802",
                        City = "Dallas",
                        State = "Texas",
                        Zip = 753201
                    },
                    Type = "Shipping",
                    Tax = 6,
                    Total = 68
                },
                new DetailOrderModel
                {
                    Items = new ObservableCollection<Item>
                    {
                        new Item { Name = "Multi-Touch Brushes", Count = 2, Price = 38},
                        new Item { Name = "Brush Collection", Count = 1, Price = 19}
                    },
                    CustomerName = "John Doe",
                    CustomerEmail = "JohnDoes@empr.co",
                    CustomerNumber = 8988997863,
                    OrderDate = DateTime.Now,
                    OrderNumber = 19905,
                    status = false,
                    PaymentVerified = false,
                    ShippingAddress = new AddressModel
                    {
                        Address1 = "300 N Akard St.",
                        Address2 = "Unit 802",
                        City = "Dallas",
                        State = "Texas",
                        Zip = 753201
                    },
                    Type = "In Store Pick up",
                    Tax = 6,
                    Total = 68
                }
            };
        }
    }
}
