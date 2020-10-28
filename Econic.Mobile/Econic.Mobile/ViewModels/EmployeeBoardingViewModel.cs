using Econic.Mobile.Models.EmployeeModels;
using Econic.Mobile.ViewModel;
using Econic.Mobile.Views.Employee;
using Econic.Mobile.Views.OwnerReg;
using Econic.Mobile.Views.Shared;
using Econic.Mobile.Views.Shared.SplashScreens;
using Syncfusion.XForms.ComboBox;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using Econic.Mobile.Views.Shared.HamburgerMenu;
using Econic.Mobile.Models;
using System.ComponentModel;

namespace Econic.Mobile.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class EmployeeBoardingViewModel : INotifyPropertyChanged
    {
        EmployeeModel employee;
        EmployeeScheduleModel scheduleModel;
        ObservableCollection<OwnerGoalModel> goals;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public EmployeeBoardingViewModel()
        {
            OpenPageCommand = new Command<string>((arg) => OpenPage(arg));
            CMTapped = new Command(cmTapped);
            SpecialityAddTapped = new Command(specialityAddTapped);
            SpecialityRemoveTapped = new Command(specialityRemoveTapped);
            DayTappedCommand = new Command(dayTappedCommand);

            employee = new EmployeeModel()
            {
                EmployeeSpecialities = new ObservableCollection<EmployeeSpecialitiesModel>()
                {
                    new EmployeeSpecialitiesModel()
                },
                EmployeeSchedules = new ObservableCollection<EmployeeScheduleModel>()
                {
                    new EmployeeScheduleModel { Day = "Sunday" },
                    new EmployeeScheduleModel { Day = "Monday" },
                    new EmployeeScheduleModel { Day = "Tuesday" },
                    new EmployeeScheduleModel { Day = "Wednesday" },
                    new EmployeeScheduleModel { Day = "Thursday" },
                    new EmployeeScheduleModel { Day = "Friday" },
                    new EmployeeScheduleModel { Day = "Saturday" }
                }
            };
            goals = new ObservableCollection<OwnerGoalModel>()
                {
                new OwnerGoalModel() { Goal = "Connect you to your customers", Value = 0},
                new OwnerGoalModel() { Goal = "Increate your profibility", Value = 1},
                new OwnerGoalModel() { Goal = "Identify your best products and service - every day", Value = 2},
                new OwnerGoalModel() { Goal = "Identify and reward your most loyal customers", Value = 3},
                new OwnerGoalModel() { Goal = "Lower your transactions costs", Value = 4}
                };
        }
        public EmployeeModel Employee
        {
            get { return employee; }
            set { employee = value; }
        }
        public ObservableCollection<OwnerGoalModel> Goals
        {
            get
            {
                return goals;
            }
            set
            {
                goals = value;
                OnPropertyChanged("Goals");
            }
        }
        public ICommand OpenPageCommand { private set; get; }
        public ICommand CMTapped { private set; get; }
        public ICommand SpecialityAddTapped { private set; get; }
        public ICommand SpecialityRemoveTapped { private set; get; }
        public ICommand DayTappedCommand { private set; get; }

        public EmployeeScheduleModel CurrentItem { get; set; }
        public SelectionViewModel ECMSelectionViewModel
        {
            get { return new SelectionViewModel(); }
            set { ECMSelectionViewModel = value; }
        }
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
        string classification = "";
        private async void cmTapped(Object sender)
        {
            TapGestureRecognizer tapGesture = sender as TapGestureRecognizer;
            Frame frame = tapGesture.Parent as Frame;
            StackLayout stackLayout = frame.Children[0] as StackLayout;

            Label label = stackLayout.Children[1] as Label;
            classification = label.Text;
            frame.BackgroundColor = Color.FromHex("#404040");
            label.TextColor = Color.White;
            await Application.Current.MainPage.Navigation.PushAsync(new EmployeeSchedule { BindingContext = this });
            frame.BackgroundColor = Color.White;
            label.TextColor = Color.FromHex("#404040");
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
                    await Application.Current.MainPage.Navigation.PushAsync(new EmployeeClassification { BindingContext = this });
                    break;
                case "GoalOutliner":
                    await Application.Current.MainPage.Navigation.PushAsync(new GoalOutliner { BindingContext = this });
                    break;
                case "SharedMenuPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new Hamburger { BindingContext = new EmployeeViewModel() });
                    break;
                default:
                    return;
            }
        }
        int count = 1;
        string header = "MY SPECIALITY";
        public string SpecialityHeader
        {
            get 
            {
                if (count == 1)
                    return header;
                else
                    return header + " " + count; 
            }
        } 
        private void specialityAddTapped(Object sender)
        {
            count++;
            StackLayout stack = sender as StackLayout;
            ControlTemplate template = Application.Current.Resources["SpecialityTemplate"] as ControlTemplate;
            ContentView view = new ContentView() { ControlTemplate = template };
            stack.Children.Add(view);
        }
        private void specialityRemoveTapped(Object sender)
        {
            count--;
            TapGestureRecognizer tapGesture = sender as TapGestureRecognizer;
            ContentView view = tapGesture.Parent.Parent.Parent.Parent as ContentView;
            StackLayout stack = view.Parent as StackLayout;
            stack.Children.Remove(view);
        }
        private void dayTappedCommand(Object sender)
        {
            if (CurrentItem.Start != null && CurrentItem.End != null)
                CurrentItem.IsWorking = true;
            else
                CurrentItem.IsWorking = false;

            if (CurrentItem != null)
                CurrentItem.IsSelected = false;

            EmployeeScheduleModel model = sender as EmployeeScheduleModel;
            scheduleModel = model;
            CurrentItem = scheduleModel;
            CurrentItem.IsSelected = true;

            if (CurrentItem.Start != null && CurrentItem.End != null)
                CurrentItem.IsWorking = true;
            else
                CurrentItem.IsWorking = false;
        }
    }
}
