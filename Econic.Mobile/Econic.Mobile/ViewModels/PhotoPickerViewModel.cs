using Econic.Mobile.Models;
using Econic.Mobile.Services;
using Econic.Mobile.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Econic.Mobile.ViewModels
{
    public class PhotoPickerViewModel : INotifyPropertyChanged
    {
        IMediaService mediaService;
        Frame currentSelectedFrame; //store the selected image frame from collection view
        bool isSelected; // determines is selected of the image
        Frame selectedFrame; //stores the previous selected image frame of collection view
        MediaAssest selectedMediaAsset; //this holds the selected image details

        public string SearchText { get; set; }
        public ObservableCollection<MediaAssest> MediaAssets { get; set; }

        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token;


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PhotoPickerViewModel()
        {

            mediaService = Xamarin.Forms.DependencyService.Get<IMediaService>();
            MediaAssets = new ObservableCollection<MediaAssest>();
            //token = source.Token;
            BindingBase.EnableCollectionSynchronization(MediaAssets, null, ObservableCollectionCallback);
            mediaService.OnMediaAssetLoaded += OnMediaAssetLoaded;
        }
        public void imageSkipTapped(Grid bodyContent, StackLayout imageselector)
        {
            bodyContent.Opacity = 1;
            bodyContent.InputTransparent = false;
            imageselector.IsVisible = false;
            isSelected = false;
            selectedMediaAsset = null;
            if (selectedFrame != null)
            {
                selectedFrame.BackgroundColor = Color.Transparent;
            }
        }
        public void ImageNextTapped(Image image, Grid bodyContent, StackLayout imageselector)
        {
            bodyContent.Opacity = 1;
            bodyContent.InputTransparent = false;
            imageselector.IsVisible = false;

            image.Source = selectedMediaAsset.Path;
            isSelected = false;
            selectedMediaAsset = null;
            selectedFrame.BackgroundColor = Color.Transparent;
        }
        public async void OnAddPhotoButtonClicked(Grid bodyContent, StackLayout imageselector, Frame imageNext, Frame imageSkip, Frame imageselectorFrame)
        {
            imageselector.IsVisible = true; //make image picker stack layout visible
            bodyContent.Opacity = 0.3; //make behing content opacity so that image picker gets attention
            bodyContent.InputTransparent = true; // disable any user interaction on main content
            imageNext.IsVisible = false;
            imageSkip.IsVisible = true;
            await imageselectorFrame.TranslateTo(0, imageselectorFrame.Y + 50, 300);
            await LoadMediaAssets(); //load the image from phone storage
        }
        public async void ImageTapped(object sender, EventArgs e, Image image, Grid bodyContent, StackLayout imageselector, Frame imageNext)
        {
            var s = (StackLayout)sender;
            var ss = s.Children[0] as Grid;
            var sss = ss.Children[0] as Frame;
            selectedFrame = ss.Children[1] as Frame;
            var clicked = (TappedEventArgs)e;
            var mediaAssest = (MediaAssest)clicked.Parameter;
            selectedMediaAsset = mediaAssest;
            if (mediaAssest.PreviewPath == "group.png")
            {
                CancelMediaAssests();
                var res = await mediaService.GetImageWithCamera();
                if (res != "")
                {
                    image.Source = res;
                    bodyContent.Opacity = 1;
                    bodyContent.InputTransparent = false;
                    imageselector.IsVisible = false;
                }
            }
            else
            {
                if (currentSelectedFrame != null)
                {
                    if (selectedFrame != currentSelectedFrame)
                    {
                        selectedFrame.BackgroundColor = Color.Green;
                        currentSelectedFrame.BackgroundColor = Color.Transparent;
                        currentSelectedFrame = selectedFrame;
                        isSelected = true;
                    }
                    else
                    {
                        if (selectedFrame.BackgroundColor == Color.Green)
                        {
                            selectedFrame.BackgroundColor = Color.Transparent;

                            currentSelectedFrame = selectedFrame;
                            isSelected = false;
                        }
                        else
                        {
                            selectedFrame.BackgroundColor = Color.Green;
                            isSelected = true;
                        }
                    }
                }
                else
                {
                    selectedFrame.BackgroundColor = Color.Green;
                    currentSelectedFrame = selectedFrame;
                    isSelected = true;
                }

                //display next button
                if (isSelected)
                {
                    //display next button
                    imageNext.IsVisible = true;
                    await imageNext.TranslateTo(0, 0, 300);
                }
                else
                {
                    //display skip options
                    imageNext.IsVisible = false;
                    await imageNext.TranslateTo(100, 0, 300);
                }

            }
        }
        void ObservableCollectionCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
        {
            // `lock` ensures that only one thread access the collection at a time
            lock (collection)
            {
                accessMethod?.Invoke();
            }
        }

        private void OnMediaAssetLoaded(object sender, MediaEventArgs e)
        {
            try
            {
                MediaAssets.Add(e.Media);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public async Task LoadMediaAssets()
        {
            try
            {
                if (source.IsCancellationRequested)
                {
                    source = new CancellationTokenSource();
                    token = source.Token;
                }
                else
                {
                    token = source.Token;
                }
                MediaAssets.Clear(); //clear list if already exists
                /*/
                 * Create default camera image as the first one
                 * so when click this image we can call camera action later
                 */
                MediaAssest defaultmedia = new MediaAssest();
                defaultmedia.PreviewPath = "group.png";
                defaultmedia.IsSelectable = false;
                MediaAssets.Add(defaultmedia);
                await mediaService.RetrieveMediaAssetsAsync(token);
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Task was cancelled");
            }
        }

        public void CancelMediaAssests()
        {
            //await _mediaService.RetrieveMediaAssetsAsync(token);
            source.Cancel();

        }
    }
}
