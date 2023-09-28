using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Xamarin.Essentials;

namespace Flash_Kullanimi
    //android manifest kısmını izin vermek için kullanıyoruz
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Button btn_ac = FindViewById<Button>(Resource.Id.button1);
            Button btn_kapat=FindViewById<Button>(Resource.Id.button2);
            btn_ac.Click += Btn_ac_Click;
            btn_kapat.Click += Btn_kapat_Click;
        }

        private async void Btn_kapat_Click(object sender, System.EventArgs e)
        {
            await Flashlight.TurnOffAsync();
        }

        private async void Btn_ac_Click(object sender, System.EventArgs e)
        {
            await Flashlight.TurnOnAsync();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}