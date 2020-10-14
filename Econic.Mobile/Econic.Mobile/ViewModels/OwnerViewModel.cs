using Econic.Mobile.Models;
using Econic.Mobile.Services;
using Econic.Mobile.Views.Gamification;
using Econic.Mobile.Views.OwnerReg;
using Econic.Mobile.Views.Shared;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace Econic.Mobile.ViewModels
{
    public class OwnerViewModel
    {
        OwnerModel owner;
        SelectionViewModel<ClassificationModel> cmSelectionViewModel;
        SelectionViewModel<NotifyModel> nmSelectionViewModel;
        IPermissionService permissionService;

        public OwnerViewModel()
        {
            owner = new OwnerModel
            {
                Address = new AddressModel(),
                Goals = new List<OwnerGoalModel>()
                {
                new OwnerGoalModel() { Goal = "Connect you to your customers", Value = 0},
                new OwnerGoalModel() { Goal = "Increate your profibility", Value = 0},
                new OwnerGoalModel() { Goal = "Identify your best products and service - every day", Value = 0},
                new OwnerGoalModel() { Goal = "Identify and reward your most loyal customers", Value = 0},
                new OwnerGoalModel() { Goal = "Lower your transactions costs", Value = 0}
                },

                Classifications = new List<SelectableData<ClassificationModel>>()
                {
                    new SelectableData<ClassificationModel>() { Data = new ClassificationModel() { Name = "Services" }},
                    new SelectableData<ClassificationModel>() { Data = new ClassificationModel() { Name = "Products" }},
                    new SelectableData<ClassificationModel>() { Data = new ClassificationModel() { Name = "Assets" }}
                },
                NotifyMethods = new List<SelectableData<NotifyModel>>()
                {
                    new SelectableData<NotifyModel>() { Data = new NotifyModel() { Name = "Text Message" }},
                    new SelectableData<NotifyModel>() { Data = new NotifyModel() { Name = "Email" }},
                    new SelectableData<NotifyModel>() { Data = new NotifyModel() { Name = "Push Notifications" }}
                },
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

            cmSelectionViewModel = new SelectionViewModel<ClassificationModel>(owner.Classifications);
            nmSelectionViewModel = new SelectionViewModel<NotifyModel>(owner.NotifyMethods);

            OpenPageCommand = new Command<string>((arg) => OpenPage(arg));
        }
        public OwnerModel Owner 
        { 
            get { return owner; }
            set { owner = value; }
        }
        public SelectionViewModel<ClassificationModel> CMSelectionViewModel
        {
            get { return cmSelectionViewModel; }
            set { cmSelectionViewModel = value; owner.Classifications = cmSelectionViewModel.Items; }
        }
        public SelectionViewModel<NotifyModel> NMSelectionViewModel
        {
            get { return nmSelectionViewModel; }
            set { nmSelectionViewModel = value; owner.NotifyMethods = nmSelectionViewModel.Items; }
        }
        public string GetInitials()
        {
            Regex initials = new Regex(@"(\b[a-zA-Z])[a-zA-Z]* ?");
            string init = initials.Replace(owner.BusinessName, "$1");

            return init;
        }
        public ICommand OpenPageCommand { private set; get; }

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
                    await Application.Current.MainPage.Navigation.PushAsync(new DragAndDrop(this));
                    break;
                case "Classification":
                    await Application.Current.MainPage.Navigation.PushAsync(new Classification(this));
                    break;
                case "AddItem":
                    await Application.Current.MainPage.Navigation.PushAsync(new AddItem(this));
                    break;
                case "NotifyMethod":
                    await Application.Current.MainPage.Navigation.PushAsync(new Notify(this));
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
                        await Application.Current.MainPage.Navigation.PushAsync(new FourthPreview());
                    break;
                default:
                    return;
            }
        }
    }
}
