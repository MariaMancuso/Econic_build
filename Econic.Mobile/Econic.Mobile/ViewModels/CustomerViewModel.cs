﻿using Econic.Mobile.Views.Customer;
using Econic.Mobile.Views.OwnerReg;
using Econic.Mobile.Models;
using Econic.Mobile.Views.Shared;
using Econic.Mobile.Views.Shared.SplashScreens;
using System.Windows.Input;
using Xamarin.Forms;
using System.Dynamic;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using Econic.Mobile.Views.Shared.HamburgerMenu;

namespace Econic.Mobile.ViewModels
{
    public class CustomerViewModel
    {
        ObservableCollection <SummaryOrderModel> customerModel;
        public ObservableCollection<HamburgerMasterMenuItem> MenuItems { get; set; }
        public CustomerViewModel()
        {
            OpenPageCommand = new Command<string>((arg) => OpenPage(arg));
            MenuItems = new ObservableCollection<HamburgerMasterMenuItem>(new[]
{
                    new HamburgerMasterMenuItem { Id = 2, Title = "Support", Icon = "icon_support", TargetType = typeof(Support) },
                    new HamburgerMasterMenuItem { Id = 3, Title = "Revyvv U", Icon = "icon_revyvvu", TargetType = typeof(RevyvvU) }
            });
        }
        public ICommand OpenPageCommand { private set; get; }

        public CrossingUIModelViewModel CrossingUIModelViewModel
        {
            get { return new CrossingUIModelViewModel(); }
            set { CrossingUIModelViewModel = value; }
        }

        CustomerModel model;
        public bool HasAccount(bool hasAccount)
		{
            return model.hasAccount = hasAccount;
		}

        public bool HasAppointment()
		{
            return model.hasAppointment;
		}

        public string[] BizImage
		{
			get
			{
                return new string[]
                {
                    "img_ziba_logo.png"
                };
			}
		}

        public string[] BizName
        {
            get
            {
                return new string[]
                {
                    "Welcome to Ziba Beauty in the Revyvv mobile business platform."
                };
            }
        }

        public string[] SplashTitles
        {
            get
            {
                return new string[]
                {
                    "REWARDING YOUR LOYALTY",
                    "PERSONALIZED OFFERS",
                    "SAVE MONEY",
                    "Revyvv"
                };
            }
        }
        public string[] SplashDetails
        {
            get
            {
                return new string[]
                {
                    "Earn loyalty points for every purchase",
                    "Deals based on your preferences",
                    "Stay tuned for red hot flash sales",
                    "Best offers. Best rewards."
                };
            }
        }
        private async void OpenPage(string value)
        {
            switch (value)
            {
                case "SharedSplashTwo":
                    //model.hasAccount = false;
                    //model.hasAppointment = false;
                    await Application.Current.MainPage.Navigation.PushAsync(new SharedSplashTwo { BindingContext = this });
                    break;
                case "SharedSplashThree":
                    await Application.Current.MainPage.Navigation.PushAsync(new SharedSplashThree { BindingContext = this });
                    break;
                case "SharedSplashFour":
                    await Application.Current.MainPage.Navigation.PushAsync(new SharedSplashFour { BindingContext = this });
                    break;
                case "SharedRegisteration":
                    await Application.Current.MainPage.Navigation.PushAsync(new SharedRegisteration { BindingContext = this });
                    break;
                case "TwoFactorConfirm":
                    await Application.Current.MainPage.Navigation.PushAsync(new TwoFactorConfirm { BindingContext = this });
                    break;
                case "SharedPageConfirmNum":
                    await Application.Current.MainPage.Navigation.PushAsync(new SharedLogin { BindingContext = this });
                    break;
                case "DragnDrop":
                    await Application.Current.MainPage.Navigation.PushAsync(new DragAndDrop { BindingContext = this });
                    break;
                case "SharedDragnDrop":
                    await Application.Current.MainPage.Navigation.PushAsync(new SharedActivate { BindingContext = this });
                    break;
                case "SharedActivate":
                    await Application.Current.MainPage.Navigation.PushAsync(new GenerateDeals { BindingContext = this });
                    break;
                case "ClickEngine":
                    //model.hasAccount = true;
                    await Application.Current.MainPage.Navigation.PushAsync(new DealBoard { BindingContext = this });
                    break;
                default:
                    return;
            }
        }

