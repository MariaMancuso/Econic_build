using Econic.Mobile.Models;
using Econic.Mobile.Views.OwnerProfile;
using Econic.Mobile.Views.Shared.HamburgerMenu;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Econic.Mobile.ViewModels
{
    public class OwnerViewModel : ViewModel.BaseVM
    {
        public ObservableCollection<HamburgerMasterMenuItem> MenuItems { get; set; }

        PartyDetailsModel _selectedEmployee;
        CustomerPartyDetailsModel _selectedCustomer;
        public PartyDetailsModel EmployeeSelected
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged("EmployeeSelected");
            }
        }
        public CustomerPartyDetailsModel CustomerSelected
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged("CustomerSelected");
            }
        }
        public OwnerModel Owner { get; set; }

        public OwnerViewModel()
        {
            Owner = new OwnerModel()
            {
                Employees = new ObservableCollection<PartyDetailsModel>(),
                Customers = new ObservableCollection<CustomerPartyDetailsModel>()
            };

            OpenPageCommand = new Command<string>((arg) => OpenPage(arg));
            AddEmployeeCommand = new Command(addEmployee);
            AddCustomerCommand = new Command(addCustomer);
            CustomerTabCommand = new Command(customertabchanged);
            MenuItems = new ObservableCollection<HamburgerMasterMenuItem>(new[]
            {
                    new HamburgerMasterMenuItem { Id = 2, Title = "Support", Icon = "icon_support", TargetType = typeof(Support) },
                    new HamburgerMasterMenuItem { Id = 3, Title = "Revyvv U", Icon = "icon_revyvvu", TargetType = typeof(RevyvvU) }
            });
            CurrentView = new CustomerHistoryView();
        }

        public ContentView CurrentView { get; set; }
        public ICommand OpenPageCommand { private set; get; }
        public ICommand AddEmployeeCommand { private set; get; }
        public ICommand AddCustomerCommand { private set; get; }
        public ICommand CustomerTabCommand { private set; get; }
        private async void OpenPage(string value)
        {
            switch (value)
            {
                case "QRcode":
                    await Application.Current.MainPage.Navigation.PushAsync(new QRCodes { BindingContext = this});
                    break;
                case "Settings":
                    await Application.Current.MainPage.Navigation.PushAsync(new Settings { BindingContext = this });
                    break;
                case "ViewEmployee":
                    await Task.Delay(5);
                    await Application.Current.MainPage.Navigation.PushAsync(new ViewEmployee { BindingContext = this });
                    break;
                case "EditEmployee":
                    await Application.Current.MainPage.Navigation.PushAsync(new EditEmployee { BindingContext = this });
                    break;
                case "SaveEmployee":
                    await Application.Current.MainPage.Navigation.PopAsync();
                    break;
                case "Message":
                    await Application.Current.MainPage.Navigation.PushAsync(new MessageBox { BindingContext = this });
                    break;
                case "RemoveEmployee":
                    if (EmployeeSelected != null)
                    {
                        Owner.Employees.Remove(EmployeeSelected);
                        EmployeeSelected = null;
                    }

                    Application.Current.MainPage.Navigation.RemovePage(Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count - 2]);
                    await Application.Current.MainPage.Navigation.PopAsync();
                    break;
                case "ViewCustomer":
                    await Application.Current.MainPage.Navigation.PushAsync(new ViewCustomer { BindingContext = this });
                    break;
                default:
                    break;
            }
        }
        private void customertabchanged(Object sender)
        {
            var e = (ItemSelectionChangedEventArgs)sender;
            if(e.AddedItems.Contains("History"))
                CurrentView = new CustomerHistoryView { BindingContext = this };
            else
                CurrentView = new CustomerDetailView { BindingContext = this };
        }
        private void addEmployee()
        {
            // add a temp employees
           for(int i=0; i<5; i++)
            {
                Owner.Employees.Add(new PartyDetailsModel
                {
                    Name = "John Doe Employee " + i,
                    Email = "johndoe@empr.co",
                    PartyType = "Part-time",
                    CountryCode = 1,
                    Number = 8009898393,
                    Title = "Sales rep",
                    Address = new AddressModel()
                    {
                        Address1 = "300 N Akard St.",
                        Address2 = "Unit 802",
                        City = "Dallas",
                        State = "Texas",
                        Zip = 753201
                    },
                    Schedule = new ObservableCollection<Models.EmployeeModels.EmployeeScheduleModel>()
                {
                    new Models.EmployeeModels.EmployeeScheduleModel() { Day = "Monday", Start = "8:30 AM", End = "3:30 PM" },
                    new Models.EmployeeModels.EmployeeScheduleModel() { Day = "Tuesday", Start = "8:30 AM", End = "3:30 PM" }
                }
                });
            }
        }
        private void addCustomer()
        {
            // add temp customers
            for(int i=0; i <5; i++)
            {
                Owner.Customers.Add(new CustomerPartyDetailsModel
                {
                    Name = Convert.ToChar(i + (int)'A') +" John Doe Customer " + i,
                    Email = "johndoe@empr.co",
                    CountryCode = 1,
                    Number = 8009898393,
                    ShippingAddress = new AddressModel()
                    {
                        Address1 = "300 N Akard St.",
                        Address2 = "Unit 802",
                        City = "Dallas",
                        State = "Texas",
                        Zip = 753201
                    },
                    Orders = new ObservableCollection<SummaryOrderModel>()
                    {
                        new SummaryOrderModel
                        {
                            OrderNumber = 12345,
                            OrderDate = DateTime.Now,
                            PaymentVerified = true, 
                            status = true,
                            ImageSource = "productsamplepic.png",
                            ProductName = "Ziba Eyebrow Brush",
                            Price = 9

                        },
                        new SummaryOrderModel
                        {
                            OrderNumber = 12145,
                            OrderDate = DateTime.Now,
                            PaymentVerified = false,
                            status = false,
                            ImageSource = "productsamplepic.png",
                            ProductName = "Usless Product",
                            Price = 18
                        }
                    }
                });
            }
        }
    }
}
