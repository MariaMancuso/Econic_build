using Econic.Mobile.Models;
using Econic.Mobile.Services;
using Econic.Mobile.Views.Customer;
using Econic.Mobile.Views.Templates;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Econic.Mobile.ViewModels
{ 
	public class ControlTemplateViewModel : INotifyPropertyChanged
	{

		public ICommand ClickedCommand { private set; get; }
		public event PropertyChangedEventHandler PropertyChanged;
		readonly IList<ControlTemplates> list;
		public ObservableCollection<ControlTemplates> templates;

		//DataTemplate classicTemplate = new DataTemplate(typeof(ClassicTemplate));
		//DataTemplate modernTemplate = new DataTemplate(typeof(ModernTemplate));
		//DataTemplate friendlyTemplate = new DataTemplate(typeof(FriendlyTemplate));

		public ControlTemplateViewModel() {
			list = new List<ControlTemplates>();
			CreateTemplateCollection();

			ClickedCommand = new Command<string>((arg) => NextPage(arg));
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
		
		public void CreateTemplateCollection()
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
	}
}
