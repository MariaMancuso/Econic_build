﻿using Econic.Mobile.Models;
using Econic.Mobile.Models.EmployeeModels;
using Econic.Mobile.Views.OwnerProfile;
using Econic.Mobile.Views.OwnerReg;
using Econic.Mobile.Views.Shared;
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
        DetailOrderModel _selectedOrder;
        BusinessLocationModel _selectedbusinesslocation;
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
        public DetailOrderModel OrderSelected
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("OrderSelected");
            }
        }
        public BusinessLocationModel BusinessLocationSelected
        {
            get { return _selectedbusinesslocation; }
            set
            {
                _selectedbusinesslocation = value;
                OnPropertyChanged("CustomerSelected");
            }
        }
        public ItemModel CurrentItemModel { get; set; }
        public OwnerModel User { get; set; }

        public OwnerViewModel(OwnerModel _user)
        {
            User = _user;
            User.Employees = new ObservableCollection<PartyDetailsModel>();
            User.Customers = new ObservableCollection<CustomerPartyDetailsModel>();
            User.BusinessLocations = new ObservableCollection<BusinessLocationModel>();
            if(User.Account == null)
                User.Account = new Account();

            OpenPageCommand = new Command<string>((arg) => OpenPage(arg));
            AddEmployeeCommand = new Command(addEmployee);
            AddCustomerCommand = new Command(addCustomer);
            //CustomerTabCommand = new Command(customertabchanged);
            DayTappedCommand = new Command(dayTappedCommand);
            EditBusinessLocationCommand = new Command(editBusinessLocationCommand);
            RemoveClicked = new Command(removeClicked);
            EditClicked = new Command(editClicked);
            MenuItems = new ObservableCollection<HamburgerMasterMenuItem>(new[]
            {
                    new HamburgerMasterMenuItem { Id = 2, Title = "Support", Icon = "icon_support", TargetType = typeof(Support) },
                    new HamburgerMasterMenuItem { Id = 3, Title = "Revyvv U", Icon = "icon_revyvvu", TargetType = typeof(RevyvvU) }
            });
            addOrders();
        }

        public ContentView CurrentView { get; set; }
        public ICommand OpenPageCommand { private set; get; }
        public ICommand AddEmployeeCommand { private set; get; }
        public ICommand AddCustomerCommand { private set; get; }
       // public ICommand CustomerTabCommand { private set; get; }
        public ICommand DayTappedCommand { private set; get; }
        public ICommand EditBusinessLocationCommand { private set; get; }
        public ICommand RemoveClicked { private set; get; }
        public ICommand EditClicked { private set; get; }

        private async void editClicked(Object sender)
        {
            CurrentItemModel = sender as ItemModel;
            await Application.Current.MainPage.Navigation.PushAsync(new AddItem { BindingContext = this });
        }
        private void removeClicked(Object sender)
        {
            var item = sender as ItemModel;
            User.Items.Remove(item);
        }
        private async void OpenPage(string value)
        {
            switch (value)
            {
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
                        User.Employees.Remove(EmployeeSelected);
                        EmployeeSelected = null;
                    }

                    Application.Current.MainPage.Navigation.RemovePage(Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count - 2]);
                    await Application.Current.MainPage.Navigation.PopAsync();
                    break;
                case "NotifyMethod":
                    await Application.Current.MainPage.Navigation.PushAsync(new Notify() { BindingContext = this });
                    break;
                case "ViewCustomer":
                    await Application.Current.MainPage.Navigation.PushAsync(new ViewCustomer { BindingContext = this });
                    break;
                case "ViewOrder":
                    await Application.Current.MainPage.Navigation.PushAsync(new OrderView { BindingContext = this });
                    break;
                case "AddEditLocation":
                    BusinessLocationSelected = new BusinessLocationModel
                    {
                        Hours = new ObservableCollection<ScheduleModel>()
                        {
                            new ScheduleModel { Day = "Sunday" },
                            new ScheduleModel { Day = "Monday" },
                            new ScheduleModel { Day = "Tuesday" },
                            new ScheduleModel { Day = "Wednesday" },
                            new ScheduleModel { Day = "Thursday" },
                            new ScheduleModel { Day = "Friday" },
                            new ScheduleModel { Day = "Saturday" }
                        }
                    };
                    await Application.Current.MainPage.Navigation.PushAsync(new AddEditBusinessLocation { BindingContext = this });
                    break;
                case "SaveLocation":
                    if (BusinessLocationSelected != null && !User.BusinessLocations.Contains(BusinessLocationSelected))
                        User.BusinessLocations.Add(BusinessLocationSelected);
                    await Application.Current.MainPage.Navigation.PopAsync();
                    break;
                case "Payments":
                    await Application.Current.MainPage.Navigation.PushAsync(new PaymentMethod { BindingContext = this });
                    break;
                case "Privacy":
                    await Application.Current.MainPage.Navigation.PushAsync(new PrivacyAndSecurity { BindingContext = this });
                    break;
                case "Bankhelpinfo":
                    await Application.Current.MainPage.Navigation.PushAsync(new BankHelpInfo { BindingContext = this });
                    break;
                case "ContactDetail":
                    await Application.Current.MainPage.Navigation.PushAsync(new ContactDetails { BindingContext = this });
                    break;
                case "Languages":
                    await Application.Current.MainPage.Navigation.PushAsync(new LanguageList { BindingContext = this });
                    break;
                case "ContactView":
                    await Application.Current.MainPage.Navigation.PushAsync(new ContactView { BindingContext = this });
                    break;
                case "SaveContactDetail":
                    await Application.Current.MainPage.Navigation.PopAsync();
                    break;
                case "SharedPreview":
        
                    var page = new Hamburger { BindingContext = this };
                    //page.Master = new HamburgerMaster { BindingContext = model };
                    page.Detail = new NavigationPage(new OwnerTabbedPage
                    {
                        BindingContext = this,
                        BarBackgroundColor = Color.WhiteSmoke
                    })
                    {
                        BarBackgroundColor = Color.WhiteSmoke,
                        BackgroundColor = Color.WhiteSmoke
                    };
                    await Application.Current.MainPage.Navigation.PushAsync(page) ;
                    break;
                case "Preview":
                    if (CurrentItemModel != null && !User.Items.Contains(CurrentItemModel))
                        User.Items.Add(CurrentItemModel);

                    await Application.Current.MainPage.Navigation.PushAsync(new ProductsAndServices { BindingContext = this }); ;
                    break;
                case "AddAnother":
                    if (CurrentItemModel.Type == "Good")
                        CurrentItemModel = new ItemModel { Type = "Good" };
                    else
                        CurrentItemModel = new ItemModel { Type = "Service" };
                    await Application.Current.MainPage.Navigation.PushAsync(new AddItem { BindingContext = this });
                    break;
                default:
                    break;
            }
        }
       /* private void customertabchanged(Object sender)
        {
            var e = (ItemSelectionChangedEventArgs)sender;

            if(e.AddedItems.Contains("History"))
                CurrentView = new CustomerHistoryView { BindingContext = this };
            else 
                CurrentView = new CustomerDetailView { BindingContext = this };
        }*/
        public ScheduleModel CurrentItem { get; set; }
        ScheduleModel scheduleModel;
        private void dayTappedCommand(Object sender)
        {
            if (CurrentItem.Start != null && CurrentItem.End != null)
                CurrentItem.IsWorking = true;
            else
                CurrentItem.IsWorking = false;

            if (CurrentItem != null)
                CurrentItem.IsSelected = false;

            ScheduleModel model = sender as ScheduleModel;
            scheduleModel = model;
            CurrentItem = scheduleModel;
            CurrentItem.IsSelected = true;

            if (CurrentItem.Start != null && CurrentItem.End != null)
                CurrentItem.IsWorking = true;
            else
                CurrentItem.IsWorking = false;
        }
        private async void editBusinessLocationCommand(Object sender)
        {
            BusinessLocationSelected = sender as BusinessLocationModel;
            await Application.Current.MainPage.Navigation.PushAsync(new AddEditBusinessLocation { BindingContext = this });
        }
        private void addEmployee()
        {
            // add a temp employees
           for(int i=0; i<5; i++)
            {
                User.Employees.Add(new PartyDetailsModel
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
                    Schedule = new ObservableCollection<Models.EmployeeModels.ScheduleModel>()
                {
                    new Models.EmployeeModels.ScheduleModel() { Day = "Monday", Start = "8:30 AM", End = "3:30 PM" },
                    new Models.EmployeeModels.ScheduleModel() { Day = "Tuesday", Start = "8:30 AM", End = "3:30 PM" }
                }
                });
            }
        }
        private void addCustomer()
        {
            // add temp customers
            for(int i=0; i <5; i++)
            {
                User.Customers.Add(new CustomerPartyDetailsModel
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
                            status = true,
                            ImageSource = "productsamplepic.png",
                            ProductName = "Ziba Eyebrow Brush",
                            Price = 9

                        },
                        new SummaryOrderModel
                        {
                            OrderNumber = 12145,
                            OrderDate = DateTime.Now,
                            status = false,
                            ImageSource = "productsamplepic.png",
                            ProductName = "Usless Product",
                            Price = 18
                        }
                    }
                });
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
