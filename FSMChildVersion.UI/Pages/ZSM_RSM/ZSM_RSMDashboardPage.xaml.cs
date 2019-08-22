using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.UI.Pages.ZSM_RSM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true, NoHistory = false)]
    public partial class ZSM_RSMDashboardPage : MvxContentPage<ZSM_RSMDashboardViewModel>
    {
        public ZSM_RSMDashboardPage()
        {
            InitializeComponent();
        }
    }
}