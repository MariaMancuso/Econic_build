using Econic.Mobile.Models;
using Econic.Mobile.Services;
using Econic.Mobile.Views.Customer;
using Econic.Mobile.Views.Gamification;
using Econic.Mobile.Views.OwnerProfile;
using Econic.Mobile.Views.OwnerReg;
using Econic.Mobile.Views.Shared;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

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
