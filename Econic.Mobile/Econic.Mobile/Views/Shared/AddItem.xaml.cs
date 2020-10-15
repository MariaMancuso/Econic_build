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
        PhotoPickerViewModel additemViewModel;
        public AddItem(OwnerViewModel OwnerVM, string mode)
        {
            InitializeComponent();
            imageselector.BindingContext = additemViewModel = new PhotoPickerViewModel();

            if(mode != "edit")
            {
                OwnerVM.ItemToAdd = new ItemModel();
                OwnerVM.ItemToAdd.Image = profilePicture;
            }
            bodyContent.BindingContext = OwnerVM;
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