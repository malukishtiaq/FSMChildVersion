using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using UIKit;

namespace FSMChildVersion.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.App, UI.App>
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Rg.Plugins.Popup.Popup.Init();
            SQLitePCL.Batteries_V2.Init();
            return base.FinishedLaunching(app, options);
        }
    }
}
