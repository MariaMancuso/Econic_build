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
        OwnerViewModel _OwnerVM;
        PhotoPickerViewModel additemViewModel;
        ItemModel item;

        public AddItem(OwnerViewModel OwnerVM)
        {
            InitializeComponent();
            imageselector.BindingContext = additemViewModel = new PhotoPickerViewModel();
            bodyContent.BindingContext = item = new ItemModel();
            _OwnerVM = OwnerVM;
        }

        async void ContinueClicked(object sender, EventArgs args)
        {
            item.Image = profilePicture;
            await Navigation.PushAsync(new ItemPreview(_OwnerVM, item));
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