using Econic.Mobile.Models;
using Econic.Mobile.Services;
using Econic.Mobile.Views.Customer;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Econic.Mobile.ViewModels
{ 
	public class ControlTemplateViewModel : INotifyPropertyChanged
	{
		public ICommand ClickedCommand { private set; get; }
		public event PropertyChangedEventHandler PropertyChanged;

		public ControlTemplateViewModel() {
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
		
	}
}
