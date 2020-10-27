using Econic.Mobile.Views.Customer;
using Econic.Mobile.Views.OwnerReg;
using Econic.Mobile.Models;
using Econic.Mobile.Views.Shared;
using Econic.Mobile.Views.Shared.SplashScreens;
using System.Windows.Input;
using Xamarin.Forms;
using System.Dynamic;
using System.Collections.Generic;

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

        public IList<Deals> SetDeals ()
        {
            List<Deals> deals = new List<Deals>
            {
                new Deals
                {
                    img = "red_deal_icon.png",
                    ShopTitle = "Ziba Beauty",
                    DealTitle = "2 for 1",
                    type = "Clearance",
                    color = Color.FromHex("#d03737")
                },

                new Deals
                {
                    img = "green_deal_icon.png",
                    ShopTitle = "Ziba Beauty",
                    DealTitle = "30% off",
                    type = "GoodDeal",
                    color = Color.FromHex("#3e8f52")
                },

                new Deals
                {
                    img = "blue_deal_icon.png",
                    ShopTitle = "Ziba Beauty",
                    DealTitle = "2 for 1",
                    type = "Points",
                    color = Color.FromHex("#276dd6")
                },

                new Deals
                {
                    img = "black_deal_icon.png",
                    ShopTitle = "Ziba Beauty",
                    DealTitle = "Black Friday",
                    type = "BlackFriday",
                    color = Color.Black
                },
            };

            return deals;
        }
    }
}
