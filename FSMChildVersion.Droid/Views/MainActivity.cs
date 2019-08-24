using System.Diagnostics;
using Acr.UserDialogs;
using Android.App;
using Android.OS;
using FFImageLoading.Forms.Platform;
using FSMChildVersion.Core.ViewModels.Main;
using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Views;
using MvvmCross.Platforms.Android;

namespace FSMChildVersion.Droid
{
    [Activity(Theme = "@style/AppTheme")]
    public class MainActivity : MvxFormsAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            UserDialogs.Init(() => Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity);
            
            Rg.Plugins.Popup.Popup.Init(this, bundle);
            CachedImageRenderer.Init(true);
            base.OnCreate(bundle);
        }
        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            { }
            else
            { }
        }
    }
}