        public List<Deals> SetDeals ()
        {
            List<Deals> deals = new List<Deals>
            {
                new Deals
                {
                    CardID = 1,
                    cardTitle = "Buy & Earn",
                    price = "$19.99",
                    dealDescr = "2 for 1 Eyebrow Brush",
                    dealPic = "component_561_1.png",
                    headerColor = Color.FromHex("#EA0404"),
                    img = "red_deal_icon.png",
                    ShopTitle = "Ziba Beauty",
                    DealTitle = "2 for 1",
                    type = "Clearance",
                    color = Color.FromHex("#d03737")
                },

                new Deals
                {
                    CardID = 2,
                    cardTitle = "Buy & Earn",
                    price = "$19.99",
                    dealDescr = "2 for 1 Eyebrow Brush",
                    dealPic = "component_561_1.png",
                    headerColor = Color.FromHex("#ff2a6037"),
                    img = "green_deal_icon.png",
                    ShopTitle = "Ziba Beauty",
                    DealTitle = "30% off",
                    type = "GoodDeal",
                    color = Color.FromHex("#3e8f52")
                },

                new Deals
                {
                    CardID = 3,
                    cardTitle = "Buy & Earn",
                    price = "$19.99",
                    dealDescr = "2 for 1 Eyebrow Brush",
                    dealPic = "component_561_1.png",
                    headerColor = Color.FromHex("#ff2a6037"),
                    img = "blue_deal_icon.png",
                    ShopTitle = "Ziba Beauty",
                    DealTitle = "2 for 1",
                    type = "Points",
                    color = Color.FromHex("#276dd6")
                },

                new Deals
                {
                    CardID = 4,
                    cardTitle = "Buy & Earn",
                    price = "$19.99",
                    dealDescr = "2 for 1 Eyebrow Brush",
                    dealPic = "component_561_1.png",
                    headerColor = Color.FromHex("#ff2a6037"),
                    img = "black_deal_icon.png",
                    ShopTitle = "Ziba Beauty",
                    DealTitle = "Black Friday",
                    type = "BlackFriday",
                    color = Color.Black
                },
            };

            return deals;
        }

        public async void GoTo(string value)
		{
			switch (value)
			{
				case "Contact":
                    await Application.Current.MainPage.Navigation.PushAsync(new ContactDetails());
					break;
				case "Payment":
                    await Application.Current.MainPage.Navigation.PushAsync(new PaymentMethod());
					break;
				case "Privacy":
                    await Application.Current.MainPage.Navigation.PushAsync(new PrivacyAndSecurity());
					break;
                case "Languages":
                    await Application.Current.MainPage.Navigation.PushAsync(new LanguageList());
                    break;
                case "Revyvv":
                    await Application.Current.MainPage.Navigation.PushAsync(new RevyvvU());
                    break;
			}

		}

        public async void SetCard(int id)
		{
            List<Deals> d = SetDeals();
            for(int i = 0; i < d.Count; i++)
			{
                if(d[i].CardID.Equals(id))
                { 
                    await Application.Current.MainPage.Navigation.PushAsync(new ClickedDeal(d[i]));
                }
            }
		}

        public async void SetCartPreview(string name)
		{
            Console.WriteLine(name);
            ObservableCollection<Models.Products> prod = new ObservableCollection<Products>();
            ProductsViewModel pvm = new ProductsViewModel();
            prod = pvm.SetProducts();

            for(int i = 0; i < prod.Count; i++)
			{
                if(prod[i].Name.Equals(name))
				{
                    await Application.Current.MainPage.Navigation.PushAsync(new CartPreview(prod[i]));
				}
			}
		}

        ObservableCollection<CustomerLevels> levels = new ObservableCollection<CustomerLevels>();
        public ObservableCollection<CustomerLevels> SetLevelImages()
		{
            levels.Add(new CustomerLevels() { level = 1, disabled = "icon_tree_disabled.png", abled = "icon_tree_idle.png" });
            levels.Add(new CustomerLevels() { level = 2, disabled = "icon_traffic_disabled.png", abled = "icon_traffic_idle.png" });
            levels.Add(new CustomerLevels() { level = 3, disabled = "icon_road_disabled.png", abled = "icon_road_idle.png" });
            levels.Add(new CustomerLevels() { level = 4, disabled = "icon_playground_disabled.png", abled = "icon_playground_idle.png" });
            levels.Add(new CustomerLevels() { level = 5, disabled = "icon_sidewalk_disabled.png", abled = "icon_sidewalk_idle.png" });
            levels.Add(new CustomerLevels() { level = 6, disabled = "icon_store_disabled.png", abled = "icon_store_idle.png" });
            levels.Add(new CustomerLevels() { level = 7, disabled = "icon_help_neighbors_disabled.png", abled = "icon_help_neighbors_idle.png" });
            levels.Add(new CustomerLevels() { level = 8, disabled = "icon_plant_garden_disabled.png", abled = "icon_plant_garden_idle.png" });
            levels.Add(new CustomerLevels() { level = 9, disabled = "icon_run_office_disabled.png", abled = "icon_run_office_idle.png" });
            return levels;
		}

        public ObservableCollection<SummaryOrderModel> SetOrders()
		{
            customerModel = new ObservableCollection<SummaryOrderModel>()
			{
                        new SummaryOrderModel
                        {
                            OrderNumber = 12345,
                            OrderDate = DateTime.Now,
                            status = true,
                            ImageSource = "browtrio.png",
                            ProductName = "Ziba Brow Trio",
                            Price = 19

                        },
                        new SummaryOrderModel
                        {
                            OrderNumber = 12145,
                            OrderDate = DateTime.Now,
                            status = false,
                            ImageSource = "browcrayon.png",
                            ProductName = "Ziba Brow Crayon",
                            Price = 19
                        }
            };
            return customerModel;
		}



    }
}
