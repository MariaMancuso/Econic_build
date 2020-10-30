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
        OwnerModel owner;
        IPermissionService permissionService;
        string mode;
        GoodModel itemToEdit;
        SelectionViewModel cmSelection;
        SelectionViewModel nSelection;
        public OwnerBoardingViewModel()
        {
            owner = new OwnerModel
            {
                Account = new Account(),
                Address = new AddressModel(),
                Items = new ObservableCollection<GoodModel>(),
                Goals = new ObservableCollection<OwnerGoalModel>()
                {
                new OwnerGoalModel() { Goal = "Connect you to your customers", Value = 0},
                new OwnerGoalModel() { Goal = "Increate your profibility", Value = 0},
                new OwnerGoalModel() { Goal = "Identify your best products and service - every day", Value = 0},
                new OwnerGoalModel() { Goal = "Identify and reward your most loyal customers", Value = 0},
                new OwnerGoalModel() { Goal = "Lower your transactions costs", Value = 0}
                },

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
            AddAnotherTapped = new Command(addAnotherTapped);
            EditClicked = new Command(editClicked);
            RemoveClicked = new Command(removeClicked);
            AddNewItemCommand = new Command(addNewItem);
        }
        public OwnerModel Owner 
        { 
            get { return owner; }
            set { owner = value; }
        }
        public GoodModel ItemToAdd { get; set; }
        public void RemoveItem(GoodModel itemModel)
        {
            owner.Items.Remove(itemModel);
        }
        public void AddItem(GoodModel itemModel)
        {
            owner.Items.Add(itemModel);
            ItemToAdd = null;
        }
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
            string init = initials.Replace(owner.BusinessName, "$1");

            return init;
        }
        int height;
        public int ListViewHeight
        {
            get { return height; }
            set { height = owner.Items.Count * 120; }
        }
        public ICommand OpenPageCommand { private set; get; }
        public ICommand InfoTapped { private set; get; }

        public ICommand AddAnotherTapped { private set; get; }
        public ICommand RemoveClicked { private set; get; }
        public ICommand EditClicked { private set; get; }
        public ICommand AddNewItemCommand { private set; get; }

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
                case "AddItem":
                    foreach (string classification in cmSelection.Items)
                    {
                        if(!owner.Classifications.Any(x => x.Name == classification))
                            owner.Classifications.Add(new ClassificationModel { Name = classification });
                    }
                    await Application.Current.MainPage.Navigation.PushAsync(new AddItem(this, "add"));
                    break;
                case "ItemPreview":
                    await Application.Current.MainPage.Navigation.PushAsync(new ItemPreview(this));
                    break;
                case "SecondPreview":
                    if (ItemToAdd != null)
                        AddItem(ItemToAdd);

                    if (itemToEdit != null)
                    {
                        RemoveItem(itemToEdit);
                        itemToEdit = null;
                    }

                    if (mode == "edit" || mode == "addfromprofile")
                        await Application.Current.MainPage.Navigation.PushAsync(new ProductsAndServices { BindingContext = this }) ;
                    else
                        await Application.Current.MainPage.Navigation.PushAsync(new  SecondPreview(this));

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
                    OwnerViewModel model = new OwnerViewModel(owner);
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
                    await Application.Current.MainPage.Navigation.PushAsync(new ChooseTheme());
                    break;
                default:
                    return;
            }
        }
        private async void addAnotherTapped()
        {
            if (mode == "edit")
                mode = "addfromprofile";
            if (ItemToAdd != null)
                AddItem(ItemToAdd);

            await Application.Current.MainPage.Navigation.PushAsync(new AddItem(this, mode));
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
            mode = "edit";
            itemToEdit = sender as GoodModel;
            ItemToAdd = itemToEdit;
            await Application.Current.MainPage.Navigation.PushAsync(new AddItem(this, mode));
        }
        private void removeClicked(Object sender)
        {
            mode = "Remove";
            GoodModel itemModel = sender as GoodModel;
            RemoveItem(itemModel);
        }
        private async void addNewItem()
        {
            mode = "addfromprofile";
            await Application.Current.MainPage.Navigation.PushAsync(new AddItem(this, mode));
        }
    }
}
