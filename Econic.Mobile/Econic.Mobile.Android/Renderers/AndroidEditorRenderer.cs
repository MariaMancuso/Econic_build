
using Android.Content;
using Econic.Mobile.Droid.Renderers;
using Econic.Mobile.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(AndroidEditorRenderer))]
namespace Econic.Mobile.Droid.Renderers
{
    public class AndroidEditorRenderer : EditorRenderer
    {
        public AndroidEditorRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
        }
    }
}