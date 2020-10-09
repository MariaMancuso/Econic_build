using Econic.Mobile.Renderers;
using Android.Content;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Econic.Mobile.Droid.Renderers;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(AndroidEntryRenderer))]
namespace Econic.Mobile.Droid.Renderers
{
    class AndroidEntryRenderer : EntryRenderer
    {
        public AndroidEntryRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
        }
    }
}