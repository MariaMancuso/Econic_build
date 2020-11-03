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
            editor.ToolbarSettings.IsVisible = false;
        }
        async void OnAddPhotoButtonClicked(object sender, EventArgs args)
        {

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
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
            savebutton.IsVisible = false;
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
        void imageSkipTapped(Object sender, EventArgs e)
        {
            //additemViewModel.imageSkipTapped(bodyContent, imageselector);
        }

        void imageNextTapped(System.Object sender, System.EventArgs e)
        {
            //additemViewModel.ImageNextTapped(profilePicture, bodyContent, imageselector);
        }

        void imageTapped(System.Object sender, System.EventArgs e)
        {
            //additemViewModel.ImageTapped(sender, e, profilePicture, bodyContent, imageselector, imageNext);
        }
    }
}