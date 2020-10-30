using Econic.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.EconicStudio
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChooseLogo : ContentPage
	{
		PhotoPickerViewModel additemViewModel;
		//OwnerViewModel OwnerVM = new OwnerViewModel();
		public ChooseLogo(OwnerBoardingViewModel ownervm)
		{
			InitializeComponent();
			imageselector.BindingContext = additemViewModel = new PhotoPickerViewModel();
            bodyContent.BindingContext = ownervm;
		}

        void OnAddPhotoButtonClicked(object sender, EventArgs args)
        {
            additemViewModel.OnAddPhotoButtonClicked(bodyContent, imageselector, imageNext, imageSkip, imageselectorFrame);
        }
        void imageSkipTapped(Object sender, EventArgs e)
        {
            additemViewModel.imageSkipTapped(bodyContent, imageselector);
        }

        void imageNextTapped(System.Object sender, System.EventArgs e)
        {
            additemViewModel.ImageNextTapped(profilePicture, bodyContent, imageselector);
        }

        void imageTapped(System.Object sender, System.EventArgs e)
        {
            additemViewModel.ImageTapped(sender, e, profilePicture, bodyContent, imageselector, imageNext);
        }
    }
}