using Econic.Mobile.Models;
using Econic.Mobile.Services;
using Econic.Mobile.Views.Customer;
using Econic.Mobile.Views.Templates;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Econic.Mobile.ViewModels
{ 
	public class ControlTemplateViewModel : INotifyPropertyChanged
	{

		public ICommand ClickedCommand { private set; get; }
		public event PropertyChangedEventHandler PropertyChanged;
		readonly IList<ControlTemplates> list;
		public ControlTemplates CurrentItem;
		public ObservableCollection<ControlTemplates> templates { get; set; }

		public int PreviousPosition { get; set; }
		public int CurrentPosition { get; set; }
		public int Position { get; set; }

		public ControlTemplateViewModel() {
			list = new List<ControlTemplates>();
			CreateTemplateCollection();
			CurrentItem = templates.Skip(3).FirstOrDefault();
			OnPropertyChanged("CurrentItem");
			ClickedCommand = new Command<string>((arg) => NextPage(arg));
			Position = 3;
			OnPropertyChanged("Position");
		}

		private async void NextPage(string value)
		{
			switch(value)
			{
				case "Book":
					await Application.Current.MainPage.Navigation.PushAsync(new BookAppointment());
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

			//return list;
			templates = new ObservableCollection<ControlTemplates>(list);
			//return templates;
		}

		void PositionChanged(int position)
		{
			PreviousPosition = CurrentPosition;
			CurrentPosition = position;
			OnPropertyChanged("PreviousPosition");
			OnPropertyChanged("CurrentPosition");
		}

		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
