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
        void OnShippedChecked(object sender, EventArgs args)
        {
            ShippingRate.IsVisible = !ShippingRate.IsVisible;
        }
    }
}