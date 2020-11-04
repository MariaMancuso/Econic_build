using Econic.Mobile.Models;
using Econic.Mobile.Services;
using Econic.Mobile.Views.Customer;
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
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Econic.Mobile.ViewModels
{
    public class OwnerBoardingViewModel : INotifyPropertyChanged
    {
        IPermissionService permissionService;
        SelectionViewModel cmSelection;
        SelectionViewModel nSelection;
        public OwnerBoardingViewModel()
        {
            User = new OwnerModel
            {
                Account = new Account(),
                Address = new AddressModel(),
                LogoIcon = new Image(),
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

            //studio stuff
            list = new List<ControlTemplates>();
            CreateTemplateCollection();
            CreateBoxCollection();
            CurrentItem = templates.Skip(3).FirstOrDefault();
            OnPropertyChanged("CurrentItem");
            Position = 3;
            OnPropertyChanged("Position");

            ClickedCommand = new Command<string>((arg) => NextPage(arg));
            BoxCommand = new Command<Color>((arg) => SetThemeColor(arg));
            //GetClassifications();
        }

        public string[] RevyvvLogo
        {
            get
            {
                return new string[]
                {
                    "logo.png"
                };
            }
        }

        public OwnerModel User { get; set; }
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
			string init;
			if (User.BusinessName != null)
			{
                init = initials.Replace(User.BusinessName, "$1");
            }
            else
			{
                init = initials.Replace("Ziba Beauty", "$1");
            }
            return init;
        }
        int height;
        public int ListViewHeight
        {
            get { return height; }
            set { height = User.Items.Count * 120; }
        }
        public ICommand OpenPageCommand { private set; get; }
        public ICommand InfoTapped { private set; get; }

        public ICommand CMTapped { private set; get; }
        public ICommand RemoveClicked { private set; get; }
        public ICommand EditClicked { private set; get; }

        // studio stuff
        public ICommand ClickedCommand { private set; get; }
        public ICommand BoxCommand { set; get; }
        readonly IList<ControlTemplates> list;

        public ObservableCollection<ControlTemplates> templates { get; set; }
        public ObservableCollection<BoxColorModel> BoxColors { get; set; }
        public IList<BoxColorModel> box;

        private List<string> goods { get; set; }
        public List<string> Goods
		{
            get { return goods; }
            set { goods = value; }
		}
        private List<string> services { get; set; }

        public List<string> Services
		{
			get { return services; }
            set { services = value; }
		}

        public event PropertyChangedEventHandler PropertyChanged;

		public int PreviousPosition { get; set; }
        public int CurrentPosition { get; set; }
        public int Position { get; set; }

        public ControlTemplates PreviousTemplate { get; set; }
        public ControlTemplates CurrentTemplate { get; set; }
        public ControlTemplates CurrentItem { get; set; }
        public ResourceDictionary ThemeDict { get; set; }

        private void SetThemeColor(Color value)
        {
            Console.WriteLine(value.ToString());
            App.Current.Resources["ThemeColor"] = value;
        }
        private async void NextPage(string value)
        {
            switch (value)
            {
                case "Book":
                    await Application.Current.MainPage.Navigation.PushAsync(new BookAppointment());
                    break;
                case "ETGoHome":
                    await Application.Current.MainPage.Navigation.PushAsync(new DealBoard());
                    break;
                case "MerchantHome":
                    await Application.Current.MainPage.Navigation.PushAsync(new LandingPage());
                    break;
                case "AccountHome":
                    await Application.Current.MainPage.Navigation.PushAsync(new LoyaltyConfirmation());
                    break;
                default:
                    return;
            }
        }
        void CreateTemplateCollection()
        {
            list.Add(new ControlTemplates
            {
                name = "Classic",
                Name = (ControlTemplate)Application.Current.Resources["ClassicControlTemplate"]
            });

            list.Add(new ControlTemplates
            {
                name = "Modern",
                Name = (ControlTemplate)Application.Current.Resources["ModernControlTemplate"]
            });

            list.Add(new ControlTemplates
            {
                name = "Friendly",
                Name = (ControlTemplate)Application.Current.Resources["FriendlyControlTemplate"]
            });
            templates = new ObservableCollection<ControlTemplates>(list);
        }

        public IList<BoxColorModel> CreateBoxCollection()
        {
            box = new List<BoxColorModel>();
            box.Add(new BoxColorModel { color = Color.FromHex("#c72129") });
            box.Add(new BoxColorModel { color = Color.FromHex("#ff8611") });
            box.Add(new BoxColorModel { color = Color.FromHex("#32922c") });
            box.Add(new BoxColorModel { color = Color.FromHex("#11a18e") });
            box.Add(new BoxColorModel { color = Color.FromHex("#000059") });
            box.Add(new BoxColorModel { color = Color.FromHex("#0070f4") });
            box.Add(new BoxColorModel { color = Color.FromHex("#cc4a82") });
            box.Add(new BoxColorModel { color = Color.FromHex("#754313") });
            box.Add(new BoxColorModel { color = Color.FromHex("#354134") });
            box.Add(new BoxColorModel { color = Color.FromHex("#7323a8") });
            box.Add(new BoxColorModel { color = Color.FromHex("#6f6f6f") });
            box.Add(new BoxColorModel { color = Color.FromHex("#c9a015") });

            return box;
        }

        public void ItemChanged(ControlTemplates item)
        {
            PreviousTemplate = CurrentTemplate;
            CurrentTemplate = item;
            Console.Write("You've Selected the " + item.name + " template");
            //ChangeThemeInfo(item.name);
            OnPropertyChanged("PreviousTemplate");
            OnPropertyChanged("CurrentTemplate");
        }

        public void ChangeThemeInfo(object template)
        {
            //Theme theme = (Theme)template;

            //ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            //if (mergedDictionaries != null)
            //{
            //	Console.WriteLine(mergedDictionaries.Count);
            //	mergedDictionaries.Clear();
            //	switch (theme)
            //	{
            //		case Theme.Classic:
            //			mergedDictionaries.Add(new Views.Templates.Resources.ClassicDictionary());
            //			break;
            //		case Theme.Modern:
            //			mergedDictionaries.Add(new Views.Templates.Resources.ModernDictionary());
            //			break;
            //		case Theme.Friendly:
            //			mergedDictionaries.Add(new Views.Templates.Resources.Friendly());
            //			break;
            //		default:
            //			break;
            //	}
            //}

        }
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // studio stuff ends
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
                    if (CurrentItemModel != null && !User.Items.Contains(CurrentItemModel))
                        User.Items.Add(CurrentItemModel);

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
                    await Application.Current.MainPage.Navigation.PushAsync(new LightsOnGamification { BindingContext = this});
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
                    OwnerViewModel model = new OwnerViewModel(User);
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
                case "ChooseLogo":
                    await Application.Current.MainPage.Navigation.PushAsync(new ChooseLogo(this));
                    break;
                case "RewardSplash":
                    await Application.Current.MainPage.Navigation.PushAsync(new RewardSplash() { BindingContext = this });
                    break;
                case "DealSplash":
                    await Application.Current.MainPage.Navigation.PushAsync(new DealSplash() { BindingContext = this });
                    break;
                case "MoneySplash":
                    await Application.Current.MainPage.Navigation.PushAsync(new MoneySplash() { BindingContext = this });
                    break;
                case "BusinessName":
                    await Application.Current.MainPage.Navigation.PushAsync(new CheckNameClassifyBusiness() { BindingContext = this });
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
            User.Items.Remove(item);
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
            if (label.Text == "Services")
                CurrentItemModel.Type = "Service";
            else
                CurrentItemModel.Type = "Good";
            await Application.Current.MainPage.Navigation.PushAsync(new AddItem { BindingContext = this});
            frame.BackgroundColor = Color.White;
            label.TextColor = Color.FromHex("#404040");
        }

        private List<DropdownItems> item;

        public List<DropdownItems> DropItem
		{
            get { return item; }
			set { item = value; }
		}
        public List<DropdownItems> SetClassificationDropdowns()
		{
            item = new List<DropdownItems>();
			item.Add(new DropdownItems { CategoryID = 1, Name = "Construction/Home Repair", IsGood = true, IsService = true});
			item.Add(new DropdownItems { CategoryID = 2, Name = "Motor Vehicle and Parts Dealers", IsGood = true, IsService = false});
			item.Add(new DropdownItems { CategoryID = 3, Name = "Furniture and Home Furishings", IsGood = true, IsService = true});
            item.Add(new DropdownItems { CategoryID = 4, Name = "Electronics and Appliance Stores", IsGood = true, IsService = true});
            item.Add(new DropdownItems { CategoryID = 5, Name = "Building Material, Garden Equipment and Supplies Dealers", IsGood = true, IsService = false});
            item.Add(new DropdownItems { CategoryID = 6, Name = "Food and Beverage Stores", IsGood = true, IsService = false});
            item.Add(new DropdownItems { CategoryID = 7, Name = "Health and Personal Care Stores", IsGood = true, IsService = true});
            item.Add(new DropdownItems { CategoryID = 8, Name = "Clothing/Clothing Accessories Stores", IsGood = true, IsService =  false});
            item.Add(new DropdownItems { CategoryID = 9, Name = "Sporting Goods, Hobby, Musical Instrument, and Book Stores", IsGood = true, IsService = false});
            return item;
        }

        public void GetClassifications()
        {
            List<DropdownItems> items;
            goods = new List<string>();
            services = new List<string>();
            items = SetClassificationDropdowns();

            for (int i = 0; i > items.Count; i++)
            {
                if (items[i].IsGood && items[i].IsService)
                {
                    goods.Add(items[i].Name);
                    services.Add(items[i].Name);
                }

                if (items[i].IsGood && !items[i].IsService)
                {
                    goods.Add(items[i].Name);
                }

                if (!items[i].IsGood && items[i].IsService)
                {
                    services.Add(items[i].Name);
                }
            }
        }
    }
}
