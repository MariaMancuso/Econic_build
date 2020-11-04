using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.OwnerReg
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckNameClassifyBusiness : ContentPage
	{
		OwnerBoardingViewModel owner = new OwnerBoardingViewModel();

		public CheckNameClassifyBusiness()
		{
			InitializeComponent();
			gg.HeightRequest = Application.Current.MainPage.Height;
			//BindingContext = owner;
			goodsBox.BindingContext = owner;
			goodsBox.ComboBoxSource = owner.Goods;
		}

		
	}
}