using Econic.Mobile.Models;
using Econic.Mobile.ViewModels;
using System;
using Plugin.FilePicker;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Collections.Generic;
using Econic.Mobile.Services;
using Xamarin.Essentials;
using Syncfusion.SfImageEditor.XForms;

namespace Econic.Mobile.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItem : ContentPage
    {
        public AddItem()
        {
            InitializeComponent();
            editor.ImageSaving += ImageSavingEvent;
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
            editor.Save();
            savebutton.IsVisible = false;
        }
        private void ImageSavingEvent(object sender, ImageSavingEventArgs args)
        {
            var byteArray = GetImageStreamAsBytes(args.Stream);
            ItemModel prop = BindingContext.GetType().GetProperty("CurrentItemModel").GetValue(BindingContext) as ItemModel;
            prop.ImageSource = ImageSource.FromStream(() => new MemoryStream(byteArray));
            args.Cancel = true; // Stop the image from saving to location
        }
        void OnChangeClicked(object sender, EventArgs args)
        {
            OnAddPhotoButtonClicked(sender, args);
            //additemViewModel.OnAddPhotoButtonClicked(bodyContent, imageselector, imageNext, imageSkip, imageselectorFrame);
        }
        void OnTypeChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs args)
        {
            if(args.Value.ToString() == "Good")
            {
                StockCount.IsVisible = true;
                ShippingContent.IsVisible = true;
                ServiceDuration.IsVisible = false;
            }
            else
            {
                StockCount.IsVisible = false;
                ShippingContent.IsVisible = false;
                ServiceDuration.IsVisible = true;
            }
        }

        void OnShipChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
		{
            Console.WriteLine(e.Value);
            if(e.Value.ToString().Equals("Yes"))
            {
                ShippingRate.IsVisible = true;
            }
            if (e.Value.ToString().Equals("No"))
            {
                ShippingRate.IsVisible = false;
            }
        }

        void OnShippedChecked(object sender, EventArgs args)
        {
            ShippingRate.IsVisible = !ShippingRate.IsVisible;
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