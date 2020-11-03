using Econic.Mobile.Models;
using Econic.Mobile.Services;
using Econic.Mobile.ViewModels;
using Syncfusion.SfImageEditor.XForms;
using System;
using System.Collections.Generic;
using System.IO;
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
		//OwnerViewModel OwnerVM = new OwnerViewModel();
		public ChooseLogo(OwnerBoardingViewModel ownervm)
		{
			InitializeComponent();
            bodyContent.BindingContext = ownervm;
            //editor.ImageSaving += ImageSavingEvent;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            editor.ToolbarSettings.IsVisible = false;
        }
        async void OnAddPhotoButtonClicked(object sender, EventArgs args)
        {
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            StreamReader reader = new StreamReader(stream);
            if (stream != null)
            {
                editor.Source = ImageSource.FromStream(() => stream);
            }
        }
        private void CropEditor_ImageLoaded(object sender, ImageLoadedEventArgs args)
        {
            editor.ToggleCropping(1, 1);
            editcontent.IsVisible = true;
            savebutton.IsVisible = true;
            imageplaceholder.IsVisible = false;
        }
        void OnSaveClicked(object sender, EventArgs args)
        {
            editor.Crop();
            //editor.Save();
            savebutton.IsVisible = false;
        }
        private void ImageSavingEvent(object sender, ImageSavingEventArgs args)
        {
            args.Cancel = true; // Stop the image from saving to location

            var byteArray = GetImageStreamAsBytes(args.Stream);
            OwnerModel prop = BindingContext.GetType().GetProperty("Owner").GetValue(BindingContext) as OwnerModel;
            prop.LogoIcon.Source = ImageSource.FromStream(() => new MemoryStream(byteArray));
        }
        void OnChangeClicked(object sender, EventArgs args)
        {
            OnAddPhotoButtonClicked(sender, args);
        }
        private byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}