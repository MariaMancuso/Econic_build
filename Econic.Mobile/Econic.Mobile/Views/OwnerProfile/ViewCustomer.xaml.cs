using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.OwnerProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewCustomer : ContentPage
    {
        public ViewCustomer()
        {
            InitializeComponent();
            buttonlist.ItemsSource = new string[] { "History", "Detail" };
        }
    }
}