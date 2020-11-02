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

namespace Econic.Mobile.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItem : ContentPage
    {
        //PhotoPickerViewModel additemViewModel;
        public AddItem()
        {
            InitializeComponent();
            //imageselector.BindingContext = additemViewModel = new PhotoPickerViewModel();

            
        }
        void OnAddPhotoButtonClicked(object sender, EventArgs args)
        {
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