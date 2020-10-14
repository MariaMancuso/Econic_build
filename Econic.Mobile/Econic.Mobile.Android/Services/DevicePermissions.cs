using System.Threading.Tasks;
using Acr.UserDialogs;
using Android;
using Android.Content.PM;
using Android.Runtime;
using Android.Support.V4.App;
using Econic.Mobile.Droid.Services;
using Econic.Mobile.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DevicePermissions))]
namespace Econic.Mobile.Droid.Services
{
    public class DevicePermissions : IPermissionService
    {
        public const int LocationCode = 1356;
        static TaskCompletionSource<bool> LocationPermissionTcs;

        public const int ContactCode = 1357;
        static TaskCompletionSource<bool> ContactPermissionTcs;

        public const int CalenderCode = 1358;
        static TaskCompletionSource<bool> CalenderPermissionTcs;

        async void RequestLocationPermission()
        {
            if (ActivityCompat.ShouldShowRequestPermissionRationale(MainActivity.FormsActivity, Manifest.Permission.AccessCoarseLocation))
            {
                await UserDialogs.Instance.AlertAsync("Location Permission", "This action requires Location permission", "Ok");
            }
            else
            {
                ActivityCompat.RequestPermissions(MainActivity.FormsActivity, new string[] { Manifest.Permission.AccessCoarseLocation }, LocationCode);
            }
        }
        public async Task<bool> RequestLocationPermissionAsync()
        {
            LocationPermissionTcs = new TaskCompletionSource<bool>();
            if (Android.Support.V4.Content.ContextCompat.CheckSelfPermission(MainActivity.FormsActivity, Manifest.Permission.AccessCoarseLocation) != (int)Permission.Granted)
            {
                RequestLocationPermission();
            }
            else
            {
                LocationPermissionTcs.TrySetResult(true);
            }
            return await LocationPermissionTcs.Task;
        }
        async void RequestContactPermission()
        {
            if (ActivityCompat.ShouldShowRequestPermissionRationale(MainActivity.FormsActivity, Manifest.Permission.ReadContacts))
            {
                await UserDialogs.Instance.AlertAsync("Contact Permission", "This action requires Contacts permission", "Ok");
            }
            else
            {
                ActivityCompat.RequestPermissions(MainActivity.FormsActivity, new string[] { Manifest.Permission.ReadContacts }, ContactCode);
            }
        }
        public async Task<bool> RequestContactPermissionAsync()
        {
            ContactPermissionTcs = new TaskCompletionSource<bool>();
            if (Android.Support.V4.Content.ContextCompat.CheckSelfPermission(MainActivity.FormsActivity, Manifest.Permission.ReadContacts) != (int)Permission.Granted)
            {
                RequestContactPermission();
            }
            else
            {
                ContactPermissionTcs.TrySetResult(true);
            }
            return await ContactPermissionTcs.Task;
        }
        async void RequestCalenderPermission()
        {
            if (ActivityCompat.ShouldShowRequestPermissionRationale(MainActivity.FormsActivity, Manifest.Permission.ReadCalendar))
            {
                await UserDialogs.Instance.AlertAsync("Calender Permission", "This action requires Calender permission", "Ok");
            }
            else
            {
                ActivityCompat.RequestPermissions(MainActivity.FormsActivity, new string[] { Manifest.Permission.ReadCalendar }, CalenderCode);
            }
        }
        public async Task<bool> RequestCalenderPermissionAsync()
        {
            CalenderPermissionTcs = new TaskCompletionSource<bool>();
            if (Android.Support.V4.Content.ContextCompat.CheckSelfPermission(MainActivity.FormsActivity, Manifest.Permission.ReadCalendar) != (int)Permission.Granted)
            {
                RequestCalenderPermission();
            }
            else
            {
                CalenderPermissionTcs.TrySetResult(true);
            }
            return await CalenderPermissionTcs.Task;
        }
        public static void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            if (requestCode == LocationCode)
            {
                if (PermissionUtil.VerifyPermissions(grantResults))
                {
                    LocationPermissionTcs.TrySetResult(true);
                }
                else
                {
                    LocationPermissionTcs.TrySetResult(false);
                }

            }
            if (requestCode == ContactCode)
            {
                if (PermissionUtil.VerifyPermissions(grantResults))
                {
                    ContactPermissionTcs.TrySetResult(true);
                }
                else
                {
                    ContactPermissionTcs.TrySetResult(false);
                }
            }
            if (requestCode == CalenderCode)
            {
                if (PermissionUtil.VerifyPermissions(grantResults))
                {
                    CalenderPermissionTcs.TrySetResult(true);
                }
                else
                {
                    CalenderPermissionTcs.TrySetResult(false);
                }
            }
        }

        public async Task<bool> RequestAllPermissions()
        {
            var location = await RequestLocationPermissionAsync();
            var contact = await RequestContactPermissionAsync();
            var calender = await RequestCalenderPermissionAsync();

            return location && contact && calender;
        }
    }
}