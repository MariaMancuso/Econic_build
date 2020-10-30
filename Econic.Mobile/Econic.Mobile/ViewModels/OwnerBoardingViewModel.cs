using Econic.Mobile.Models;
using Econic.Mobile.Services;
using Econic.Mobile.Views.EconicStudio;
using Econic.Mobile.Views.Gamification;
using Econic.Mobile.Views.OwnerProfile;
using Econic.Mobile.Views.OwnerReg;
using Econic.Mobile.Views.Shared;
using Econic.Mobile.Views.Shared.HamburgerMenu;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Econic.Mobile.ViewModels
{
    public class OwnerBoardingViewModel
    {
        IPermissionService permissionService;
        SelectionViewModel cmSelection;
        SelectionViewModel nSelection;
        public OwnerBoardingViewModel()
        {
            Owner = new OwnerModel
            {
                Account = new Account(),
                Address = new AddressModel(),
                Goals = new ObservableCollection<OwnerGoalModel>()
                {
                new OwnerGoalModel() { Goal = "Connect you to your customers", Value = 0},
                new OwnerGoalModel() { Goal = "Increate your profibility", Value = 0},
                new OwnerGoalModel() { Goal = "Identify your best products and service - every day", Value = 0},
                new OwnerGoalModel() { Goal = "Identify and reward your most loyal customers", Value = 0},
                new OwnerGoalModel() { Goal = "Lower your transactions costs", Value = 0}
                },
                Items = new ObservableCollection<ItemModel>(),

                Classifications = new ObservableCollection<ClassificationModel>(),
                NotifyMethods = new ObservableCollection<NotifyModel>(),

                InviteMessages = new InviteMessageModel()
                {
                    CustomerMessage =
                    "To all my best customers and VIPs, this is an advance invitation to our new app that provides you special deals and rewards your loyalty. " +
                    "\n\nPlease click the link to install and save." +
                    "\nwww.ziba.econic.com",
                    EmployeeMessage
                    = "Check out out new Econic mobile business. This will help us sell out best products and services to our best customers. Click the link to install." +
                    "\nwww.ziba.econic.com"
                }
            };
            permissionService = DependencyService.Get<IPermissionService>();
            cmSelection = new SelectionViewModel();
            nSelection = new SelectionViewModel();

            OpenPageCommand = new Command<string>((arg) => OpenPage(arg));
            InfoTapped = new Command<string>((arg) => OpenInfoPage(arg));
            CMTapped = new Command(cmTapped);
            RemoveClicked = new Command(removeClicked);
            EditClicked = new Command(editClicked);
        }
        public OwnerModel Owner { get; set; }
        public ItemModel CurrentItemModel { get; set; }
        public SelectionViewModel CMSelectionViewModel
        {
            get { return cmSelection; }
            set { cmSelection = value;}
        }
        public SelectionViewModel NMSelectionViewModel
        {
            get { return nSelection; }
            set { nSelection = value; }
        }
        public CrossingUIModelViewModel CrossingUIModelViewModel
        {
            get { return new CrossingUIModelViewModel(); }
            set { CrossingUIModelViewModel = value; }
        }
        public string GetInitials()
        {
            Regex initials = new Regex(@"(\b[a-zA-Z])[a-zA-Z]* ?");
            string init = initials.Replace(Owner.BusinessName, "$1");

            return init;
        }
        int height;
        public int ListViewHeight
        {
            get { return height; }
            set { height = Owner.Items.Count * 120; }
        }
        public ICommand OpenPageCommand { private set; get; }
        public ICommand InfoTapped { private set; get; }

        public ICommand CMTapped { private set; get; }
        public ICommand RemoveClicked { private set; get; }
        public ICommand EditClicked { private set; get; }

        private async void OpenPage(string value)
        {
            switch (value)
            {
                case "Address":
                    await Application.Current.MainPage.Navigation.PushAsync(new Address(this));
                    break;
                case "Sales":
                    await Application.Current.MainPage.Navigation.PushAsync(new Sales(this));
                    break;
                case "FirstPreview":
                    await Application.Current.MainPage.Navigation.PushAsync(new FirstPreview(this));
                    break;
                case "DragAndDrop":
                    await Application.Current.MainPage.Navigation.PushAsync(new DragAndDrop { BindingContext = this });
                    break;
                case "SharedDragnDrop":
                    await Application.Current.MainPage.Navigation.PushAsync(new Classification(this));
                    break;
                case "Preview":
                    if (CurrentItemModel != null && !Owner.Items.Contains(CurrentItemModel))
                        Owner.Items.Add(CurrentItemModel);

                    await Application.Current.MainPage.Navigation.PushAsync(new ProductsAndServices { BindingContext = this }); ;
                    break;
                case "AddAnother":
                    if(CurrentItemModel.Type == "Good")
                        CurrentItemModel = new ItemModel { Type = "Good"};
                    else
                        CurrentItemModel = new ItemModel { Type = "Service" };
                    await Application.Current.MainPage.Navigation.PushAsync(new AddItem { BindingContext = this });
                    break;
                case "SharedPreview":
                    await Application.Current.MainPage.Navigation.PushAsync(new SecondPreview(this));
                    break;
                case "NotifyMethod":
                    await Application.Current.MainPage.Navigation.PushAsync(new Notify { BindingContext = this});
                    //foreach(string notifymethod in nSelection.Items)
                    //{
                    //    if(!owner.NotifyMethods.Any(x => x.Name == notifymethod))
                    //        owner.NotifyMethods.Add(new NotifyModel { Name = notifymethod });
                    //}
                    //await Application.Current.MainPage.Navigation.PushAsync(new Notify(this));
                    break;
                case "Invite":
                    await Application.Current.MainPage.Navigation.PushAsync(new Invite(this));
                    break;
                case "Features":
                    await Application.Current.MainPage.Navigation.PushAsync(new Features(this));
                    break;
                case "Permission":
                    await Application.Current.MainPage.Navigation.PushAsync(new Permission(this));
                    break;
                case "FourthPreview":
                    bool Granted = await permissionService.RequestAllPermissions();
                    if(Granted)
                        await Application.Current.MainPage.Navigation.PushAsync(new FourthPreview(this));
                    break;
                case "LoyaltyPreview":
                        await Application.Current.MainPage.Navigation.PushAsync(new LoyaltyPreview(this));
                    break;
                case "AccountRegisteration":
                    await Application.Current.MainPage.Navigation.PushAsync(new AccountRegisteration(this));
                    break;
                case "TwoFactorNumber":
                    await Application.Current.MainPage.Navigation.PushAsync(new TwoFactorNumber(this));
                    break;
                case "TwoFactorConfirm":
                    await Application.Current.MainPage.Navigation.PushAsync(new TwoFactorConfirm { BindingContext = this });
                    break;
                case "SharedPageConfirmNum":
                    await Application.Current.MainPage.Navigation.PushAsync(new FifthPreview(this));
                    break;
                case "Profile":
                    OwnerViewModel model = new OwnerViewModel(Owner);
                    var page = new Hamburger { BindingContext = model };
                    //page.Master = new HamburgerMaster { BindingContext = model };
                    page.Detail = new NavigationPage(new OwnerTabbedPage
                    {
                        BindingContext = model,
                        BarBackgroundColor = Color.WhiteSmoke
                    })
                    {
                        BarBackgroundColor = Color.WhiteSmoke,
                        BackgroundColor = Color.WhiteSmoke
                    };
                    await Application.Current.MainPage.Navigation.PushAsync(page);
                    break;
                case "EconicStudio":
                    await Application.Current.MainPage.Navigation.PushAsync(new Views.EconicStudio.WelcomeScreen(this));
                    break;
                case "Theme":
                    await Application.Current.MainPage.Navigation.PushAsync(new ChooseTheme(this));
                    break;
                default:
                    return;
            }
        }

        private async void OpenInfoPage(string value)
        {
            switch (value)
            {
                case "QRCodes":
                    await Application.Current.MainPage.Navigation.PushAsync(new QRCodes { BindingContext = this});
                    break;
                case "ProductAndServices":
                    await Application.Current.MainPage.Navigation.PushAsync(new ProductsAndServices { BindingContext = this });
                    break;
                default:
                    return;
            }
        }
        private async void editClicked(Object sender)
        {
            CurrentItemModel = sender as ItemModel;
            await Application.Current.MainPage.Navigation.PushAsync(new AddItem { BindingContext = this });
        }
        private void removeClicked(Object sender)
        {
            var item = sender as ItemModel;
            Owner.Items.Remove(item);
        }
        private async void cmTapped(Object sender)
        {
            TapGestureRecognizer tapGesture = sender as TapGestureRecognizer;
            Frame frame = tapGesture.Parent as Frame;
            StackLayout stackLayout = frame.Children[0] as StackLayout;

            Label label = stackLayout.Children[1] as Label;
            frame.BackgroundColor = Color.FromHex("#404040");
            label.TextColor = Color.White;
            CurrentItemModel = new ItemModel();
            CurrentItemModel.Image = new Image();
            if (label.Text == "Services")
                CurrentItemModel.Type = "Service";
            else
                CurrentItemModel.Type = "Good";
            await Application.Current.MainPage.Navigation.PushAsync(new AddItem { BindingContext = this});
            frame.BackgroundColor = Color.White;
            label.TextColor = Color.FromHex("#404040");
        }
    }
}
