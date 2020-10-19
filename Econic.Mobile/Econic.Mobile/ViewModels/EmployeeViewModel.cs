using Econic.Mobile.Views.OwnerReg;
using Econic.Mobile.Views.Shared;
using Econic.Mobile.Views.Shared.SplashScreens;
using System.Windows.Input;
using Xamarin.Forms;

namespace Econic.Mobile.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
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
                    "REWARDING SYSTEM",
                    "HELPING YOU BE YOUR BEST",
                    "REACHING YOUR GOALS",
                    "MAKES YOU MONEY AND IT'S FREE!"
                };
            }
        }
        public string[] SplashDetails
        {
            get
            {
                return new string[]
                {
                    "Get rewarded for improving your results",
                    "Automating the deals you present to your customers",
                    "Earning more commissions",
                    "Join the Revyvv Resolution"
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
                default:
                    return;
            }
        }
    }
}
