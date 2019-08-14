using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;

namespace FSMChildVersion.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.App, Core.App>
    {
    }
}
