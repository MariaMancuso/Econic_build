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
		public ObservableCollection<BoxColorModel> BoxColors { get; set; }
		public IList<BoxColorModel> box;

		public int PreviousPosition { get; set; }
		public int CurrentPosition { get; set; }
		public int Position { get; set; }

		public ControlTemplateViewModel() {
			list = new List<ControlTemplates>();
			CreateTemplateCollection();
			CreateBoxCollection();
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
			//BoxColors = new ObservableCollection<BoxColorModel>(box);
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
