using Econic.Mobile.Models;
using Econic.Mobile.Services;
using Econic.Mobile.Views.Customer;
using Econic.Mobile.Views.EconicStudio;
using Econic.Mobile.Views.Templates.Resources;
using Econic.Mobile.Views.OwnerReg;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.Collections;

namespace Econic.Mobile.ViewModels
{ 
	public class ControlTemplateViewModel : INotifyPropertyChanged
	{
		
		public ICommand ClickedCommand { private set; get; }
		public ICommand BoxCommand { set; get; }

		public event PropertyChangedEventHandler PropertyChanged;
		readonly IList<ControlTemplates> list;
		
		public ObservableCollection<ControlTemplates> templates { get; set; }
		public ObservableCollection<BoxColorModel> BoxColors { get; set; }
		public IList<BoxColorModel> box;

		public int PreviousPosition { get; set; }
		public int CurrentPosition { get; set; }
		public int Position { get; set; }

		public ControlTemplates PreviousTemplate { get; set; }
		public ControlTemplates CurrentTemplate { get; set; }
		public ControlTemplates CurrentItem { get; set; }

		
		public ResourceDictionary ThemeDict { get; set; }

		public ControlTemplateViewModel() {
			list = new List<ControlTemplates>();
			CreateTemplateCollection();
			CreateBoxCollection();
			CurrentItem = templates.Skip(3).FirstOrDefault();
			OnPropertyChanged("CurrentItem");
			Position = 3;
			OnPropertyChanged("Position");

			ClickedCommand = new Command<string>((arg) => NextPage(arg));
			BoxCommand = new Command<Color>((arg) => SetThemeColor(arg));
			
		}

		private void SetThemeColor(Color value)
		{
			Console.WriteLine(value.ToString());
			App.Current.Resources["ThemeColor"] = value;
		}

		private async void NextPage(string value)
		{
			switch(value)
			{
				case "Book":
					await Application.Current.MainPage.Navigation.PushAsync(new BookAppointment());
					break;
				case "Notify":
					await Application.Current.MainPage.Navigation.PushAsync(new Notify { BindingContext = this });
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
			Console.Write("You've Selected the " +  item.name + " template");
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
	}
}
