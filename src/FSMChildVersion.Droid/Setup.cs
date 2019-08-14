using Acr.UserDialogs;
using Android.App;
using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;

#if DEBUG
[assembly: Application(Debuggable = true)]
#else
[assembly: Application(Debuggable = false)]
#endif

namespace FSMChildVersion.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.App, UI.App>
    {
        public Setup()
        {
        }
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
        }
    }
}
