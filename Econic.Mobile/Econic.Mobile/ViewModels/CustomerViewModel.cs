using Econic.Mobile.Views.Customer;
using Econic.Mobile.Views.OwnerReg;
using Econic.Mobile.Models;
using Econic.Mobile.Views.Shared;
using Econic.Mobile.Views.Shared.SplashScreens;
using System.Windows.Input;
using Xamarin.Forms;
using System.Dynamic;
using System.Collections.Generic;
using System;

namespace Econic.Mobile.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            OpenPageCommand = new Command<string>((arg) => OpenPage(arg));
        }
        public ICommand OpenPageCommand { private set; get; }

        public CrossingUIModelViewModel CrossingUIModelViewModel
        {
            get { return new CrossingUIModelViewModel(); }
            set { CrossingUIModelViewModel = value; }
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
    }
}
